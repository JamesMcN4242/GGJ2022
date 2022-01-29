using UnityEngine;

public static class LadderMovementSystem
{
    public static void LadderMovement(GameObject player, PlayerInput inputControls, Character character)
    {
        Vector3 movementDirection = Vector3.zero;

        if (Input.GetKey(inputControls.m_upKey))
        {
            movementDirection.y = 1f;
        }
        else if (Input.GetKey(inputControls.m_downKey))
        {
            movementDirection.y = -1f;
        }
        
        if (Input.GetKey(inputControls.m_rightKey))
        {
            player.GetComponentInChildren<SpriteRenderer>().flipX = true;
            movementDirection.x += 1;
        } 
        else if (Input.GetKey(inputControls.m_leftKey))
        {
            movementDirection.x -= 1;
            // player.GetComponent<Rigidbody>().
            player.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        
        if(movementDirection.magnitude > 0)
            MovementSystem.AssignMovement(player, movementDirection.normalized, character.speed);
    }
}