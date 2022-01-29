using UnityEngine;

public class EnemyEntity
{
    public EnemyData m_enemyData;
    public GameObject m_gameObject;

    public readonly Vector3 k_originPosition;
    public bool m_movingLeft = false;
    
    public EnemyEntity(GameObject obj, EnemyData data)
    {
        m_gameObject = obj;
        m_enemyData = data;

        k_originPosition = m_gameObject.transform.position;
    }
}