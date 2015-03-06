using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace BusinessLogicLayer
{
    public class UnitOfWork : IDisposable
    {
        private Contexto contexto;

        public Contexto Contexto
        {
            get { return contexto; }            
        }
        private int usuarioId;
        private List<String> errors = new List<String>();
        private IBusinessLogic<Usuario> usuarioBusinessLogic;
        private IBusinessLogic<Rol> rolBusinessLogic;        
        private IBusinessLogic<Permiso> permisoBusinessLogic;
        private IBusinessLogic<OpcionSistema> opcionSistemaBusinessLogic;
        private IBusinessLogic<UsuarioRol> usuarioRolBusinessLogic;
        private IBusinessLogic<Ejercicio> ejercicioBusinessLogic;
        private IBusinessLogic<Municipio> municipioBusinessLogic;
        private IBusinessLogic<Localidad> localidadBusinessLogic;
        private IBusinessLogic<Fondo> fondoBusinessLogic;
        private IBusinessLogic<Financiamiento> financiamientoBusinessLogic;
        private IBusinessLogic<Sector> sectorBusinessLogic;
        private IBusinessLogic<AperturaProgramatica> aperturaProgramaticaBusinessLogic;
        
        private IBusinessLogic<AperturaProgramaticaMeta> aperturaProgramaticaMetaBusinessLogic;
        private IBusinessLogic<AperturaProgramaticaBeneficiario> aperturaProgramaticaBeneficiarioBusinessLogic;
        private IBusinessLogic<AperturaProgramaticaUnidad> aperturaProgramaticaUnidadBusinessLogic;
        private IBusinessLogic<Obra> obraBusinessLogic;
        private IBusinessLogic<ObraFinanciamiento> obraFinanciamientoBusinessLogic;
        private IBusinessLogic<Funcionalidad> funcionalidadBusinessLogic;
        private IBusinessLogic<Eje> ejeBusinessLogic;
        private IBusinessLogic<PlanSectorial> planSectorialBusinessLogic;
        private IBusinessLogic<Modalidad> modalidadBusinessLogic;
        private IBusinessLogic<Programa> programaBusinessLogic;
        private IBusinessLogic<GrupoBeneficiario> grupoBeneficiarioBusinessLogic;
        private IBusinessLogic<DependenciaEjecutora> dependenciaejecutoraBL;
        private IBusinessLogic<Firmas> firmasBL;

        private IBusinessLogic<ContratosDeObra> contratosdeobraBL;
        private IBusinessLogic<PresupuestosContratados> presupuestosscontratadosBL;
        private IBusinessLogic<Estimaciones> estimacionesBL;
        private IBusinessLogic<EstimacionesConceptos> estimacionesconceptosBL;
        private IBusinessLogic<EstimacionesConceptosTMP> estimacionesconceptostmpBL;

        private IBusinessLogic<ProgramasDeObras> programasdeobrasBL;
        private IBusinessLogic<ProgramasDeObrasTMP> programasdeobrastmpBL;
        private IBusinessLogic<EstimacionesProgramadas> estimacionesprogramadasBL;
        private IBusinessLogic<EstimacionesProgramadasConceptos> estimacionesprogramadasconceptosBL;
		
        

        public UnitOfWork()
        {
            this.contexto = new Contexto();
        }

        public UnitOfWork(string usuarioId)
        {           
            this.usuarioId = Utilerias.StrToInt(usuarioId);
            this.contexto = new Contexto();
        }



        

        public IBusinessLogic<Usuario> UsuarioBusinessLogic
        {
            get
            {
                if (this.usuarioBusinessLogic == null)
                {
                    this.usuarioBusinessLogic = new GenericBusinessLogic<Usuario>(contexto);
                }

                return usuarioBusinessLogic;
            }
        }

        public IBusinessLogic<Rol> RolBusinessLogic
        {
            get
            {
                if (this.rolBusinessLogic == null)
                {
                    this.rolBusinessLogic = new GenericBusinessLogic<Rol>(contexto);
                }

                return rolBusinessLogic;
            }
        }

        public IBusinessLogic<UsuarioRol> UsuarioRolBusinessLogic
        {
            get
            {
                if (this.usuarioRolBusinessLogic == null)
                {
                    this.usuarioRolBusinessLogic = new GenericBusinessLogic<UsuarioRol>(contexto);
                }

                return usuarioRolBusinessLogic;
            }
        }

        public IBusinessLogic<Permiso> PermisoBusinessLogic
        {
            get
            {
                if (this.permisoBusinessLogic == null)
                {
                    this.permisoBusinessLogic = new GenericBusinessLogic<Permiso>(contexto);
                }

                return permisoBusinessLogic;
            }
        }

        public IBusinessLogic<OpcionSistema> OpcionSistemaBusinessLogic
        {
            get
            {
                if (this.opcionSistemaBusinessLogic == null)
                {
                    this.opcionSistemaBusinessLogic = new GenericBusinessLogic<OpcionSistema>(contexto);
                }

                return opcionSistemaBusinessLogic;
            }
        }


        public IBusinessLogic<Ejercicio> EjercicioBusinessLogic
        {
            get
            {
                if (this.ejercicioBusinessLogic == null)
                {
                    this.ejercicioBusinessLogic = new GenericBusinessLogic<Ejercicio>(contexto);
                }

                return ejercicioBusinessLogic;
            }
        }


        public IBusinessLogic<Municipio> MunicipioBusinessLogic
        {
            get
            {
                if (this.municipioBusinessLogic == null)
                {
                    this.municipioBusinessLogic = new GenericBusinessLogic<Municipio>(contexto);
                }

                return municipioBusinessLogic;
            }
        }

        public IBusinessLogic<Localidad> LocalidadBusinessLogic
        {
            get
            {
                if (this.localidadBusinessLogic == null)
                {
                    this.localidadBusinessLogic = new GenericBusinessLogic<Localidad>(contexto);
                }

                return localidadBusinessLogic;
            }
        }

        public IBusinessLogic<Fondo> FondoBusinessLogic
        {
            get
            {
                if (this.fondoBusinessLogic == null)
                {
                    this.fondoBusinessLogic = new GenericBusinessLogic<Fondo>(contexto);
                }

                return fondoBusinessLogic;
            }
        }



        public IBusinessLogic<Financiamiento> FinanciamientoBusinessLogic
        {
            get
            {
                if (this.financiamientoBusinessLogic == null)
                {
                    this.financiamientoBusinessLogic = new GenericBusinessLogic<Financiamiento>(contexto);
                }

                return financiamientoBusinessLogic;
            }
        }

        


        public IBusinessLogic<Sector> SectorBusinessLogic
        {
            get
            {
                if (this.sectorBusinessLogic == null)
                {
                    this.sectorBusinessLogic = new GenericBusinessLogic<Sector>(contexto);
                }

                return sectorBusinessLogic;
            }
        }


        

        public IBusinessLogic<AperturaProgramatica> AperturaProgramaticaBusinessLogic
        {
            get
            {
                if (this.aperturaProgramaticaBusinessLogic == null)
                {
                    this.aperturaProgramaticaBusinessLogic = new GenericBusinessLogic<AperturaProgramatica>(contexto);
                }

                return aperturaProgramaticaBusinessLogic;
            }
        }

     

        public IBusinessLogic<AperturaProgramaticaMeta> AperturaProgramaticaMetaBusinessLogic
        {
            get
            {
                if (this.aperturaProgramaticaMetaBusinessLogic == null)
                {
                    this.aperturaProgramaticaMetaBusinessLogic = new GenericBusinessLogic<AperturaProgramaticaMeta>(contexto);
                }

                return aperturaProgramaticaMetaBusinessLogic;
            }
        }

        public IBusinessLogic<AperturaProgramaticaBeneficiario> AperturaProgramaticaBeneficiarioBusinessLogic
        {
            get
            {
                if (this.aperturaProgramaticaBeneficiarioBusinessLogic == null)
                {
                    this.aperturaProgramaticaBeneficiarioBusinessLogic = new GenericBusinessLogic<AperturaProgramaticaBeneficiario>(contexto);
                }

                return aperturaProgramaticaBeneficiarioBusinessLogic;
            }
        }

        public IBusinessLogic<AperturaProgramaticaUnidad> AperturaProgramaticaUnidadBusinessLogic
        {
            get
            {
                if (this.aperturaProgramaticaUnidadBusinessLogic == null)
                {
                    this.aperturaProgramaticaUnidadBusinessLogic = new GenericBusinessLogic<AperturaProgramaticaUnidad>(contexto);
                }

                return aperturaProgramaticaUnidadBusinessLogic;
            }
        }

        public IBusinessLogic<Obra> ObraBusinessLogic
        {
            get
            {
                if (this.obraBusinessLogic == null)
                {
                    this.obraBusinessLogic = new GenericBusinessLogic<Obra>(contexto);
                }

                return obraBusinessLogic;
            }
        }

        public IBusinessLogic<ObraFinanciamiento> ObraFinanciamientoBusinessLogic
        {
            get
            {
                if (this.obraFinanciamientoBusinessLogic == null)
                {
                    this.obraFinanciamientoBusinessLogic = new GenericBusinessLogic<ObraFinanciamiento>(contexto);
                }

                return obraFinanciamientoBusinessLogic;
            }
        }



        /// <summary>
        /// Agregado por Rigoberto TS 
        /// 25/09/2014
        /// </summary>

        public IBusinessLogic<Funcionalidad> FuncionalidadBusinessLogic
        {
            get
            {
                if (this.funcionalidadBusinessLogic == null)
                {
                    this.funcionalidadBusinessLogic = new GenericBusinessLogic<Funcionalidad>(contexto);
                }

                return funcionalidadBusinessLogic;
            }
        }

        public IBusinessLogic<Eje> EjeBusinessLogic
        {
            get
            {
                if (this.ejeBusinessLogic == null)
                {
                    this.ejeBusinessLogic = new GenericBusinessLogic<Eje>(contexto);
                }

                return ejeBusinessLogic;
            }
        }

        public IBusinessLogic<PlanSectorial> PlanSectorialBusinessLogic
        {
            get
            {
                if (this.planSectorialBusinessLogic == null)
                {
                    this.planSectorialBusinessLogic = new GenericBusinessLogic<PlanSectorial>(contexto);
                }

                return planSectorialBusinessLogic;
            }
        }

        public IBusinessLogic<Modalidad> ModalidadBusinessLogic
        {
            get
            {
                if (this.modalidadBusinessLogic == null)
                {
                    this.modalidadBusinessLogic = new GenericBusinessLogic<Modalidad>(contexto);
                }

                return modalidadBusinessLogic;
            }
        }

        public IBusinessLogic<Programa> ProgramaBusinessLogic
        {
            get
            {
                if (this.programaBusinessLogic == null)
                {
                    this.programaBusinessLogic = new GenericBusinessLogic<Programa>(contexto);
                }

                return programaBusinessLogic;
            }
        }

        public IBusinessLogic<GrupoBeneficiario> GrupoBeneficiarioBusinessLogic
        {
            get
            {
                if (this.grupoBeneficiarioBusinessLogic == null)
                {
                    this.grupoBeneficiarioBusinessLogic = new GenericBusinessLogic<GrupoBeneficiario>(contexto);
                }

                return grupoBeneficiarioBusinessLogic;
            }
        }


        public IBusinessLogic<DependenciaEjecutora> DependenciaEjecutoraBL
        {
            get
            {
                if (this.dependenciaejecutoraBL == null)
                {
                    this.dependenciaejecutoraBL = new GenericBusinessLogic<DependenciaEjecutora>(contexto);
                }
                return this.dependenciaejecutoraBL; 
            }
        }




        public IBusinessLogic<Firmas> FirmasBL
        {
            get
            {
                if (this.firmasBL == null)
                {
                    this.firmasBL = new GenericBusinessLogic<Firmas>(contexto);
                }
                return this.firmasBL;
            }
        }

        public IBusinessLogic<ContratosDeObra> ContratosDeObraBL
        {
            get
            {
                if (this.contratosdeobraBL == null)
                {
                    this.contratosdeobraBL = new GenericBusinessLogic<ContratosDeObra>(contexto);
                         
                }
                return this.contratosdeobraBL;
            }
        }



        

        public IBusinessLogic<PresupuestosContratados> PresupuestosContratadosBL
        { 
            get {
                if (this.presupuestosscontratadosBL == null)
                {
                    this.presupuestosscontratadosBL = new GenericBusinessLogic<PresupuestosContratados>(contexto);
                         
                }
                return this.presupuestosscontratadosBL;
            } 
        }


        public IBusinessLogic<Estimaciones> EstimacionesBL
        {
            get
            {
                if (this.estimacionesBL == null)
                {
                    this.estimacionesBL = new GenericBusinessLogic<Estimaciones>(contexto);
                }
                return this.estimacionesBL;
            }
        }


        public IBusinessLogic<EstimacionesConceptos> EstimacionesConceptosBL
        {
            get{
                if (this.estimacionesconceptosBL == null)
                {
                    this.estimacionesconceptosBL = new GenericBusinessLogic<EstimacionesConceptos>(contexto);
                }
                return this.estimacionesconceptosBL;
            }
        }

        public IBusinessLogic<EstimacionesConceptosTMP> EstimacionesConceptosTMPBL
        {
            get
            {
                if (this.estimacionesconceptostmpBL == null)
                {
                    this.estimacionesconceptostmpBL = new GenericBusinessLogic<EstimacionesConceptosTMP>(contexto);
                }
                return this.estimacionesconceptostmpBL;
            }
        }

        public IBusinessLogic<ProgramasDeObras> ProgramasDeObrasBL
        {
            get
            {
                if (this.programasdeobrasBL == null)
                {
                    this.programasdeobrasBL = new GenericBusinessLogic<ProgramasDeObras>(contexto);
                }

                return this.programasdeobrasBL;
            }
        }


        public IBusinessLogic<ProgramasDeObrasTMP> ProgramasDeObraTMPBL
        {
            get
            {
                if (this.programasdeobrastmpBL == null)
                {
                    this.programasdeobrastmpBL = new GenericBusinessLogic<ProgramasDeObrasTMP>(contexto);
                }
                return this.programasdeobrastmpBL;
            }
        }
        
        public IBusinessLogic<EstimacionesProgramadas> EstimacionesProgramadasBL
        {
            get
            {
                if (this.estimacionesprogramadasBL == null)
                {
                    this.estimacionesprogramadasBL = new GenericBusinessLogic<EstimacionesProgramadas>(contexto);
                }
                return this.estimacionesprogramadasBL;
            }
        }

        public IBusinessLogic<EstimacionesProgramadasConceptos> EstimacionesProgramadasConceptosBL
        {
            get
            {
                if (this.estimacionesprogramadasconceptosBL == null)
                {
                    this.estimacionesprogramadasconceptosBL = new GenericBusinessLogic<EstimacionesProgramadasConceptos>(contexto);
                }
                return this.estimacionesprogramadasconceptosBL;
            }
        }
        
     
        public void SaveChanges()
        {
            try
            {
                errors.Clear();
                contexto.SaveChanges(usuarioId);
            }
            catch (DbEntityValidationException ex)
            {

                this.RollBack();

                foreach (var item in ex.EntityValidationErrors)
                {

                    errors.Add(String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors", item.Entry.Entity.GetType().Name, item.Entry.State));

                    foreach (var error in item.ValidationErrors)
                    {
                        errors.Add(String.Format("Propiedad: \"{0}\", Error: \"{1}\"", error.PropertyName, error.ErrorMessage));
                    }


                }

            }
            catch (DbUpdateException ex)
            {
                this.RollBack();
                errors.Add(String.Format("{0}", ex.InnerException.InnerException.Message));
            }
            catch (System.InvalidOperationException ex)
            {
                this.RollBack();
                errors.Add(String.Format("{0}", ex.Message));
            }
            catch (Exception ex)
            {
                this.RollBack();
                errors.Add(String.Format("{0}\n{1}", ex.Message, ex.InnerException.Message));
            }
            
        }

        public void RollBack()
        {

            var changedEntries = contexto.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged);

            // ojo....... respetar el orden en que se evalua el atributo State
            // primero Deleted,segundo Modified, al final y nada mas que al final Added
            // debido a que una vez que asignamos el estado Detached a una entidad,
            // desasociamos a esta del contexto y el filtro changedEntries.Where(etc....) genera un error

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Deleted))
            {
                entry.State = EntityState.Unchanged;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Modified))
            {
                entry.CurrentValues.SetValues(entry.OriginalValues);
                entry.State = EntityState.Unchanged;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Added))
            {
                entry.State = EntityState.Detached;
            }                       

        }

        public List<String> Errors 
        {
            get 
            {
                return errors;
            }
        }

        public object GetResult() 
        {
            if (errors.Count == 0) 
            {
                return new { OK = true };
            }

            return new  { OK = false, Errors = errors };
        }
        
        
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    contexto.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
    
}
