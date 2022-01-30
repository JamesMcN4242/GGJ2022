using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushBones : MonoBehaviour
{
    public int jumpedOnCounter = 0;
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
            var player = other.GetComponentInParent<PlayerEntity>();
            Debug.Log( "player position y" + other.transform.position.y);
            Debug.Log( "player localPosition y" + gameObject.transform.localPosition.y);
            if ((other.transform.position.y - gameObject.transform.position.y) > 0.6f)
            {
                jumpedOnCounter++;
            } else if (jumpedOnCounter >= 3)
            {
                jumpedOnCounter = 0;
                var crushedItemPosition = gameObject.transform.position;
                var spawnLocation = new Vector3(crushedItemPosition.x, crushedItemPosition.y + 1f, crushedItemPosition.z);
                var gameObjectName = gameObject.name;
                Destroy(gameObject);
                if (gameObjectName.Contains("bone"))
                {
                    Object.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/crushed bones"), spawnLocation, Quaternion.identity);
                } else if (gameObjectName.Contains("flower"))
                {
                    Object.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/crushed flower"), spawnLocation, Quaternion.identity);
                }
            }
            //staying player: 0.184
            //bone 0.30 y-axis position
        }
    }
}