﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class AperturaProgramatica:Generica
    {

        public AperturaProgramatica() 
        {
            this.DetalleMetas = new HashSet<AperturaProgramaticaMeta>();
            this.DetalleSubElementos = new HashSet<AperturaProgramatica>();
        }

        [StringLength(50, ErrorMessage = "El campo {0} debe contener un máximo de {1} caracteres")]
        public string Clave { get; set; }
        public string Nombre { get; set; }

        public int? ParentId { get; set; }        
        public int EjercicioId { get; set; }
        public int? Nivel { get; set; }

        public int? AperturaProgramaticaBeneficiarioId { get; set; }
        public int? AperturaProgramaticaUnidadId { get; set; }

        public virtual Ejercicio Ejercicio { get; set; }        
        public virtual AperturaProgramatica Parent { get; set; }

        public virtual AperturaProgramaticaBeneficiario AperturaProgramaticaBeneficiario { get; set; }
        public virtual AperturaProgramaticaUnidad AperturaProgramaticaUnidad { get; set; } 

        public virtual ICollection<AperturaProgramaticaMeta> DetalleMetas { get; set; }
        public virtual ICollection<AperturaProgramatica> DetalleSubElementos { get; set; }


        


    }

    public enum enumObraAccion 
    {
        Obra=1,
        Accion=2
    }
}
