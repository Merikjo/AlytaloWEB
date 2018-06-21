using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ÄlytaloWEB.ViewModels
{
    public class LightsViewModel
    {
        
        public int Valo_ID { get; set; }
        public string Huone { get; set; }

        [Display(Name = "Valaisin")]
        public string ValaisinType { get; set; }
        [Display(Name = "Valaisin koodi")]
        public string Lamppu_ID { get; set; }

        [Display(Name = "Valot pois")]
        public bool ValoTilaOff { get; set; }
        public bool Valo33 { get; set; }
        public bool Valo66 { get; set; }
        public bool Valo100 { get; set; }
        public Nullable<System.DateTime> ValoOn33 { get; set; }
        public Nullable<System.DateTime> ValoOn66 { get; set; }
        public Nullable<System.DateTime> ValoOn100 { get; set; }
        public Nullable<System.DateTime> ValoOff { get; set; }
    }
}