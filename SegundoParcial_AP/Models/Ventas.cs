using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial_AP.Models
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public float Monto { get; set; }
        public float Balance { get; set; }

        public virtual Clientes Cliente { get; set; }

        [ForeignKey("VentaId")]
        public virtual List<CobrosDetalle> cobrosDetalle { get; set; } = new List<CobrosDetalle>();
    }
}
