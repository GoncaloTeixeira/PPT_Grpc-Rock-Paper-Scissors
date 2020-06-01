using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using PPT_Grpc.Models;
using PPT_Grpc.Data;

namespace PPT_Grpc
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public readonly PlayerContext Context;
       

        public GreeterService(ILogger<GreeterService> logger, PlayerContext context)
        {
            _logger = logger;
            Context = context;
           
        }

        public override async Task<EnviarDados> Nome(EnviarNome Dados, ServerCallContext context)
        {
            Player Jogador = Context.Players.Where(x => x.Nome == Dados.Nome ).FirstOrDefault();
            if (Jogador==null)
            {
                Jogador= new Player();
                Jogador.Nome = Dados.Nome;
                Jogador.vitorias = 0;
                Jogador.empates = 0;
                Jogador.derrotas = 0;
                Context.Add(Jogador);
                Context.SaveChanges();
            }
           
            return await Task.FromResult(new EnviarDados
            {
                Nome = Jogador.Nome,
                Vitorias = Jogador.vitorias,
                Empates = Jogador.empates,
                Derrotas = Jogador.derrotas
            });
        }

        public override async Task<EnviarResultado> Jogar(EnviarJogada PJogada, ServerCallContext context)
        {
            int IRes;
            
            IRes = Jogo.JogarF(PJogada.Jogada);
            string auxResultado = Jogo.ResultadoText(IRes);
            //comparaçoes para incrementar resi«ultado


            Player Jogador = Context.Players.Where(x => x.Nome == PJogada.Nome).FirstOrDefault();
            if (IRes == 1)
            {
                Jogador.vitorias ++;
            }else if (IRes == 2)
            {
                Jogador.empates ++;
            }
            else
            {
                Jogador.derrotas++;
            }
            Context.Update(Jogador);
            Context.SaveChanges();
            return await Task.FromResult(new EnviarResultado
            {
                Resultado = auxResultado,
                Vitorias = Jogador.vitorias,
                Empates = Jogador.empates,
                Derrotas = Jogador.derrotas
            }) ;
        }




    }
}
