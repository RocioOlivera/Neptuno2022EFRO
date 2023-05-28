using Autofac;
using Neptuno2022EF.Datos;
using Neptuno2022EF.Datos.Interfaces;
using Neptuno2022EF.Datos.Repositorios;
using Neptuno2022EF.Servicios.Interfaces;
using Neptuno2022EF.Servicios.Servicios;

namespace Neptuno2022EF.Di
{
    public class Bootstrapper
    {
        public IContainer Boostrap()
        {
            var builder=new ContainerBuilder();
            builder.RegisterType<NeptunoDbContext>().AsSelf();
            builder.RegisterType<RepositorioPaises>().As<IRepositorioPaises>();
            builder.RegisterType<ServiciosPaises>().As<IServiciosPaises>();

            builder.RegisterType<RepositorioCiudades>().As<IRepositorioCiudades>();
            builder.RegisterType<ServiciosCiudades>().As<IServiciosCiudades>();

            return builder.Build();
        }
    }
}
