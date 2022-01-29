using UnityEngine;

public class CombatInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //TODO: Create a better enemy destruction test
            if (other.transform.position.y > transform.position.y)
            {
                //TODO: Particle effect on death
                Object.Destroy(gameObject);
            }
            else
            {
                // It's not above so it's probably a side hit. So we should kill our player.
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                other.transform.Rotate((other.transform.position - transform.position).normalized, 45.0f, Space.World);
                WorldFlags.PlayerDead = true;
            }
        }
    }
}
