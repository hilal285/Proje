using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace ProjeAdi.Models
    {
        public class Muzik
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Şarkı ismi zorunludur")]
            public string SarkiIsmi { get; set; }

            public string AlbumIsmi { get; set; }

            [Required(ErrorMessage = "Sanatçı ismi zorunludur")]
            public string Artist { get; set; }

            public string SarkiSuresi { get; set; }

            public int? CikisYili { get; set; }
        }
    }








