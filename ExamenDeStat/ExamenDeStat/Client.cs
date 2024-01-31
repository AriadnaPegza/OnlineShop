using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExamenDeStat
{
    public class Client
    {
        [Key]
        public int CodClient { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
    }
}
