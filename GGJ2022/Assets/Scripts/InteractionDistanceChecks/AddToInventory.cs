using System.Collections;
using System.Collections.Generic;
using PersonalFramework;
using UnityEngine;

public class AddToInventory : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !gameObject.name.Contains("crushed"))
        {
            Debug.Log("Object with name {other.name} entered the trigger");
            var player = other.GetComponentInParent<PlayerEntity>();
            player.Inventory.Add(gameObject.name);
            Object.Destroy(gameObject);
        } else if (gameObject.name.Contains("crushed bone") && other.name.Contains("Player_1") ||
                   gameObject.name.Contains("crushed flower") && other.name.Contains("Player_2"))
        {
            var player = other.GetComponentInParent<PlayerEntity>();
            player.Inventory.Add(gameObject.name);
            Object.Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Object with name {other.name} left the trigger");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Object with name {other.name} stayed in the trigger");
        }
    }
}
