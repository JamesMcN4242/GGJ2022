using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    public bool PlayerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInside |= other.tag == "Player";
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") PlayerInside = false;
    }
}
