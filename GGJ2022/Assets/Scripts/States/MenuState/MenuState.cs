using PersonalFramework;
using UnityEngine;

public class MenuState : FlowStateBase
{
    private MenuUI m_menuUi = null;
    private GameObject player = null;
    private Character character = null;
    private PlayerInput playerInput = null;
    private GameObject player1 = null;
    private Character character1 = null;
    private PlayerInput playerInput1 = null;

    
    protected override bool AquireUIFromScene()
    {
        m_menuUi = Object.FindObjectOfType<MenuUI>();
        m_ui = m_menuUi;
        return m_menuUi != null;
    }

    protected override void StartActiveState()
    {
        var objects = SpawnSystem.SpawnAllFindableEntities();
        (player, player1) = (objects[0], objects[1]);
        character1 = character = Resources.Load<Character>("Data/characterInput");
        playerInput = Resources.Load<PlayerInput>("Data/playerOneInput");
        playerInput1 = Resources.Load<PlayerInput>("Data/playerTwoInput");
    }
    
    

    protected override void UpdateActiveState()
    {
        base.UpdateActiveState();
        MovementSystem.MovementInput(player, playerInput, character);
        MovementSystem.MovementInput(player1, playerInput1, character1);
    }
}