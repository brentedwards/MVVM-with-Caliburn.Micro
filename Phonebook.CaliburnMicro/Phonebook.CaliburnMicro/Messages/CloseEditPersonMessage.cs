using Caliburn.Micro;

namespace Phonebook.CaliburnMicro.Messages
{
	public sealed class CloseEditPersonMessage
	{
		public Screen PersonViewModel { get; set; }
	}
}
