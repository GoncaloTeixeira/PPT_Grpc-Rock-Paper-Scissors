using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PPT_Grpc.Data;
using PPT_Grpc.Models;

namespace PPT_Grpc.Controllers
{
    public class PlayerController : Controller
    {
        public readonly PlayerContext Context;
        public PlayerController(PlayerContext context)
        {
            Context = context;
        }
        
      
        public async Task<IActionResult> AdicionarPlayer(string _nome)
        {
            
            Player Jexistente = Context.Players.Where(x => x.Nome == _nome).FirstOrDefault();

            if (Jexistente==null)
            {
                Player Jogador = new Player
                {
                    Nome = _nome,
                    vitorias = 0,
                    empates = 0,
                    derrotas = 0
                    
                };
                Context.Add(Jogador);
                await Context.SaveChangesAsync();
                return RedirectToAction("Jogar");
            }
            
          
            return RedirectToAction("Jogar");
        }
    }
}
