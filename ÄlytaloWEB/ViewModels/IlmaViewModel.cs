using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ÄlytaloWEB.ViewModels
{
    public class IlmaViewModel
    {

        public int Ilma_ID { get; set; }
        public string Huone { get; set; }

        [Display(Name = "IlmaOff")]
        public bool IlmaTilaOff { get; set; }
        public bool Ilma1 { get; set; }
        public bool Ilma2 { get; set; }
        public bool Ilma3 { get; set; }
        public bool Ilma4 { get; set; }
        public Nullable<System.DateTime> IlmaOn1 { get; set; }
        public Nullable<System.DateTime> IlmaOn2 { get; set; }
        public Nullable<System.DateTime> IlmaOn3 { get; set; }
        public Nullable<System.DateTime> IlmaOn4 { get; set; }
        public Nullable<System.DateTime> IlmaOff { get; set; }
    }
}