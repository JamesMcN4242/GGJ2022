using UnityEngine;

public static class AudioQuickFire
{
    private static readonly GameObject k_audioPrefab = Resources.Load<GameObject>("Prefabs/AudioQuickFire");
    
    public static void PlayAudioClip(string audioName)
    {
        GameObject newObj = Object.Instantiate(k_audioPrefab);
        var source = newObj.GetComponent<AudioSource>();
        source.clip = Resources.Load<AudioClip>(audioName);
        if (audioName.EndsWith("pewpew"))
        {
            source.pitch = Random.Range(1f, 3f);
            source.time = 1.2f;
        }

        source.Play();
        Object.Destroy(newObj, source.clip.length + 0.1f);
    }
}
