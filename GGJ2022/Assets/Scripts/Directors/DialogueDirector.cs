using System.Collections.Generic;
using PersonalFramework;
using UnityEngine.SceneManagement;

public class DialogueDirector : LocalDirector
{
    private void Awake()
    {
        Queue<string> messages = new Queue<string>();
        if (SceneManager.GetActiveScene().buildIndex < 3)
        {
            messages.Enqueue(DialogueEntries.entryText);
            messages.Enqueue(DialogueEntries.choiceText);
        }
        else
        {
            messages.Enqueue(DialogueEntries.postText);
        }

        m_stateController.PushState(new DialogueState(messages));
    }
}