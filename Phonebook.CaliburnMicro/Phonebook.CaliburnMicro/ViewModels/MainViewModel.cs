using Caliburn.Micro;
using Phonebook.CaliburnMicro.Messages;

namespace Phonebook.CaliburnMicro.ViewModels
{
	public sealed class MainViewModel : Conductor<Screen>.Collection.OneActive // TODO: 1.Interfaces
	{
		public MainViewModel(IWindowManager windowManager)
		{
			DisplayName = "Phonebook";

			WindowManager = windowManager;
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();

			Items.Add(IoC.Get<AllFriendsViewModel>());
		}

		// TODO: 2.Handle EditPersonMessage

		// TODO: 3.Handle ViewPersonMessage

		private IWindowManager WindowManager { get; set; }
	}
}
