using TaleWorlds.Library;

namespace AIInfluence.UI;

public class ChatMessageItemVM : ViewModel
{
	private string _senderName;
	private string _messageText;
	private bool _isNpcMessage;

	[DataSourceProperty]
	public string SenderName
	{
		get => _senderName;
		set { if (value != _senderName) { _senderName = value; OnPropertyChangedWithValue(value); } }
	}

	[DataSourceProperty]
	public string MessageText
	{
		get => _messageText;
		set { if (value != _messageText) { _messageText = value; OnPropertyChangedWithValue(value); } }
	}

	[DataSourceProperty]
	public bool IsNpcMessage
	{
		get => _isNpcMessage;
		set { if (value != _isNpcMessage) { _isNpcMessage = value; OnPropertyChangedWithValue(value); OnPropertyChanged("IsPlayerMessage"); } }
	}

	[DataSourceProperty]
	public bool IsPlayerMessage => !_isNpcMessage;

	public ChatMessageItemVM(string senderName, string messageText, bool isNpcMessage)
	{
		_senderName = senderName;
		_messageText = messageText;
		_isNpcMessage = isNpcMessage;
	}
}
