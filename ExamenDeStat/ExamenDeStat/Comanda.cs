using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExamenDeStat
{
   public class Comanda
    {    [Key]
        public int CodComanda { get; set; }

        public DateTime DataComanda  { get; set; }
        public double SumaTotala { get; set; }
        public int CodClient { get; set; }
        public string NumeClient { get; set; }
        
        public Client client { get; set; }
    }
}
