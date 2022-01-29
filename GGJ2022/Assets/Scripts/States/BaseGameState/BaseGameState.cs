using System.Collections;
using System.Collections.Generic;
using PersonalFramework;
using UnityEngine;

public class BaseGameState : FlowStateBase
{
    private GameObject player = null;
    private Character character = null;
    private PlayerInput playerInput = null;
    private GameObject player1 = null;
    private Character character1 = null;
    private PlayerInput playerInput1 = null;

    protected override void StartPresentingState()
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
