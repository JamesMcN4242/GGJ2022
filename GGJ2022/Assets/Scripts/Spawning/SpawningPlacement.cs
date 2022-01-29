using UnityEngine;

public class SpawningPlacement : MonoBehaviour
{
    public enum SpawnType
    {
        PLAYER,
        PORTAL,
        ITEM,
        ENEMY
    }

    private Color[] m_spawnColors = new[]
    {
        Color.green,
        Color.magenta,
        Color.blue,
        Color.red,
    };

    [SerializeField] private SpawnType m_spawnType;
    [SerializeField] private int m_specificInformation;

    public SpawnType Type => m_spawnType;
    public int SpecificInformation => m_specificInformation;

    private void OnDrawGizmos()
    {
        Gizmos.color = m_spawnColors[(int)m_spawnType];
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
