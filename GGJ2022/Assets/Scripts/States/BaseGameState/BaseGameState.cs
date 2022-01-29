using System;
using PersonalFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseGameState : FlowStateBase
{
    private PlayerEntity[] m_players = null;
    private EnemyEntity[] m_enemies = null;
    private BaseGameUI m_stateUI = null;
    private ResetTimer m_resetTimer = new ResetTimer(10f);

    protected override bool AquireUIFromScene()
    {
        GameObject uiPrefab = Resources.Load<GameObject>("Prefabs/BaseGameUI");
        GameObject instance = GameObject.Instantiate(uiPrefab);
        m_ui = m_stateUI = instance.GetComponent<BaseGameUI>();
        return m_ui != null;
    }

    protected override void StartPresentingState()
    {
        GameObject mainCam = GameObject.Find("Main Camera");
        
        var objects = SpawnSystem.SpawnAllFindableEntities();
        var playerObjects = Array.FindAll(objects, input => input.tag == "Player");
        m_players = new PlayerEntity[]
        {
            PlayerEntity.CreatePlayerEntity(playerObjects[(1 + WorldFlags.ResetValue) % 2], 1),
            PlayerEntity.CreatePlayerEntity(playerObjects[WorldFlags.ResetValue % 2], 2)
        };

        var enemies = Array.FindAll(objects, o => o.GetComponent<CombatInteraction>() != null);
        m_enemies = Array.ConvertAll(enemies,
            input => new EnemyEntity(input, Resources.Load<EnemyData>($"Data/enemyData/Enemy{input.name[5]}")));

        mainCam.SetActive(false);
    }
    
    protected override void UpdateActiveState()
    {
        MovementSystem.UpdatePlayerInputs(m_players);
        EnemySystem.UpdateEntities(m_enemies);
        m_resetTimer.UpdateTime(Time.deltaTime);

        if (WorldFlags.PlayerDead || !m_resetTimer.HasTimeLeft)
        {
            ResetLevel();
        }
    }

    protected override void FixedUpdateActiveState()
    {
        m_stateUI.UpdateTimerFill(m_resetTimer.PortionRemaining);
    }

    private void ResetLevel()
    {
        //TODO: Reset level
        WorldFlags.PlayerDead = false;
        WorldFlags.ResetValue++;
        Debug.Log("OHH NO. THEY'RE DEAD.... Or out of time I guess. Either way let's reset!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
