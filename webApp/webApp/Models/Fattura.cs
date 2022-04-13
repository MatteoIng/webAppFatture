using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webApp.Models
{
    [Table("Fattura")]
    public class Fattura
    {
        public long id { get; set; }
        public string numeroFattura { get; set; }
        public DateTime? dataFattura { get; set; }
        public DateTime? dataRicezione { get; set; }
        public string intestatario { get; set; }
        public float? importo { get; set; }
        public string metodoPagamento { get; set; }
        public string pagatore { get; set; }
        public DateTime? dataPagamento { get; set; }
    }
}
