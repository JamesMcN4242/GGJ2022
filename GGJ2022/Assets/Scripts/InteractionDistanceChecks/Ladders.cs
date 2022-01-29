using UnityEngine;

public class Ladders : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            WorldFlags.PlayersOnLadders.Add(other.name);
            other.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            WorldFlags.PlayersOnLadders.Remove(other.name);
            other.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}