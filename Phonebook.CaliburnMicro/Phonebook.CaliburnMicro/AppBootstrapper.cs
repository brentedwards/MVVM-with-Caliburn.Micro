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

		protected override void Configure()
		{
			Container = new WindsorContainer();

			Container.Register(
				AllTypes.FromAssembly(typeof(AppBootstrapper).Assembly)
					.Where(x => x.Namespace.Contains("ViewModels"))
					.Configure(x => x.LifeStyle.Is(LifestyleType.Transient)),

				Component.For<IPersonRepository>().ImplementedBy<PersonRepository>(),
				Component.For<IWindowManager>().ImplementedBy<WindowManager>(),
				Component.For<IEventAggregator>().ImplementedBy<EventAggregator>());
		}

		protected override object GetInstance(Type serviceType, string key)
		{
			return string.IsNullOrWhiteSpace(key)
					? Container.Resolve(serviceType)
					: Container.Resolve(key, serviceType);
		}

		protected override IEnumerable<object> GetAllInstances(Type serviceType)
		{
			return (IEnumerable<object>)Container.ResolveAll(serviceType);
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
