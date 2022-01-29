using UnityEngine;

[CreateAssetMenu(fileName = "enemyData.asset", menuName = "Data/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public Sprite[] m_idleSprites;
    public Sprite[] m_movingSprites;
    public float m_speed;
    public float m_maxXRangeMovement;
}
