using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public interface IDisplayDriver
{
    public void SetMessage(Message message);
    public void ClearDisplay();
    public void ShowMessage();
    public void SetTextColor(ConsoleColor color);
}