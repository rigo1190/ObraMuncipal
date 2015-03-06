using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Financiamiento:Generica
    {
        public int EjercicioId { get; set; }
        public int FondoId { get; set; }
        public decimal Importe { get; set; }
        public decimal Ampliaciones { get; set; }

        public decimal Reducciones { get; set; }

        public decimal Importe_final{get;set;}

        public virtual Ejercicio Ejercicio{ get; set; }
        public virtual Fondo Fondo { get; set; }
        

    }
}
