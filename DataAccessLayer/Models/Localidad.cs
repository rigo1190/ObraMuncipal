using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Localidad:Generica
    {       
        [StringLength(50, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]       
        public string Clave { get; set; }

        [StringLength(100, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Nombre { get; set; }
        public int MunicipioId { get; set; }
        public virtual Municipio Municipio { get; set; }
    }
}
