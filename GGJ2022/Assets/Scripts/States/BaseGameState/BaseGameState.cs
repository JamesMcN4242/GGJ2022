using PersonalFramework;
using UnityEngine;

public class BaseGameState : FlowStateBase
{
    private PlayerEntity[] m_players = null;

    protected override void StartPresentingState()
    {
        GameObject mainCam = GameObject.Find("Main Camera");
        
        var objects = SpawnSystem.SpawnAllFindableEntities();
        m_players = new PlayerEntity[2]
        {
            PlayerEntity.CreatePlayerEntity(objects[0], 1),
            PlayerEntity.CreatePlayerEntity(objects[1], 2)
        };
        
        mainCam.SetActive(false);
    }
    
    protected override void UpdateActiveState()
    {
        base.UpdateActiveState();
        MovementSystem.UpdatePlayerInputs(m_players);
    }
}
