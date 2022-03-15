using Autofac;
using ReservationSystem.Data;
using ReservationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationSystem
{
    public static class AutofaqConfig
    {


        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DataContext>().As<IDataContext>();
            builder.RegisterType<ReservationRepository>();

            return builder.Build();
        }
    }
 
}