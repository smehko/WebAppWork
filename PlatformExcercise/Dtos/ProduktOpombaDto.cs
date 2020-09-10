using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlatformExcercise.Dtos
{
    public class ProduktOpombaDto
    {
        public int Id { get; set; }
        public string Produkt { get; set; }
        public string Stranka { get; set; }
        public string Cena { get; set; }
        public string Opomba { get; set; }
        public string DatumOpombe { get; set; }
    }
}