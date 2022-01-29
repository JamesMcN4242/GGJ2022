using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovementSystem
{
    public static void MovementInput(GameObject player, PlayerInput inputControls, Character character)
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
        MovementSystem.AssignMovement(player, movementDirection.normalized, character.speed);
    }
    
    public static void AssignMovement(GameObject gameObject1, Vector3 direction, float speed)
    {
        gameObject1.transform.position += direction * Time.deltaTime * speed;
    }
}
