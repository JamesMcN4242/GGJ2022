using System;
using System.Linq;
using PersonalFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseGameState : FlowStateBase
{
    private PlayerEntity[] m_players = null;
    private EnemyEntity[] m_enemies = null;
    private BaseGameUI m_stateUI = null;
    private ResetTimer m_resetTimer = new ResetTimer(300f);
    private PortalSystem m_portalSystem = new PortalSystem();

    private int flowersToCollect = 0;
    private int skullsToCollect = 0;

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
            input => new EnemyEntity(input, Resources.Load<EnemyData>($"Data/enemyData/{input.name.Split('(')[0]}")));

        mainCam.SetActive(false);
        m_stateUI.UpdateCollectableImages();

        var collectables = GameObject.FindObjectsOfType<AddToInventory>();
        flowersToCollect = collectables.Count(i => i.name.Contains("flower"));
        skullsToCollect = collectables.Length - flowersToCollect; 
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
        else if (m_portalSystem.AreBothPlayersIn && WorldFlags.LevelConditionsMet(m_players))
        {
            // Go the next level or finish screen
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            WorldFlags.ResetValue++;
            WorldFlags.LevelIteration++;
            SceneManager.LoadScene(currentScene+1);
        }
    }

    protected override void FixedUpdateActiveState()
    {
        m_stateUI.UpdateTimerFill(m_resetTimer.PortionRemaining);
        m_stateUI.UpdateCollectableText(m_players[0].Inventory.Count, WorldFlags.ResetValue % 2 == 0? skullsToCollect : flowersToCollect, m_players[1].Inventory.Count, WorldFlags.ResetValue % 2 == 0? flowersToCollect:skullsToCollect);
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
