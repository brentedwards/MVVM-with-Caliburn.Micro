using System.Windows;

namespace Phonebook.CaliburnMicro
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			var bootstrapper = new AppBootstrapper();
		}
	}
}
