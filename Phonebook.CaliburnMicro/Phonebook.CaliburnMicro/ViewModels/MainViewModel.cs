using Caliburn.Micro;
using Phonebook.CaliburnMicro.Messages;

namespace Phonebook.CaliburnMicro.ViewModels
{
	public sealed class MainViewModel : Conductor<Screen>.Collection.OneActive,
		IHandle<EditPersonMessage>,
		IHandle<ViewPersonMessage>
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

		public void Handle(EditPersonMessage message)
		{
			var editPersonViewModel = IoC.Get<EditPersonViewModel>();
			editPersonViewModel.Person = message.Person;

			WindowManager.ShowDialog(editPersonViewModel);
		}

		public void Handle(ViewPersonMessage message)
		{
			var viewPersonViewModel = IoC.Get<ViewPersonViewModel>();
			viewPersonViewModel.Person = message.Person;

			Items.Add(viewPersonViewModel);

			ActivateItem(viewPersonViewModel);
		}

		private IWindowManager WindowManager { get; set; }
	}
}
