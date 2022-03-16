using ReservationSystem.Data;
using ReservationSystem.Repositories;
using ReservationSystem.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ReservationSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDataContext, DataContext > ();
            container.RegisterType<ReservationRepository>();
            container.RegisterType<ReservationService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}