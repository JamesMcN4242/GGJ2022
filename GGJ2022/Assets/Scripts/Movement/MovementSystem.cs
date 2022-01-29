using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovementSystem
{
    public static void UpdatePlayerInputs(PlayerEntity[] playerEntities)
    {
        foreach (var playerEntity in playerEntities)
        {
            MovementInput(playerEntity.GameObj, playerEntity.PlayerInputs, playerEntity.CharacterData);
            AssignCameraPosition(playerEntity.GameObj, playerEntity.PlayerCamera);
        }
    }

    private static void MovementInput(GameObject player, PlayerInput inputControls, Character character)
    {
        Vector3 movementDirection = Vector3.zero;
        if (Input.GetKey(inputControls.m_rightKey))
        {
            movementDirection.x += 1;
        } else if (Input.GetKey(inputControls.m_leftKey))
        {
            movementDirection.x -= 1;
        }

        if (Input.GetKey(inputControls.m_upKey))
        {
            movementDirection.y += 1;
        } else if (Input.GetKey(inputControls.m_downKey))
        {
            movementDirection.y -= 1;
        }
        
        AssignMovement(player, movementDirection.normalized, character.speed);
    }
    
    public static void AssignMovement(GameObject gameObject1, Vector3 direction, float speed)
    {
        gameObject1.transform.position += direction * Time.deltaTime * speed;
    }
    
    private static void AssignCameraPosition(GameObject playerObj, Camera playerCamera)
    {
        Vector3 cameraOffset = new Vector3(0f, 0f, -10f);
        playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position,
            playerObj.transform.position + cameraOffset, 0.5f);
    }
}
