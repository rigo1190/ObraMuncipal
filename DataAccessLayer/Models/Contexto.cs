using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Contexto : DbContext
    {
        private int userId;
       
        public Contexto()
            : base("BD3SoftObraPublica")
        {
            System.Diagnostics.Debug.Print(Database.Connection.ConnectionString);
        }            

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {          
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            modelBuilder.Entity<UsuarioRol>()
              .HasRequired(c => c.Usuario)
              .WithMany(d => d.DetalleRoles)
              .HasForeignKey(c => c.UsuarioId);

            
            modelBuilder.Entity<AperturaProgramaticaMeta>()
             .HasRequired(u => u.AperturaProgramatica)
             .WithMany(u => u.DetalleMetas)
             .HasForeignKey(u => u.AperturaProgramaticaId)
             .WillCascadeOnDelete(true);         
            
        }

        public int SaveChanges(int userId)
        {

            var creados = this.ChangeTracker.Entries()
                            .Where(e => e.State == System.Data.Entity.EntityState.Added)
                            .Select(e => e.Entity).OfType<Generica>().ToList();

            foreach (var item in creados)
            {
                item.CreatedAt = DateTime.Now;
                item.CreatedById = (userId==0)?null:(int?)userId;
            }

            var modificados = this.ChangeTracker.Entries()
                            .Where(e => e.State == System.Data.Entity.EntityState.Modified)
                            .Select(e => e.Entity).OfType<Generica>().ToList();

            foreach (var item in modificados)
            {
                item.EditedAt = DateTime.Now;
                item.EditedById = (userId == 0) ? null : (int?)userId;
            }

            return SaveChanges();
            

        }

        public virtual DbSet<Ejercicio> Ejercicios { get; set; }
        
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Localidad> Localidades { get; set; }
        public virtual DbSet<Sector> Sectores { get; set; }
        public virtual DbSet<Fondo> Fondos { get; set; }
        
        public virtual DbSet<Financiamiento> Financiamientos { get; set; }
        public virtual DbSet<AperturaProgramatica> AperturaProgramatica { get; set; }
        public virtual DbSet<AperturaProgramaticaMeta> AperturaProgramaticaMetas { get; set; }
        public virtual DbSet<AperturaProgramaticaUnidad> AperturaProgramaticaUnidades { get; set; }
        public virtual DbSet<AperturaProgramaticaBeneficiario> AperturaProgramaticaBeneficiarios { get; set; }

        public virtual DbSet<Obra> Obras { get; set; }
        public virtual DbSet<ObraFinanciamiento> ObraFinanciamientos { get; set; }
    
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<OpcionSistema> OpcionesSistema { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRoles { get; set; }
        
        public virtual DbSet<Funcionalidad> Funcionalidad { get; set; }
        public virtual DbSet<Eje> Eje { get; set; }
        public virtual DbSet<PlanSectorial> PlanSectorial { get; set; }
        public virtual DbSet<Modalidad> Modalidad { get; set; }
        public virtual DbSet<Programa> Programa { get; set; }
        public virtual DbSet<GrupoBeneficiario> GrupoBeneficiario { get; set; }

        public virtual DbSet<DependenciaEjecutora> DBSdependenciaEjecutora { get; set; }

        public virtual DbSet<Firmas> Firmas { get; set; }
        public virtual DbSet<ContratosDeObra> DBScontratosDeObra { get; set; }        
        public virtual DbSet<PresupuestosContratados> DBSpresupuestosContratados { get; set; }
        public virtual DbSet<Estimaciones> DBSestimaciones { get; set; }
        public virtual DbSet<EstimacionesConceptos> DBSestimacionesConceptos { get; set; }
        public virtual DbSet<EstimacionesConceptosTMP> DBestimacionesConceptosTMP { get; set; }
        public virtual DbSet<ProgramasDeObras> DBSprogramasdeobras { get; set; }
        public virtual DbSet<ProgramasDeObrasTMP> DBSprogramasdeobrastmp { get; set; }
        public virtual DbSet<EstimacionesProgramadas> DBSestimacionesprogramadas { get; set; }
        public virtual DbSet<EstimacionesProgramadasConceptos> DBSestimacionesprogramadasconceptos { get; set; }
        
        
        }

}
