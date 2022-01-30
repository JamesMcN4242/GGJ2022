using System.Collections.Generic;
using PersonalFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueState : FlowStateBase
{
    private DialogueUI m_dialogueUI;
    private Queue<string> m_messages;

    public DialogueState(Queue<string> textToDisplay)
    {
        m_messages = textToDisplay;
    }

    protected override bool AquireUIFromScene()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/DialogueStateUI");
        m_ui = m_dialogueUI = Object.Instantiate(prefab).GetComponent<DialogueUI>();
        return m_ui != null;
    }

    protected override void StartPresentingState()
    {
        m_dialogueUI.UpdateText(m_messages.Dequeue());
    }

    protected override void UpdateActiveState()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (m_messages.Count > 0)
            {
                m_dialogueUI.UpdateText(m_messages.Dequeue());
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}