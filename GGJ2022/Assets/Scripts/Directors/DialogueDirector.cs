using System.Collections.Generic;
using PersonalFramework;

public class DialogueDirector : LocalDirector
{
    private void Awake()
    {
        Queue<string> messages = new Queue<string>();
        messages.Enqueue(DialogueEntries.entryText);
        messages.Enqueue(DialogueEntries.choiceText);
        m_stateController.PushState(new DialogueState(messages));
    }
}