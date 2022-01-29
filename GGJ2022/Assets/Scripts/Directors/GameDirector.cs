using PersonalFramework;
using UnityEngine;

public class GameDirector : LocalDirector
{
    private void Awake()
    {
        m_stateController.PushState(new BaseGameState());
    }
}
