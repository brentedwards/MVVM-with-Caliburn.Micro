using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Phonebook.CaliburnMicro.Messages;
using Phonebook.CaliburnMicro.Models;
using Phonebook.CaliburnMicro.ViewModels;

namespace Phonebook.CaliburnMicro.Tests.ViewModels
{
	[TestClass]
	public class MainViewModelTests
	{
		private IWindowManager WindowManager { get; set; }

		private MainViewModel ViewModel { get; set; }

		[TestInitialize]
		public void Initialize()
		{
			WindowManager = Substitute.For<IWindowManager>();

			ViewModel = new MainViewModel(WindowManager);
		}

		[TestMethod]
		public void ViewModelInitialized()
		{
			// Arrange
			IoC.GetInstance = (type, key) =>
				{
					return new AllFriendsViewModel(null, null);
				};

			// Act
			((IActivate)ViewModel).Activate();

			// Assert
			Assert.AreEqual(1, ViewModel.Items.Count);
		}

		[TestMethod]
		public void Handle_EditPersonMessage()
		{
			// Arrange
			var editPersonViewModel = new EditPersonViewModel();
			IoC.GetInstance = (type, key) =>
				{
					return editPersonViewModel;
				};

			var person = new Person();
			var message = new EditPersonMessage { Person = person };

			// Act
			ViewModel.Handle(message);

			// Assert
			Assert.AreSame(person, editPersonViewModel.Person);
			WindowManager.Received().ShowDialog(editPersonViewModel);
		}

		[TestMethod]
		public void Handle_ViewPersonMessage()
		{
			// Arrange
			var viewPersonViewModel = new ViewPersonViewModel();
			IoC.GetInstance = (type, key) =>
			{
				return viewPersonViewModel;
			};

			var person = new Person();
			var message = new ViewPersonMessage { Person = person };

			// Act
			ViewModel.Handle(message);

			// Assert
			Assert.AreSame(person, viewPersonViewModel.Person, "Person");
			Assert.AreEqual(1, ViewModel.Items.Count, "Items Count");
		}
	}
}
