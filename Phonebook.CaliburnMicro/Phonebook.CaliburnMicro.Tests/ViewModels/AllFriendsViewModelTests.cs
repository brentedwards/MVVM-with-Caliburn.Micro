using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phonebook.CaliburnMicro.Repositories;

namespace Phonebook.CaliburnMicro.Tests.ViewModels
{
	[TestClass]
	public class AllFriendsViewModelTests
	{
		private IPersonRepository PersonRepository { get; set; }
		private IEventAggregator EventAggregator { get; set; }

		[TestInitialize]
		public void Initialize()
		{

		}

		[TestMethod]
		public void TestMethod1()
		{
		}
	}
}
