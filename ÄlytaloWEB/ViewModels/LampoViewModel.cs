using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ÄlytaloWEB.ViewModels
{
    public class LampoViewModel
    {
        public int Huone_ID { get; set; }
        public string Huone { get; set; }
        public string HuoneTavoiteLampo { get; set; }
        public string HuoneNykyLampo { get; set; }
        public DateTime? LampoKirjattu { get; set; }
        public bool LampoOn { get; set; }
        public bool LampoOff { get; set; }

        public char Astemerkki { get; set; }
    }
}