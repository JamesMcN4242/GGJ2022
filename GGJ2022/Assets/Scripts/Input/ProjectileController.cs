using System;
using UnityEngine;
public class ProjectileController: MonoBehaviour
{
    public Vector3 playerDirection = Vector3.left;

    private void Start()
    {
        AudioQuickFire.PlayAudioClip("Audio/pewpew");
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
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
    
    