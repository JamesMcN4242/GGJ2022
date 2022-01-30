using UnityEngine;

public static class EnemySystem
{
   public static void UpdateEntities(EnemyEntity[] entities)
   {
      foreach (var enemy in entities)
      {
         if (enemy.m_gameObject == null || enemy.m_enemyData.m_maxXRangeMovement == 0f) continue;
         
         Vector3 dir = enemy.m_movingLeft ? Vector3.left : Vector3.right;
         MovementSystem.AssignMovement(enemy.m_gameObject, dir, enemy.m_enemyData.m_speed);

         float xPos = enemy.m_gameObject.transform.position.x;
         if ((enemy.m_movingLeft && enemy.k_originPosition.x - enemy.m_enemyData.m_maxXRangeMovement > xPos) || 
             (!enemy.m_movingLeft && enemy.k_originPosition.x + enemy.m_enemyData.m_maxXRangeMovement < xPos))
         {
            enemy.m_movingLeft = !enemy.m_movingLeft;
         }
      }
   }
}