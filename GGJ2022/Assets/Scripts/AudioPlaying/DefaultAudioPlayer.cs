using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class DefaultAudioPlayer : MonoBehaviour
{
    private AudioSource source = null;
    private AudioClip[] clips = null;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        clips = Resources.LoadAll<AudioClip>("Audio/music");
    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            source.clip = clips[Random.Range(0, clips.Length)];
            source.Play();
        }
    }


    [RuntimeInitializeOnLoadMethod]
    private static void CreateMusicModule()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/MainMusicLoop");
        Object.DontDestroyOnLoad(Object.Instantiate(prefab));
    }
}
