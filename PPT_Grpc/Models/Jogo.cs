using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPT_Grpc.Models
{
    public class Jogo
    {
        public string Pjogada { get; set; }
        public string Sjogada { get; set; }

        public int Resultado { get; set; }

        //0 Vitoria do servidor 
        //1 Vitotia do cliente
        //2 Empate




        public static int  JogarF(string Pjogada)
        {
                string SJogada;
                Random random=new Random();

                int aux = random.Next(0, 4);
                if (aux == 1)
                {
                    SJogada = "Rock";
                }else if (aux == 2)
                {
                    SJogada = "Paper";
                }
                else
                {
                    SJogada = "Scissors";
                }

                if (Pjogada == SJogada)
                {
                    return 2;
                }
                if(Pjogada=="Rock"&& SJogada == "Scissors")
                {
                    return 1;//Vitoria do Player/Cliente

                }else if(Pjogada == "Paper" && SJogada == "Rock")
                {
                    return 1;//Vitoria do Player/Cliente

                }else if (Pjogada == "Scissors" && SJogada == "Paper")
                {
                    return 1;//Vitoria do Player/Cliente

                }
                else
                {
                    return 0;//Vitoria do Servidor
                }

        } 

        public static string ResultadoText(int Iresul)
        {
            string Sresultado=" ";

            if (Iresul == 0) 
                Sresultado = "Vitoria do Servidor";

            if (Iresul == 1)
                Sresultado = "Vitoria do Jogador";

            if (Iresul == 2)
                Sresultado = "Empate";


            return Sresultado;
        }

    }

  







}
