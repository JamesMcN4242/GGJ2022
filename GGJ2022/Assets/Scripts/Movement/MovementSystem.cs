using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovementSystem
{
    public static void UpdatePlayerInputs(PlayerEntity[] playerEntities)
    {
        foreach (var playerEntity in playerEntities)
        {
            MovementInput(playerEntity.gameObject, playerEntity.PlayerInputs, playerEntity.CharacterData);
            AssignCameraPosition(playerEntity.gameObject, playerEntity.PlayerCamera);
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

        if (Input.GetKeyDown(inputControls.m_upKey) )
        {
            var playerEntity = player.GetComponent<PlayerEntity>();
            Debug.Log($"player ability: {playerEntity.Ability}");

            RaycastHit hit = default;
            //TODO actioncounter + 1 wenn firstjump, acioncounter == 1 then actioncounter is set to 0
            //if any other key is pressed than actioncounter is resetted
            if (playerEntity.Ability == "DoubleJump" && playerEntity.actionCounter < 2 ||
                Physics.Raycast(player.transform.position, Vector3.down, out hit, 1f, LayerMask.GetMask("Ground")))
            {
                if (hit.collider != null)
                {
                    Debug.Log($"----hit: {hit}");
                }
                if (playerEntity.Ability == "DoubleJump")
                {
                    playerEntity.actionCounter++;
                }
                player.GetComponent<Rigidbody>().AddForce(new Vector3(0f, character.jumpHeight, 0f));
            }
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
        Vector3 cameraOffset = new Vector3(0f, 0f, -20f);
        playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position,
            playerObj.transform.position + cameraOffset, 0.5f);
    }
}
