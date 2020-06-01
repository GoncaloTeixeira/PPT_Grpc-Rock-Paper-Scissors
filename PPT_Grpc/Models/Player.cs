using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace PPT_Grpc.Models
{
    public class Player
    {
        [Key]
        public string Nome { get; set; }
       
        [Range(0, int.MaxValue)]
       
        public int vitorias { get; set; }
       
        [Range(0, int.MaxValue)]
  
        public int empates { get; set; }
  
        [Range(0, int.MaxValue)]

        public int derrotas { get; set; }
        

    }
    
    
}
