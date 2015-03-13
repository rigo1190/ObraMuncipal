using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class GruposConceptosDeObra:Generica
    {

        public GruposConceptosDeObra()
        {
            this.detalleSubelementos = new HashSet<GruposConceptosDeObra>();
        }

        public int EjercicioId { get; set; }
        
        [StringLength(50, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Clave { get; set; }
                
        public string Nombre { get; set; }


        public int? ParentId { get; set; }

        public int Nivel { get; set; }

        public virtual Ejercicio Ejercicio { get; set; }
        public virtual GruposConceptosDeObra Parent { get; set; }

        public virtual ICollection<GruposConceptosDeObra> detalleSubelementos { get; set; }

    }
}
