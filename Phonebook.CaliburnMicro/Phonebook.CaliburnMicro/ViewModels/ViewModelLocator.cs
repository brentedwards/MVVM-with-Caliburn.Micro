using System.ComponentModel;
using System.Windows;

namespace Phonebook.CaliburnMicro.ViewModels
{
	public sealed class ViewModelLocator
	{
		private static bool? isInDesignMode;
		public static bool IsInDesignMode
		{
			get
			{
				if (!isInDesignMode.HasValue)
				{
					var prop = DesignerProperties.IsInDesignModeProperty;
					isInDesignMode
						= (bool)DependencyPropertyDescriptor
									 .FromProperty(prop, typeof(FrameworkElement))
									 .Metadata.DefaultValue;
				}
				return isInDesignMode.Value;
			}
		}

		public AllFriendsViewModel AllFriends
		{
			get
			{
				if (IsInDesignMode)
				{
					return new AllFriendsViewModel(null, null);
				}
				return null;
			}
		}

		public EditPersonViewModel EditPerson
		{
			get
			{
				if (IsInDesignMode)
				{
					return new EditPersonViewModel();
				}
				return null;
			}
		}
	}
}
