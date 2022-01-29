using PersonalFramework;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Debug;

public class MenuState : FlowStateBase
{
    private MenuUI m_menuUi = null;

    protected override bool AquireUIFromScene()
    {
        m_menuUi = Object.FindObjectOfType<MenuUI>();
        m_ui = m_menuUi;
        return m_menuUi != null;
    }

    protected override void HandleMessage(object message)
    {
        switch (message)
        {
            case string msg when msg == "play":
                SceneManager.LoadScene(1);
                break;
            
            default:
                LogError($"Unexpected message type: {message}");
                break;
        }
    }
}