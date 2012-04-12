using System.Collections.Generic;
using System.ComponentModel;
using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Phonebook.CaliburnMicro.Messages;
using Phonebook.CaliburnMicro.Models;
using Phonebook.CaliburnMicro.Repositories;
using Phonebook.CaliburnMicro.ViewModels;

namespace Phonebook.CaliburnMicro.Tests.ViewModels
{
	[TestClass]
	public class AllFriendsViewModelTests
	{
		private IPersonRepository PersonRepository { get; set; }
		private IEventAggregator EventAggregator { get; set; }
		private AllFriendsViewModel ViewModel { get; set; }

		private List<string> PropertiesChanged { get; set; }
		private void OnPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			PropertiesChanged.Add(args.PropertyName);
		}

		[TestInitialize]
		public void Initialize()
		{
			PropertiesChanged = new List<string>();

			PersonRepository = Substitute.For<IPersonRepository>();
			EventAggregator = Substitute.For<IEventAggregator>();

			ViewModel = new AllFriendsViewModel(PersonRepository, EventAggregator);
		}

		[TestMethod]
		public void Edit()
		{
			// Arrange
			var selectedFriend = new Person();

			ViewModel.SelectedPerson = selectedFriend;

			EditPersonMessage publishedMessage = null;
			EventAggregator.Publish(Arg.Do<EditPersonMessage>(m => publishedMessage = m));

			// Act
			ViewModel.Edit();

			// Assert
			Assert.AreSame(selectedFriend, publishedMessage.Person);
		}

		[TestMethod]
		public void View()
		{
			// Arrange
			var selectedFriend = new Person();

			ViewPersonMessage publishedMessage = null;
			EventAggregator.Publish(Arg.Do<ViewPersonMessage>(m => publishedMessage = m));

			// Act
			ViewModel.View(selectedFriend);

			// Assert
			Assert.AreSame(selectedFriend, publishedMessage.Person);
		}

		[TestMethod]
		public void ViewModelInitialized()
		{
			// Arrange
			var friend = new Person();
			var friends = new List<Person>();
			friends.Add(friend);

			PersonRepository.GetAllFriends().Returns(friends);

			// Act
			((IActivate)ViewModel).Activate();

			// Assert
			Assert.AreSame(friend, ViewModel.Friends[0]);
		}

		[TestMethod]
		public void SelectedPerson()
		{
			// Arrange
			var person = new Person();

			// Act
			ViewModel.PropertyChanged += OnPropertyChanged;
			ViewModel.SelectedPerson = person;
			ViewModel.PropertyChanged -= OnPropertyChanged;

			// Assert
			Assert.AreSame(person, ViewModel.SelectedPerson, "SelectedPerson");
			Assert.IsTrue(PropertiesChanged.Contains("SelectedPerson"), "Property Changed");
		}
	}
}
