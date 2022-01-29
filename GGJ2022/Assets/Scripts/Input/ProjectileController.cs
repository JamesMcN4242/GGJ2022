using System;
using UnityEngine;
public class ProjectileController: MonoBehaviour
{
    public Vector3 playerDirection = Vector3.left;

    private void Start()
    {
        Destroy(gameObject, 10);
    }

    private void Update()
        {
            transform.position += playerDirection * 3 * Time.deltaTime;
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            
        // Debug.Log("Object with name {other.name} entered the trigger");
        // var enemy = other.GetComponentInParent<PlayerEntity>();
        // player.Inventory.Add(gameObject.name);
        // Object.Destroy(gameObject);
        }
    }
}
    
    