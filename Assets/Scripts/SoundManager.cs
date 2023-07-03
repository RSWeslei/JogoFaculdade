using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private Dictionary<Sound, AudioClip> sounds;
    [SerializeField] private AudioSource audioSource;

    public enum Sound
    {
        Interact,
        Typing,
        OpenDoor,
        Paper
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        InitializeSounds();
    }

    public void PlaySound(Sound sound)
    {
        audioSource.PlayOneShot(sounds[sound]);
    }
    
    public void StopSound()
    {
        audioSource.Stop();
    }

    private void InitializeSounds()
    {
        sounds = new Dictionary<Sound, AudioClip>();
        foreach (Sound sound in Enum.GetValues(typeof(Sound)))
        {
            AudioClip audioClip = Resources.Load("Sounds/" + sound) as AudioClip;
            if (audioClip != null)
            {
                sounds.Add(sound, audioClip);
            }
            else
            {
                Debug.LogWarning("Sound not found: " + sound);
            }
        }
    }
}