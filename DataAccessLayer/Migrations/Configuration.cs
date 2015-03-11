namespace DataAccessLayer.Migrations
{
    using DataAccessLayer.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.Models.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAccessLayer.Models.Contexto context)
        {
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //



            return;
            context.Roles.AddOrUpdate(
            
                new Rol { Id = 1 , Clave="R001", Nombre="Desarrollador", Orden=1, EsSefiplan=true,EsDependencia=false},
                new Rol { Id = 2, Clave = "R002", Nombre = "Ejecutivo", Orden = 2, EsSefiplan = true, EsDependencia = false },
                new Rol { Id = 3, Clave = "R003", Nombre = "Administrador", Orden = 3, EsSefiplan = true, EsDependencia = false },
                new Rol { Id = 4, Clave = "R004", Nombre = "Capturista", Orden = 4, EsSefiplan = false, EsDependencia = true },
                new Rol { Id = 5, Clave = "R005", Nombre = "Analista", Orden = 5, EsSefiplan = true, EsDependencia = false }   
            );

            
            

            context.Usuarios.AddOrUpdate(

               new Usuario { Id = 1, Login = "desarrollador", Password = "desarrollador", Nombre = "Usuario Desarrollador", Activo = true,RolId=1 },
               new Usuario { Id = 2, Login = "ejecutivo", Password = "ejecutivo", Nombre = "Usuario Ejecutivo", Activo = true, RolId = 2 },
               new Usuario { Id = 3, Login = "admin", Password = "admin", Nombre = "Usuario Administrador", Activo = true, RolId = 3 },
               new Usuario { Id = 4, Login = "sedarpa", Password = "sedarpa", Nombre = "Capturista de SEDARPA", Activo = true, RolId = 4 },
               new Usuario { Id = 5, Login = "iiev", Password = "iiev", Nombre = "Capturista de IIEV", Activo = true, RolId = 4 },
               new Usuario { Id = 6, Login = "inverbio", Password = "inverbio", Nombre = "Capturista de INVERBIO", Activo = true, RolId = 4 } ,
               new Usuario { Id = 7, Login = "analista", Password = "analista", Nombre = "Analista en SEFIPLAN", Activo = true, RolId = 5 }               
            );

           

            context.OpcionesSistema.AddOrUpdate(
            
                new OpcionSistema { Id = 1, Clave = "OS001", Descripcion = "Captura del proyecto de POA",Activo=true,Orden=1},
                new OpcionSistema { Id = 2, Clave = "OS002", Descripcion = "Ajuste del POA",Activo=true,Orden=2},
                new OpcionSistema { Id = 3, Clave = "OS003", Descripcion = "Catálogos",Activo=true,Orden=3},
                new OpcionSistema { Id = 4, Clave = "OS004", Descripcion = "Catálogo de Unidades presupuestales", Activo = true, Orden = 1,ParentId=3 },
                new OpcionSistema { Id = 5, Clave = "OS005", Descripcion = "Catálogo de Fondos", Activo = true, Orden = 2, ParentId = 3 },
                new OpcionSistema { Id = 6, Clave = "OS006", Descripcion = "Catálogo de Apertura programatica", Activo = true, Orden = 3, ParentId = 3 },
                new OpcionSistema { Id = 7, Clave = "OS007", Descripcion = "Catálogo de Municipios", Activo = true, Orden = 4, ParentId = 3 },
                new OpcionSistema { Id = 8, Clave = "OS008", Descripcion = "Catálogo de Ejercicios", Activo = true, Orden = 5, ParentId = 3 },
                new OpcionSistema { Id = 9, Clave = "OS009", Descripcion = "Catálogo de Usuarios", Activo = true, Orden = 6, ParentId = 3 }

            );

            context.Permisos.AddOrUpdate(

                new Permiso { Id = 1, RolId = 3, OpcionSistemaId = 4, Operaciones = enumOperaciones.Agregar | enumOperaciones.Editar | enumOperaciones.Detalle | enumOperaciones.Borrar },
                new Permiso { Id = 2, RolId = 3, OpcionSistemaId = 5, Operaciones = enumOperaciones.Agregar | enumOperaciones.Editar | enumOperaciones.Detalle | enumOperaciones.Borrar },
                new Permiso { Id = 3, RolId = 3, OpcionSistemaId = 6, Operaciones = enumOperaciones.Agregar | enumOperaciones.Editar | enumOperaciones.Detalle | enumOperaciones.Borrar },
                new Permiso { Id = 4, RolId = 4, OpcionSistemaId = 1, Operaciones = enumOperaciones.Agregar | enumOperaciones.Editar | enumOperaciones.Detalle | enumOperaciones.Borrar },
                new Permiso { Id = 5, RolId = 4, OpcionSistemaId = 2, Operaciones = enumOperaciones.Agregar | enumOperaciones.Editar | enumOperaciones.Detalle }
                
            );            
            

            context.Ejercicios.AddOrUpdate(              
               new Ejercicio { Id = 1, Año = 2015, FactorIva = 1.6M, Estatus = enumEstatusEjercicio.Activo  },
               new Ejercicio { Id = 2, Año = 2016, FactorIva = 1.6M, Estatus = enumEstatusEjercicio.Nuevo   }               
            );

        

            Usuario usedarpa = context.Usuarios.Local.FirstOrDefault(u => u.Login == "sedarpa");
            Usuario uiiev = context.Usuarios.Local.FirstOrDefault(u => u.Login == "iiev");
            Usuario uinverbio = context.Usuarios.Local.FirstOrDefault(u => u.Login == "inverbio");

        

            context.Municipios.AddOrUpdate(              
              new Municipio {Id=1,Clave="M001",Nombre="Acajete" },
              new Municipio {Id=2,Clave="M002",Nombre="Acatlán" },
              new Municipio {Id=3,Clave="M003",Nombre="Acayucan" },
              new Municipio {Id=4,Clave="M004",Nombre="Actopan" }              
            );

            context.Localidades.AddOrUpdate(
                new Localidad { Id = 1, Nombre = "Primer localidad de Acajete", MunicipioId = 1 },
                new Localidad { Id = 2, Nombre = "Segunda localidad de Acajete", MunicipioId = 1}
                
            );

            
           

           context.Fondos.AddOrUpdate(
             new Fondo { Id = 1, Clave = "01", Nombre = "FISM",EjercicioId =1 },
             new Fondo { Id = 2, Clave = "02", Nombre = "FORTAMUN" ,EjercicioId=1}
           );







           context.AperturaProgramaticaUnidades.AddOrUpdate(
               new AperturaProgramaticaUnidad { Id = 1, Clave = "APU001", Nombre = "Planta" },
               new AperturaProgramaticaUnidad { Id = 2, Clave = "APU002", Nombre = "Pozo" },
               new AperturaProgramaticaUnidad { Id = 3, Clave = "APU003", Nombre = "Tanque" },
               new AperturaProgramaticaUnidad { Id = 4, Clave = "APU004", Nombre = "Metro lineal" },
               new AperturaProgramaticaUnidad { Id = 5, Clave = "APU005", Nombre = "Sistema" },
               new AperturaProgramaticaUnidad { Id = 6, Clave = "APU006", Nombre = "Obra" },
               new AperturaProgramaticaUnidad { Id = 7, Clave = "APU007", Nombre = "Pozo" },
               new AperturaProgramaticaUnidad { Id = 8, Clave = "APU008", Nombre = "Olla" }

           );

           context.AperturaProgramaticaBeneficiarios.AddOrUpdate(
             new AperturaProgramaticaBeneficiario { Id = 1, Clave = "APB001", Nombre = "Persona" },
             new AperturaProgramaticaBeneficiario { Id = 2, Clave = "APB002", Nombre = "Productor" },
             new AperturaProgramaticaBeneficiario { Id = 3, Clave = "APB003", Nombre = "Familia" },
             new AperturaProgramaticaBeneficiario { Id = 4, Clave = "APB004", Nombre = "Alumno" }

           );

           context.AperturaProgramatica.AddOrUpdate(
               new AperturaProgramatica { Id = 1, Clave = "SC", Nombre = "Agua y saneamiento (Agua potable)", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 2, Clave = "SD", Nombre = "Agua y saneamiento (Drenaje)", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 3, Clave = "SE", Nombre = "Urbanización municipal", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 4, Clave = "SG", Nombre = "Electrificación", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 5, Clave = "SO", Nombre = "Salud", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 6, Clave = "SJ", Nombre = "Educación", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 7, Clave = "SH", Nombre = "Vivienda", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 8, Clave = "UB", Nombre = "Caminos rurales", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 9, Clave = "IR", Nombre = "Infraestructura productiva rural", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 10, Clave = "EP", Nombre = "Estudios", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 11, Clave = "DI", Nombre = "Programa de desarrollo institucional municipal y de las demarcaciones territoriales del distrito federal", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 12, Clave = "U9", Nombre = "Gastos indirectos", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 13, Clave = "PP", Nombre = "Prevención presupuestaria", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 14, Clave = "DP", Nombre = "Deuda pública", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 15, Clave = "PA", Nombre = "Auditoría", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 16, Clave = "SP", Nombre = "Seguridad pública municipal", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 17, Clave = "FM", Nombre = "Fortalecimiento municipal", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 18, Clave = "UM", Nombre = "Equipamiento urbano", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 19, Clave = "PE", Nombre = "Protección y preservación ecológica", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 20, Clave = "BM", Nombre = "Bienes muebles", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 21, Clave = "BI", Nombre = "Bienes inmuebles", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 22, Clave = "PM", Nombre = "Planeación municipal", EjercicioId = 2, Nivel = 1 },
               new AperturaProgramatica { Id = 23, Clave = "SB", Nombre = "Estímulos a la educación", EjercicioId = 2, Nivel = 1 }
            );

           AperturaProgramatica sc = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "SC");

           sc.DetalleSubElementos.Add(new AperturaProgramatica { Id = 24, Clave = "01", Nombre = "Rehabilitación", EjercicioId = 2, Nivel = 2 });
           sc.DetalleSubElementos.Add(new AperturaProgramatica { Id = 25, Clave = "02", Nombre = "Ampliación", EjercicioId = 2, Nivel = 2 });
           sc.DetalleSubElementos.Add(new AperturaProgramatica { Id = 26, Clave = "03", Nombre = "Construcción", EjercicioId = 2, Nivel = 2 });
           sc.DetalleSubElementos.Add(new AperturaProgramatica { Id = 27, Clave = "04", Nombre = "Mantenimiento", EjercicioId = 2, Nivel = 2 });
           sc.DetalleSubElementos.Add(new AperturaProgramatica { Id = 28, Clave = "05", Nombre = "Equipamiento", EjercicioId = 2, Nivel = 2 });
           sc.DetalleSubElementos.Add(new AperturaProgramatica { Id = 29, Clave = "06", Nombre = "Sustitución", EjercicioId = 2, Nivel = 2 });


           AperturaProgramatica sd = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "SD");

           sd.DetalleSubElementos.Add(new AperturaProgramatica { Id = 30, Clave = "01", Nombre = "Rehabilitación", EjercicioId = 2, Nivel = 2 });
           sd.DetalleSubElementos.Add(new AperturaProgramatica { Id = 31, Clave = "02", Nombre = "Ampliación", EjercicioId = 2, Nivel = 2 });
           sd.DetalleSubElementos.Add(new AperturaProgramatica { Id = 32, Clave = "03", Nombre = "Construcción", EjercicioId = 2, Nivel = 2 });
           sd.DetalleSubElementos.Add(new AperturaProgramatica { Id = 33, Clave = "04", Nombre = "Mantenimiento", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica se = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "SE");

           se.DetalleSubElementos.Add(new AperturaProgramatica { Id = 34, Clave = "01", Nombre = "Rehabilitación", EjercicioId = 2, Nivel = 2 });
           se.DetalleSubElementos.Add(new AperturaProgramatica { Id = 35, Clave = "02", Nombre = "Construcción", EjercicioId = 2, Nivel = 2 });
           se.DetalleSubElementos.Add(new AperturaProgramatica { Id = 36, Clave = "03", Nombre = "Ampliación", EjercicioId = 2, Nivel = 2 });
           se.DetalleSubElementos.Add(new AperturaProgramatica { Id = 37, Clave = "04", Nombre = "Mantenimiento", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica sg = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "SG");

           sg.DetalleSubElementos.Add(new AperturaProgramatica { Id = 38, Clave = "01", Nombre = "Rehabilitación", EjercicioId = 2, Nivel = 2 });
           sg.DetalleSubElementos.Add(new AperturaProgramatica { Id = 39, Clave = "02", Nombre = "Ampliación", EjercicioId = 2, Nivel = 2 });
           sg.DetalleSubElementos.Add(new AperturaProgramatica { Id = 40, Clave = "03", Nombre = "Construcción", EjercicioId = 2, Nivel = 2 });
           sg.DetalleSubElementos.Add(new AperturaProgramatica { Id = 41, Clave = "04", Nombre = "Mantenimiento", EjercicioId = 2, Nivel = 2 });
           sg.DetalleSubElementos.Add(new AperturaProgramatica { Id = 42, Clave = "05", Nombre = "Equipamiento", EjercicioId = 2, Nivel = 2 });


           AperturaProgramatica so = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "SO");

           so.DetalleSubElementos.Add(new AperturaProgramatica { Id = 43, Clave = "01", Nombre = "Rehabilitación", EjercicioId = 2, Nivel = 2 });
           so.DetalleSubElementos.Add(new AperturaProgramatica { Id = 44, Clave = "02", Nombre = "Ampliación", EjercicioId = 2, Nivel = 2 });
           so.DetalleSubElementos.Add(new AperturaProgramatica { Id = 45, Clave = "03", Nombre = "Construcción", EjercicioId = 2, Nivel = 2 });
           so.DetalleSubElementos.Add(new AperturaProgramatica { Id = 46, Clave = "04", Nombre = "Mantenimiento", EjercicioId = 2, Nivel = 2 });
           so.DetalleSubElementos.Add(new AperturaProgramatica { Id = 47, Clave = "05", Nombre = "Equipamiento", EjercicioId = 2, Nivel = 2 });


           AperturaProgramatica sj = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "SJ");

           sj.DetalleSubElementos.Add(new AperturaProgramatica { Id = 48, Clave = "01", Nombre = "Rehabilitación", EjercicioId = 2, Nivel = 2 });
           sj.DetalleSubElementos.Add(new AperturaProgramatica { Id = 49, Clave = "02", Nombre = "Construcción", EjercicioId = 2, Nivel = 2 });
           sj.DetalleSubElementos.Add(new AperturaProgramatica { Id = 50, Clave = "03", Nombre = "Equipamiento", EjercicioId = 2, Nivel = 2 });
           sj.DetalleSubElementos.Add(new AperturaProgramatica { Id = 51, Clave = "04", Nombre = "Ampliación", EjercicioId = 2, Nivel = 2 });
           sj.DetalleSubElementos.Add(new AperturaProgramatica { Id = 52, Clave = "05", Nombre = "Mantenimiento", EjercicioId = 2, Nivel = 2 });


           AperturaProgramatica sh = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "SH");

           sh.DetalleSubElementos.Add(new AperturaProgramatica { Id = 53, Clave = "01", Nombre = "Rehabilitación", EjercicioId = 2, Nivel = 2 });
           sh.DetalleSubElementos.Add(new AperturaProgramatica { Id = 54, Clave = "02", Nombre = "Construcción", EjercicioId = 2, Nivel = 2 });
           sh.DetalleSubElementos.Add(new AperturaProgramatica { Id = 55, Clave = "03", Nombre = "Equipamiento", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica ub = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "UB");

           ub.DetalleSubElementos.Add(new AperturaProgramatica { Id = 56, Clave = "01", Nombre = "Rehabilitación", EjercicioId = 2, Nivel = 2 });
           ub.DetalleSubElementos.Add(new AperturaProgramatica { Id = 57, Clave = "02", Nombre = "Construcción", EjercicioId = 2, Nivel = 2 });
           ub.DetalleSubElementos.Add(new AperturaProgramatica { Id = 58, Clave = "03", Nombre = "Ampliación", EjercicioId = 2, Nivel = 2 });
           ub.DetalleSubElementos.Add(new AperturaProgramatica { Id = 59, Clave = "04", Nombre = "Mantenimiento", EjercicioId = 2, Nivel = 2 });


           AperturaProgramatica ir = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "IR");

           ir.DetalleSubElementos.Add(new AperturaProgramatica { Id = 60, Clave = "01", Nombre = "Rehabilitación", EjercicioId = 2, Nivel = 2 });
           ir.DetalleSubElementos.Add(new AperturaProgramatica { Id = 61, Clave = "02", Nombre = "Ampliación", EjercicioId = 2, Nivel = 2 });
           ir.DetalleSubElementos.Add(new AperturaProgramatica { Id = 62, Clave = "03", Nombre = "Construcción", EjercicioId = 2, Nivel = 2 });
           ir.DetalleSubElementos.Add(new AperturaProgramatica { Id = 63, Clave = "04", Nombre = "Mantenimiento", EjercicioId = 2, Nivel = 2 });
           ir.DetalleSubElementos.Add(new AperturaProgramatica { Id = 64, Clave = "05", Nombre = "Equipamiento", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica ep = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "EP");

           ep.DetalleSubElementos.Add(new AperturaProgramatica { Id = 65, Clave = "01", Nombre = "Estudios", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica di = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "DI");

           di.DetalleSubElementos.Add(new AperturaProgramatica { Id = 66, Clave = "01", Nombre = "Programa de desarrollo institucional municipal y de las demarcaciones territoriales del distrito federal", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica u9 = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "U9");

           u9.DetalleSubElementos.Add(new AperturaProgramatica { Id = 67, Clave = "01", Nombre = "Realización de estudios asociados a los proyectos", EjercicioId = 2, Nivel = 2 });
           u9.DetalleSubElementos.Add(new AperturaProgramatica { Id = 68, Clave = "02", Nombre = "Seguimiento de obra", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica pp = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "PP");

           pp.DetalleSubElementos.Add(new AperturaProgramatica { Id = 69, Clave = "01", Nombre = "Prevención presupuestaria", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica dp = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "DP");

           dp.DetalleSubElementos.Add(new AperturaProgramatica { Id = 70, Clave = "01", Nombre = "Deuda pública", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica pa = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "PA");

           pa.DetalleSubElementos.Add(new AperturaProgramatica { Id = 71, Clave = "01", Nombre = "Auditoría", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica sp = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "SP");

           sp.DetalleSubElementos.Add(new AperturaProgramatica { Id = 72, Clave = "01", Nombre = "Recursos humanos", EjercicioId = 2, Nivel = 2 });
           sp.DetalleSubElementos.Add(new AperturaProgramatica { Id = 73, Clave = "02", Nombre = "Equipos y accesorios", EjercicioId = 2, Nivel = 2 });


           AperturaProgramatica fm = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "FM");

           fm.DetalleSubElementos.Add(new AperturaProgramatica { Id = 74, Clave = "01", Nombre = "Capacitación", EjercicioId = 2, Nivel = 2 });
           fm.DetalleSubElementos.Add(new AperturaProgramatica { Id = 75, Clave = "02", Nombre = "Pago de servicios municipales", EjercicioId = 2, Nivel = 2 });
           fm.DetalleSubElementos.Add(new AperturaProgramatica { Id = 76, Clave = "03", Nombre = "Vehículos terrestres", EjercicioId = 2, Nivel = 2 });
           fm.DetalleSubElementos.Add(new AperturaProgramatica { Id = 77, Clave = "04", Nombre = "Sistematización de procesos", EjercicioId = 2, Nivel = 2 });
           fm.DetalleSubElementos.Add(new AperturaProgramatica { Id = 78, Clave = "05", Nombre = "Protección civil municipal", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica um = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "UM");

           um.DetalleSubElementos.Add(new AperturaProgramatica { Id = 79, Clave = "01", Nombre = "Rehabilitación", EjercicioId = 2, Nivel = 2 });
           um.DetalleSubElementos.Add(new AperturaProgramatica { Id = 80, Clave = "02", Nombre = "Construcción", EjercicioId = 2, Nivel = 2 });
           um.DetalleSubElementos.Add(new AperturaProgramatica { Id = 81, Clave = "03", Nombre = "Ampliación", EjercicioId = 2, Nivel = 2 });
           um.DetalleSubElementos.Add(new AperturaProgramatica { Id = 82, Clave = "04", Nombre = "Mantenimiento", EjercicioId = 2, Nivel = 2 });
           um.DetalleSubElementos.Add(new AperturaProgramatica { Id = 83, Clave = "05", Nombre = "Equipamiento", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica pe = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "PE");

           pe.DetalleSubElementos.Add(new AperturaProgramatica { Id = 84, Clave = "01", Nombre = "Manejo de residuos solidos", EjercicioId = 2, Nivel = 2 });
           pe.DetalleSubElementos.Add(new AperturaProgramatica { Id = 85, Clave = "02", Nombre = "Reforestación", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica be = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "BM");

           be.DetalleSubElementos.Add(new AperturaProgramatica { Id = 86, Clave = "01", Nombre = "Adquisiciones", EjercicioId = 2, Nivel = 2 });
           be.DetalleSubElementos.Add(new AperturaProgramatica { Id = 87, Clave = "02", Nombre = "Otros", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica bi = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "BI");

           bi.DetalleSubElementos.Add(new AperturaProgramatica { Id = 88, Clave = "01", Nombre = "Adquisiciones", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica pm = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "PM");

           pm.DetalleSubElementos.Add(new AperturaProgramatica { Id = 89, Clave = "01", Nombre = "Estudios", EjercicioId = 2, Nivel = 2 });

           AperturaProgramatica sb = context.AperturaProgramatica.Local.FirstOrDefault(ap => ap.Clave == "SB");

           sb.DetalleSubElementos.Add(new AperturaProgramatica { Id = 90, Clave = "01", Nombre = "Becas y despensas", EjercicioId = 2, Nivel = 2 });



           //context.AperturaProgramaticaMetas.AddOrUpdate(
           //    new AperturaProgramaticaMeta { Id = 1, AperturaProgramaticaId = 91, AperturaProgramaticaUnidadId = 1, AperturaProgramaticaBeneficiarioId = 1 },
           //    new AperturaProgramaticaMeta { Id = 2, AperturaProgramaticaId = 92, AperturaProgramaticaUnidadId = 2, AperturaProgramaticaBeneficiarioId = 1 },
           //    new AperturaProgramaticaMeta { Id = 3, AperturaProgramaticaId = 93, AperturaProgramaticaUnidadId = 3, AperturaProgramaticaBeneficiarioId = 1 },
           //    new AperturaProgramaticaMeta { Id = 4, AperturaProgramaticaId = 94, AperturaProgramaticaUnidadId = 4, AperturaProgramaticaBeneficiarioId = 1 },
           //    new AperturaProgramaticaMeta { Id = 5, AperturaProgramaticaId = 95, AperturaProgramaticaUnidadId = 4, AperturaProgramaticaBeneficiarioId = 1 },
           //    new AperturaProgramaticaMeta { Id = 6, AperturaProgramaticaId = 96, AperturaProgramaticaUnidadId = 5, AperturaProgramaticaBeneficiarioId = 1 },
           //    new AperturaProgramaticaMeta { Id = 7, AperturaProgramaticaId = 97, AperturaProgramaticaUnidadId = 6, AperturaProgramaticaBeneficiarioId = 1 },
           //    new AperturaProgramaticaMeta { Id = 8, AperturaProgramaticaId = 98, AperturaProgramaticaUnidadId = 6, AperturaProgramaticaBeneficiarioId = 1 },
           //    new AperturaProgramaticaMeta { Id = 9, AperturaProgramaticaId = 99, AperturaProgramaticaUnidadId = 7, AperturaProgramaticaBeneficiarioId = 1 },
           //    new AperturaProgramaticaMeta { Id = 10, AperturaProgramaticaId = 100, AperturaProgramaticaUnidadId = 8, AperturaProgramaticaBeneficiarioId = 1 }
           //);




           context.Funcionalidad.AddOrUpdate(
            new Funcionalidad { Id = 1, Clave = "F001", Descripcion = "Gobierno", Nivel=1 },
            new Funcionalidad { Id = 2, Clave = "F002", Descripcion = "Desarrollo Social", Nivel = 1 },
            new Funcionalidad { Id = 3, Clave = "F003", Descripcion = "Desarrollo Económico", Nivel = 1 }           
            );

           Funcionalidad fgobierno = context.Funcionalidad.Local.FirstOrDefault(f => f.Clave == "F001");
           Funcionalidad fdesarrollosocial = context.Funcionalidad.Local.FirstOrDefault(f => f.Clave == "F002");
           Funcionalidad fdesarrolloeconomico = context.Funcionalidad.Local.FirstOrDefault(f => f.Clave == "F003");

           fgobierno.DetalleSubElementos.Add(new Funcionalidad { Id = 4, Clave = "F004", Descripcion = "Legislación", Nivel = 2 });
           fgobierno.DetalleSubElementos.Add(new Funcionalidad { Id = 5, Clave = "F005", Descripcion = "Fiscalización", Nivel = 2 });
           fgobierno.DetalleSubElementos.Add(new Funcionalidad { Id = 6, Clave = "F006", Descripcion = "Justicia", Nivel = 2 });

           fdesarrollosocial.DetalleSubElementos.Add(new Funcionalidad { Id = 7, Clave = "F007", Descripcion = "Protección ambiental", Nivel = 2 });
           fdesarrollosocial.DetalleSubElementos.Add(new Funcionalidad { Id = 8, Clave = "F008", Descripcion = "Vivienda y servicios a la comunidad", Nivel = 2 });
           fdesarrollosocial.DetalleSubElementos.Add(new Funcionalidad { Id = 9, Clave = "F009", Descripcion = "Salud",  Nivel = 2 });

           fdesarrolloeconomico.DetalleSubElementos.Add(new Funcionalidad { Id = 10, Clave = "F010", Descripcion = "Asuntos económicos, comerciales y laborales en general", Nivel = 2 });
           fdesarrolloeconomico.DetalleSubElementos.Add(new Funcionalidad { Id = 11, Clave = "F011", Descripcion = "Agropecuaria, silvicultura, pesca y caza",  Nivel = 2 });
           fdesarrolloeconomico.DetalleSubElementos.Add(new Funcionalidad { Id = 12, Clave = "F012", Descripcion = "Combustible y energía", Nivel = 2 });

           Funcionalidad flegislacion = context.Funcionalidad.Local.FirstOrDefault(f => f.Clave == "F004");
           Funcionalidad ffiscalizacion = context.Funcionalidad.Local.FirstOrDefault(f => f.Clave == "F005");
           Funcionalidad fjusticia = context.Funcionalidad.Local.FirstOrDefault(f => f.Clave == "F006");

           flegislacion.DetalleSubElementos.Add(new Funcionalidad { Id = 13, Clave = "F013", Descripcion = "Legislación",  Nivel = 3 });
           ffiscalizacion.DetalleSubElementos.Add(new Funcionalidad { Id = 14, Clave = "F014", Descripcion = "Fiscalización",  Nivel = 3 });

           fjusticia.DetalleSubElementos.Add(new Funcionalidad { Id = 15, Clave = "F015", Descripcion = "Impartición de Justicia",  Nivel = 3 });
           fjusticia.DetalleSubElementos.Add(new Funcionalidad { Id = 16, Clave = "F016", Descripcion = "Procuración de Justicia",  Nivel = 3 });
           fjusticia.DetalleSubElementos.Add(new Funcionalidad { Id = 17, Clave = "F017", Descripcion = "Reclusión y readaptación social",  Nivel = 3 });
           fjusticia.DetalleSubElementos.Add(new Funcionalidad { Id = 18, Clave = "F018", Descripcion = "Derechos humanos",  Nivel = 3 });


          context.Eje.AddOrUpdate(
                new Eje { Id = 1, Clave = "A", Descripcion = "Construir el presente: Un mejor futuro para todos", Nivel = 1 },
                new Eje { Id = 2, Clave = "B", Descripcion = "Economía fuerte para el progreso de la gente",  Nivel = 1 },
                new Eje { Id = 3, Clave = "C", Descripcion = "Un Veracruz sustentable", Nivel = 1 },
                new Eje { Id = 4, Clave = "D", Descripcion = "Gobierno y administración eficientes y transparentes", Nivel = 1 }
        
          );

          Eje ejeA = context.Eje.Local.FirstOrDefault(e => e.Clave == "A");

          ejeA.DetalleSubElementos.Add(new Eje { Id = 5, Clave = "A005", Descripcion = "Combatir rezagos para salir adelante", Nivel=2 });
          ejeA.DetalleSubElementos.Add(new Eje { Id = 6, Clave = "A006", Descripcion = "El valor de la civilización indígena", Nivel = 2 });
          ejeA.DetalleSubElementos.Add(new Eje { Id = 7, Clave = "A007", Descripcion = "La familia veracruzana", Nivel = 2 });
          ejeA.DetalleSubElementos.Add(new Eje { Id = 8, Clave = "A008", Descripcion = "Igualdad de género", Nivel = 2 });
          ejeA.DetalleSubElementos.Add(new Eje { Id = 9, Clave = "A009", Descripcion = "Juventud: oportunidad y compromiso", Nivel = 2 });


          context.PlanSectorial.AddOrUpdate(
              new PlanSectorial { Id = 1, Clave = "A", Descripcion = "Programa Veracruzano de Desarrollo Agropecuario, Rural, Forestal y Pesca.", Nivel=1 },
              new PlanSectorial { Id = 2, Clave = "B", Descripcion = "Programa Veracruzano de Salud.", Nivel = 1 },
              new PlanSectorial { Id = 3, Clave = "C", Descripcion = "Programa Veracruzano de Asistencia Social.", Nivel = 1 },
              new PlanSectorial { Id = 4, Clave = "D", Descripcion = "Programa Veracruzano de Educación.", Nivel = 1 }           

          );

          context.Modalidad.AddOrUpdate(
            new Modalidad { Id = 1, Clave = "M001", Descripcion = "Subsidios: Sector Social y Privado o Entidades Federativas y Municipios", Nivel=1 },
            new Modalidad { Id = 2, Clave = "M002", Descripcion = "Desempeño de las Funciones", Nivel=1 },
            new Modalidad { Id = 3, Clave = "M003", Descripcion = "Administrativos y de Apoyo", Nivel=1 },
            new Modalidad { Id = 4, Clave = "M004", Descripcion = "Programas de Gasto Federalizado (Gobierno Federal)", Nivel=1 }
          );

          Modalidad mSubsidios = context.Modalidad.Local.FirstOrDefault(m => m.Clave == "M001");

          mSubsidios.DetalleSubElementos.Add(new Modalidad { Id = 5, Clave = "S", Descripcion = "Sujetos a Reglas de Operación", Nivel = 2 });
          mSubsidios.DetalleSubElementos.Add(new Modalidad { Id = 6, Clave = "U", Descripcion = "Otros Subsidios", Nivel = 2 });


          context.Programa.AddOrUpdate(
             new Programa { Id = 1, Clave = "010", Descripcion = "Formación y Orientación Educativa", Tipo = "A.I.", Objetivo = "Contribuir al desarrollo de las tareas de los alumnos, padres y profesores dentro del ámbito específico de los centros escolares."},
             new Programa { Id = 2, Clave = "011", Descripcion = "Centros de Desarrollo Infantil", Tipo = "A.I.", Objetivo = "Brindar servicios de cuidado, salud, alimentación y estimulación a los hijos de las trabajadoras de la Secretaría de Educación de Veracruz de edades comprendidas entre 45 días y 5 años 11 meses."},
             new Programa { Id = 3, Clave = "012", Descripcion = "Educación Básica Nivel Preescolar", Tipo = "A.I.", Objetivo = "Atender y apoyar desde edades tempranas a los menores para favorecer el desarrollo de sus potencialidades y capacidades, lo que permitirá un mejordesarrollo personal y social."}            

          );

          context.GrupoBeneficiario.AddOrUpdate(
              new GrupoBeneficiario { Id = 1, Clave = "A", Nombre = "Adulto Mayor" },
              new GrupoBeneficiario { Id = 2, Clave = "B", Nombre = "Alumno" },
              new GrupoBeneficiario { Id = 3, Clave = "C", Nombre = "Artesano"},
              new GrupoBeneficiario { Id = 4, Clave = "D", Nombre = "Artista"},
              new GrupoBeneficiario { Id = 5, Clave = "E", Nombre = "Contribuyente" },
              new GrupoBeneficiario { Id = 6, Clave = "F", Nombre = "Damnificado" }

          );

          

                    

          context.SaveChanges();

          
           
        }


        private void CrearTriggers(Contexto contexto)
        {

            string sp001 = @" CREATE TRIGGER trgAsignarNumeroObra_POADetalle ON [dbo].[POADetalle] 
                                FOR INSERT
                                AS
	                               
									 declare @consecutivo int;
						             declare @UnidadPresupuestalClave varchar(9);
						             declare @anio int;
						             declare @poadetalleId int;
						             declare @poaId int;
						             declare @numeroObra varchar(100);

						             select @poaId=POAId,@poadetalleId=Id from inserted; 

                                     select

                                         @consecutivo=MAX(POADetalle.Consecutivo),							  
							             @UnidadPresupuestalClave=UnidadPresupuestal.Clave,
							             @anio=Ejercicio.Año							   

                                     from POADetalle 
                                     inner join POA
                                     on POA.Id=POADetalle.POAId
                                     inner join UnidadPresupuestal
                                     on UnidadPresupuestal.Id=POA.UnidadPresupuestalId
                                     inner join Ejercicio
                                     on Ejercicio.Id=POA.EjercicioId
                                     where POA.Id=@poaId
							         group by POA.Id,UnidadPresupuestal.Clave,Ejercicio.Año
                            
                            set @consecutivo=@consecutivo+1;                                     
							
							set @numeroObra= CAST(@UnidadPresupuestalClave AS varchar(9))  + CAST(@anio AS varchar(4)) + REPLACE(STR(@consecutivo, 3),SPACE(1),'0');

                            update POADetalle set Consecutivo=@consecutivo,Numero=@numeroObra where Id=@poadetalleId";



            contexto.Database.ExecuteSqlCommand(sp001);


            sp001 = @"CREATE TRIGGER trgAsignarNumeroObra_Obra ON [dbo].[Obra] 
                                FOR INSERT
                                AS	                               									 
						             declare @consecutivo int;
						             declare @obraId int;
						             declare @poaDetalleId int;
						             declare @numeroObra varchar(100);

						             select @poaDetalleId=POADetalleId,@obraId=Id from inserted; 

                                     select @consecutivo=Consecutivo,@numeroObra=Numero from POADetalle where Id=@poaDetalleId     
                        
                                update Obra set Consecutivo=@consecutivo,Numero=@numeroObra where Id=@obraId";



            contexto.Database.ExecuteSqlCommand(sp001);           




        } // Triggers






    }
}
