using UnityEngine;

public class Ladders : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            WorldFlags.PlayersOnLadders.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            WorldFlags.PlayersOnLadders.Remove(other.gameObject);
        }
    }
}