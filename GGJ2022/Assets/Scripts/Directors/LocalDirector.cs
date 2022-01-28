using PersonalFramework;
using UnityEngine;

public class GameDirector : LocalDirector
{
    private void Awake()
    {
        m_stateController.PushState(new MenuState());
    }

    [RuntimeInitializeOnLoadMethod]
    private static void OnInitialised()
    {
        var _ = new GameObject("GameDirector", typeof(GameDirector));
    }
}
