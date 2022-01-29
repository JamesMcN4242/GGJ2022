using PersonalFramework;
using UnityEngine;

public class MenuDirector : LocalDirector
{
    private void Awake()
    {
        m_stateController.PushState(new MenuState());
    }
}
