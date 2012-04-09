using System.Collections.Generic;
using System.ComponentModel;
using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Phonebook.CaliburnMicro.Models;
using Phonebook.CaliburnMicro.ViewModels;

namespace Phonebook.CaliburnMicro.Tests.ViewModels
{
	[TestClass]
	public class EditPersonViewModelTests
	{
		private EditPersonViewModel ViewModel { get; set; }

		private List<string> PropertiesChanged { get; set; }
		private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			PropertiesChanged.Add(args.PropertyName);
		}

		[TestInitialize]
		public void Initialize()
		{
			PropertiesChanged = new List<string>();

			ViewModel = new EditPersonViewModel();
		}

		[TestMethod]
		public void Close()
		{
			// Arrange
			var conductor = Substitute.For<IConductor>();
			ViewModel.Parent = conductor;

			// Act
			ViewModel.Close();

			// Assert
			conductor.Received().CloseItem(Arg.Is<EditPersonViewModel>(ViewModel));
		}

		[TestMethod]
		public void Person_NotNull()
		{
			// Arrange
			var person = new Person { Name = "Bob" };

			// Act
			ViewModel.PropertyChanged += OnPropertyChanged;
			ViewModel.Person = person;
			ViewModel.PropertyChanged -= OnPropertyChanged;

			// Assert
			Assert.AreSame(person, ViewModel.Person, "Person");
			Assert.IsTrue(PropertiesChanged.Contains("Person"), "Property Changed");
			Assert.AreEqual("Edit Bob", ViewModel.DisplayName, "DisplayName");
		}

		[TestMethod]
		public void Person_Null()
		{
			// Arrange

			// Act
			ViewModel.PropertyChanged += OnPropertyChanged;
			ViewModel.Person = null;
			ViewModel.PropertyChanged -= OnPropertyChanged;

			// Assert
			Assert.IsNull(ViewModel.Person, "Person");
			Assert.IsTrue(PropertiesChanged.Contains("Person"), "Property Changed");
			Assert.AreEqual(EditPersonViewModel.EditPerson, ViewModel.DisplayName, "DisplayName");
		}
	}
}
