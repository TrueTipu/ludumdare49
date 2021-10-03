using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Invoke("Music", 0.1f);           
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Music()
    {
        FindObjectOfType<AudioManager>().Play("musa");
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Play();
    }
}
