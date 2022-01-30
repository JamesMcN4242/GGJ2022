using UnityEngine;

public static class AudioQuickFire
{
    private static readonly GameObject k_audioPrefab = Resources.Load<GameObject>("Prefabs/AudioQuickFire");
    
    public static void PlayAudioClip(string audioName)
    {
        GameObject newObj = Object.Instantiate(k_audioPrefab);
        var source = newObj.GetComponent<AudioSource>();
        source.clip = Resources.Load<AudioClip>(audioName);
        source.Play();
        Object.Destroy(newObj, source.clip.length + 0.1f);
    }
}
