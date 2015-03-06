using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class Obra:Generica
    {
        

        
        [Index(IsUnique = true)]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Numero { get; set; }
        public string Nombre { get; set; }
        public int MunicipioId { get; set; }       
        public int LocalidadId { get; set; }        
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }  
        
        public int AperturaProgramaticaId { get; set; }
        public int AperturaProgramaticaMetaId { get; set; }
        public int CantidadMetas { get; set; }
        public int CantidadBeneficiarios { get; set; }
        public enumModalidadObra? ModalidadObra { get; set; }

        public int Status { get; set; }

        public DateTime? FechaInicioContrato { get; set; }
        public DateTime? FechaTerminoContrato { get; set; }  


        public int FuncionalidadId { get; set; }
        public int EjeId { get; set; }
        public int PlanSectorialId { get; set; }
        public int ModalidadId { get; set; }
        public int ProgramaId { get; set; }
        public int GrupoBeneficiarioId { get; set; }

        public int DependenciaEjecutoraId { get; set; }

        public string Observaciones { get; set; }

        public int EsObra { get; set; }
        
        public int StatusControlFinanciero { get; set; }

        public int EjercicioId { get; set; }
        



        
        public virtual Municipio Municipio { get; set; }
        public virtual Localidad Localidad { get; set; }       
        public virtual AperturaProgramatica AperturaProgramatica { get; set; }
        public virtual AperturaProgramaticaMeta AperturaProgramaticaMeta { get; set; }
        
        
        public virtual Funcionalidad Funcionalidad { get; set; }
        public virtual Eje Eje { get; set; }
        public virtual PlanSectorial PlanSectorial { get; set; }
        public virtual Modalidad Modalidad { get; set; }
        public virtual Programa Programa { get; set; }
        public virtual GrupoBeneficiario GrupoBeneficiario { get; set; }

        public virtual DependenciaEjecutora DependenciaEjecutora { get; set; }

        public virtual Ejercicio Ejercicio { get; set; }


        

    }

    public enum enumModalidadObra 
    {
        Contrato=1,
        [Display(Name="Administración directa")]
        AdministracionDirecta=2,
    }
}
