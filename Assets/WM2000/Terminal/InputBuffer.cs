public class InputBuffer  // InputBuffer is exactly that, limits the amount of characters that can be processed by input
{
    string currentInputLine; // todo private

    public delegate void OnCommandSentHandler(string command);
    public event OnCommandSentHandler onCommandSent;

    public void ReceiveFrameInput(string input)
    {
        foreach (char c in input)
        {
            UpdateCurrentInputLine(c);
        }
    }

    public string GetCurrentInputLine()
    {
        return currentInputLine;
        // unless password
    }

    private void UpdateCurrentInputLine(char c)
    {
        if (c == '\b')
        {
            DeleteCharacters();
        }
        else if (c == '\n' || c == '\r')
        {
            SendCommand(currentInputLine); 
        }
        else
        {
            currentInputLine += c;
        }
    }

    private void DeleteCharacters()
    {
        if (currentInputLine.Length > 0)
        {
            currentInputLine = currentInputLine.Remove(currentInputLine.Length - 1);
        }
        else
        {
            // do nothing on delete at start of line
        }
    }
        
    private void SendCommand(string command)
    {
        onCommandSent(command);
        currentInputLine = "";
    } 
}
