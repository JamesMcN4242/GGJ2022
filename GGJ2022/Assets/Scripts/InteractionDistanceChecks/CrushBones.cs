using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushBones : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Object with name {other.name} entered the trigger");
            // gameObject TODO: add gameObject to inventory
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
            Debug.Log("Object with name {other.name} y-axis: " + other.gameObject.transform.position.y);
            Debug.Log("current game object name: { gameObject.name} y-axis" + gameObject.transform.position.y);
            //TODO compare y-axis of other and gameObject, to be crushed the y-axis of other has
            //to fullfill criteria(like being 2m away, being in the air and 0.1m away being on top), this has to be
            //done eg 3 times so that bone gets crushed and new mesh gets spawend
        }
    }
}