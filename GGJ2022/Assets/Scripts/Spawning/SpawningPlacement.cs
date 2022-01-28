using UnityEngine;

public class SpawningPlacement : MonoBehaviour
{
    public enum SpawnType
    {
        PLAYER,
        PORTAL,
        ITEM
    }

    [SerializeField] private SpawnType m_spawnType;
    [SerializeField] private int m_specificInformation;

    public SpawnType Type => m_spawnType;
    public int SpecificInformation => m_specificInformation;

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
