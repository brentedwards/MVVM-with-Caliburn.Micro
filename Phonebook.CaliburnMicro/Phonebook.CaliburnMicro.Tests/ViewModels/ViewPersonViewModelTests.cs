using System;
using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Phonebook.CaliburnMicro.Models;
using Phonebook.CaliburnMicro.ViewModels;

namespace Phonebook.CaliburnMicro.Tests.ViewModels
{
	[TestClass]
	public class ViewPersonViewModelTests
	{
		[TestMethod]
		public void Close()
		{
			// Arrange
			var conductor = Substitute.For<IConductor>();
			var viewModel = new ViewPersonViewModel();
			viewModel.Parent = conductor;

			// Act
			viewModel.Close();

			// Assert
			conductor.Received().CloseItem(viewModel);
		}

		[TestMethod]
		public void Person_NotNull()
		{
			// Arrange
			var viewModel = new ViewPersonViewModel();

			var name = Guid.NewGuid().ToString();
			var person = new Person { Name = name };

			// Act
			viewModel.Person = person;

			// Assert
			Assert.AreSame(person, viewModel.Person, "Person");
			Assert.AreEqual(name, viewModel.DisplayName, "DisplayName");
		}

		[TestMethod]
		public void Person_Null()
		{
			// Arrange
			var viewModel = new ViewPersonViewModel();

			// Act
			viewModel.Person = null;

			// Assert
			Assert.IsNull(viewModel.Person, "Person");
			Assert.AreEqual(string.Empty, viewModel.DisplayName, "DisplayName");
		}
	}
}
