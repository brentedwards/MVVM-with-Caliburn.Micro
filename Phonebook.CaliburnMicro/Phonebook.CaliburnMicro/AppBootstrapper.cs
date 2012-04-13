using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Caliburn.Micro;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Phonebook.CaliburnMicro.Repositories;
using Phonebook.CaliburnMicro.ViewModels;

namespace Phonebook.CaliburnMicro
{
	public class AppBootstrapper : Bootstrapper<MainViewModel>
	{
		private IWindsorContainer Container { get; set; }
		private IEventAggregator EventAggregator { get; set; }

		protected override void Configure()
		{
			EventAggregator = new EventAggregator();
			Container = new WindsorContainer();

			Container.Register(
				AllTypes.FromAssembly(typeof(AppBootstrapper).Assembly)
					.Where(x => x.Namespace.Contains("ViewModels"))
					.Configure(x => x.LifeStyle.Is(LifestyleType.Transient)),

				Component.For<IPersonRepository>().ImplementedBy<PersonRepository>(),
				Component.For<IWindowManager>().ImplementedBy<WindowManager>(),
				Component.For<IEventAggregator>().Instance(EventAggregator));
		}

		protected override object GetInstance(Type serviceType, string key)
		{
			var instance = string.IsNullOrWhiteSpace(key)
					? Container.Resolve(serviceType)
					: Container.Resolve(key, serviceType);

			// TODO: 6.GetInstance - Auto Subscribe

			return instance;
		}

		protected override IEnumerable<object> GetAllInstances(Type serviceType)
		{
			var instances = (IEnumerable<object>)Container.ResolveAll(serviceType);
			// TODO: 7.GetAllInstances - Auto Subscribe

			return instances;
		}

		protected override void BuildUp(object instance)
		{
			instance.GetType().GetProperties()
				.Where(property => property.CanWrite && property.PropertyType.IsPublic)
				.Where(property => Container.Kernel.HasComponent(property.PropertyType))
				.ToList()
				.ForEach(property => property.SetValue(instance, Container.Resolve(property.PropertyType), null));
		}

		protected override IEnumerable<Assembly> SelectAssemblies()
		{
			return AssemblySource.Instance.Any() ?
				new Assembly[] { } :
				new[] { typeof(AppBootstrapper).Assembly };
		}
	}
}
