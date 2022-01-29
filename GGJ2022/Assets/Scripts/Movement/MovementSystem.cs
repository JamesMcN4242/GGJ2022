using System.Collections;
using System.Collections.Generic;
using PersonalFramework;
using UnityEngine;

using static LadderMovementSystem;

public static class MovementSystem
{
    public static void UpdatePlayerInputs(PlayerEntity[] playerEntities)
    {
        foreach (var playerEntity in playerEntities)
        {
            if (WorldFlags.PlayersOnLadders.Contains(playerEntity.gameObject.name))
            {
                LadderMovement(playerEntity.gameObject, playerEntity.PlayerInputs, playerEntity.CharacterData);
            }
            else
            {
                MovementInput(playerEntity.gameObject, playerEntity.PlayerInputs, playerEntity.CharacterData);
            }

            if (playerEntity.Ability == "Shoot")
            {
                SpecialAbilityInput(playerEntity.gameObject, playerEntity.PlayerInputs, playerEntity.CharacterData);
            }
            AssignCameraPosition(playerEntity.gameObject, playerEntity.PlayerCamera);
        }
    }

    private static void MovementInput(GameObject player, PlayerInput inputControls, Character character)
    {
        Vector3 movementDirection = Vector3.zero;
        var playerEntity = player.GetComponent<PlayerEntity>();
        var doubleJump = playerEntity.Ability == "DoubleJump";
        if (Input.GetKey(inputControls.m_rightKey))
        {
            player.GetComponentInChildren<SpriteRenderer>().flipX = true;
            if (player.name.EndsWith("2(Clone)"))
            {
                player.GetComponentInChildren<MeshRenderer>().transform.localPosition = new Vector3(-1.12f, -0.79f, -0.03649405f);
            }
            movementDirection.x += 1;
        } else if (Input.GetKey(inputControls.m_leftKey))
        {
            movementDirection.x -= 1;
            // player.GetComponent<Rigidbody>().-1.12
            player.GetComponentInChildren<SpriteRenderer>().flipX = false;
            if (player.name.EndsWith("2(Clone)"))
            {
                player.GetComponentInChildren<MeshRenderer>().transform.localPosition = new Vector3(1.076107f, -0.79f, -0.03649405f);
            }
        }
        

        if (Input.GetKeyDown(inputControls.m_upKey) )
        {

            RaycastHit hit = default;
            bool onGround = Physics.Raycast(player.transform.position, Vector3.down, out hit, 0.8f,
                LayerMask.GetMask("Ground"));
            Debug.Log("onGround: " + onGround);

            if (onGround && doubleJump) playerEntity.actionCounter = 0;
            
            if (onGround || doubleJump && playerEntity.actionCounter < 2)
            {
                playerEntity.actionCounter++;
                player.GetComponent<Rigidbody>().AddForce(new Vector3(0f, character.jumpHeight, 0f));
            }

        } else if (Input.GetKey(inputControls.m_downKey))
        {
            movementDirection.y -= 1;
        }

        AssignMovement(player, movementDirection.normalized, character.speed);
    }

    private static void SpecialAbilityInput(GameObject player, PlayerInput inputControls, Character character)
    {
        if (Input.GetKeyDown(inputControls.m_shootingKey))
        {
            var spawnLocation = player.FindChildByName("Weapon").transform.position;
            GameObject projectile = Object.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Projectile"), spawnLocation, Quaternion.identity);
            projectile.GetComponent<ProjectileController>().playerDirection = player.FindChildByName("Weapon").transform.localPosition.x > 0 ? Vector3.left : Vector3.right;
        }
    }
    
    
    public static void AssignMovement(GameObject gameObject1, Vector3 direction, float speed)
    {
        gameObject1.transform.position += direction * (Time.deltaTime * speed);
    }
    
    private static void AssignCameraPosition(GameObject playerObj, Camera playerCamera)
    {
        Vector3 cameraOffset = new Vector3(0f, 4f, -30f);
        playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position,
            playerObj.transform.position + cameraOffset, 0.5f);
    }
}
