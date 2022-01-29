using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleDistCheck : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object with name {other.name} entered the trigger");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Object with name {other.name} left the trigger");
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Object with name {other.name} stayed in the trigger");
    }
}
