using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_SIF.Models
{
    public class InventarioCuernavaca
    {
        [Key]
        public int idConsecutivo { get; set; }
        public int entrada { get; set; }
        public DateTime? fechaentrada { get; set; }
        public double unidad2 { get; set; }
        public int unidad2historial { get; set; }
        public int unidadempaque2 { get; set; }
        public decimal unidad3 { get; set; }
        public int idProducto { get; set; }
        public string lote { get; set; }
        public int procedencia { get; set; }
        public int ubicacion { get; set; }
        public string comentario { get; set; }
        public int cliente { get; set; }
        public int? folio { get; set; }
        public string folios { get; set; }
        public string loteexterno { get; set; }
        public decimal valor { get; set; }
        public int embolsado { get; set; }
        public int tipocambio { get; set; }
        public int idordencompradetalle { get; set; }

    }
}
