using PersonalFramework;
using UnityEngine;

public class DialogueState : FlowStateBase
{
    private DialogueUI m_dialogueUI;
    private string m_message;

    public DialogueState(string textToDisplay)
    {
        m_message = textToDisplay;
    }

    protected override bool AquireUIFromScene()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/DialogueStateUI");
        m_ui = m_dialogueUI = Object.Instantiate(prefab).GetComponent<DialogueUI>();
        return m_ui != null;
    }

    protected override void StartPresentingState()
    {
        m_dialogueUI.UpdateText(m_message);
    }

    protected override void UpdateActiveState()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ControllingStateStack.PopState(this);
        }
    }
}