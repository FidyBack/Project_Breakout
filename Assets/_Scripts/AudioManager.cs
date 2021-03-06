// https://www.youtube.com/watch?v=6OT43pvUyfY -> Consrução de um AudioManager

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    void Awake() {
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }

    void Start() {
        Play("Backg");
    }

    public void Play (string name) {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null) {
            Debug.Log($"Soundtrack Error: {name}");
            return;
        }
        s.source.Play();
    }
}
