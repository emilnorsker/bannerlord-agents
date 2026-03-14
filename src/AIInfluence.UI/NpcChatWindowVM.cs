using System;
using System.Threading.Tasks;
using TaleWorlds.Library;

namespace AIInfluence.UI;

public class NpcChatWindowVM : ViewModel
{
	private readonly Func<string, Task<string>> _onSendMessage;
	private readonly Action _onLeave;

	private string _npcName;
	private string _npcTitle;
	private string _inputText = "";
	private bool _isWaitingForResponse;
	private MBBindingList<ChatMessageItemVM> _messages;

	[DataSourceProperty]
	public string NpcName
	{
		get => _npcName;
		set { if (value != _npcName) { _npcName = value; OnPropertyChangedWithValue(value); } }
	}

	[DataSourceProperty]
	public string NpcTitle
	{
		get => _npcTitle;
		set { if (value != _npcTitle) { _npcTitle = value; OnPropertyChangedWithValue(value); } }
	}

	[DataSourceProperty]
	public string InputText
	{
		get => _inputText;
		set { if (value != _inputText) { _inputText = value; OnPropertyChangedWithValue(value); OnPropertyChanged("IsSendEnabled"); } }
	}

	[DataSourceProperty]
	public bool IsWaitingForResponse
	{
		get => _isWaitingForResponse;
		set { if (value != _isWaitingForResponse) { _isWaitingForResponse = value; OnPropertyChangedWithValue(value); OnPropertyChanged("IsSendEnabled"); } }
	}

	[DataSourceProperty]
	public bool IsSendEnabled => !_isWaitingForResponse && !string.IsNullOrWhiteSpace(_inputText);

	[DataSourceProperty]
	public MBBindingList<ChatMessageItemVM> Messages
	{
		get => _messages;
		set { if (value != _messages) { _messages = value; OnPropertyChangedWithValue(value); } }
	}

	public NpcChatWindowVM(string npcName, string npcTitle, Func<string, Task<string>> onSendMessage, Action onLeave)
	{
		_npcName = npcName;
		_npcTitle = npcTitle;
		_onSendMessage = onSendMessage;
		_onLeave = onLeave;
		_messages = new MBBindingList<ChatMessageItemVM>();
	}

	public void AddMessage(string senderName, string text, bool isNpc)
	{
		Messages.Add(new ChatMessageItemVM(senderName, text, isNpc));
	}

	public async void ExecuteSendMessage()
	{
		if (!IsSendEnabled) return;
		string playerInput = InputText.Trim();
		InputText = "";
		AddMessage("You", playerInput, isNpc: false);
		IsWaitingForResponse = true;
		try
		{
			string response = await _onSendMessage(playerInput);
			if (!string.IsNullOrEmpty(response))
				AddMessage(NpcName, response, isNpc: true);
		}
		finally
		{
			IsWaitingForResponse = false;
		}
	}

	public void ExecuteLeave()
	{
		_onLeave?.Invoke();
	}
}
