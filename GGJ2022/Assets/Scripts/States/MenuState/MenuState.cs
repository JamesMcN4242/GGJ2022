using PersonalFramework;
using UnityEngine;

public class MenuState : FlowStateBase
{
    private MenuUI m_menuUi = null;
    
    protected override bool AquireUIFromScene()
    {
        m_menuUi = Object.FindObjectOfType<MenuUI>();
        m_ui = m_menuUi;
        return m_menuUi != null;
    }
}