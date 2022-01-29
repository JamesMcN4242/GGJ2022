using System;
using PersonalFramework;
using UnityEngine;

public class BaseGameState : FlowStateBase
{
    private PlayerEntity[] m_players = null;
    private EnemyEntity[] m_enemies = null;

    protected override void StartPresentingState()
    {
        GameObject mainCam = GameObject.Find("Main Camera");
        
        var objects = SpawnSystem.SpawnAllFindableEntities();
        var playerObjects = Array.FindAll(objects, input => input.tag == "Player");
        m_players = new PlayerEntity[2]
        {
            PlayerEntity.CreatePlayerEntity(playerObjects[0], 1),
            PlayerEntity.CreatePlayerEntity(playerObjects[1], 2)
        };

        var enemies = Array.FindAll(objects, o => o.GetComponent<CombatInteraction>() != null);
        m_enemies = Array.ConvertAll(enemies,
            input => new EnemyEntity(input, Resources.Load<EnemyData>($"Data/enemyData/Enemy{input.name[5]}")));

        mainCam.SetActive(false);
    }
    
    protected override void UpdateActiveState()
    {
        base.UpdateActiveState();
        MovementSystem.UpdatePlayerInputs(m_players);
        EnemySystem.UpdateEntities(m_enemies);

        if (WorldFlags.PlayerDead)
        {
            //TODO: Reset level
            Debug.Log("OHH NO. THEY'RE DEAD!");
        }
    }
}
