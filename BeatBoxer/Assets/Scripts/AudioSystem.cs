using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] Clips;
    private AudioClip lastClip;

    public float Volume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(RandomClip());
    }

    // Update is called once per frame
    void Update()
    {
        AudioClip newClip = Clips[Random.Range(0, Clips.Length - 1)];
    }

    AudioClip RandomClip()
    {
        int attempts = 3;
        AudioClip newClip = Clips[Random.Range(0, Clips.Length - 1)];

        while (newClip == lastClip && attempts > 0)
        {
            newClip = Clips[Random.Range(0, Clips.Length - 1)];
            attempts--;
        }

        lastClip = newClip;
        return newClip;
    }
}
