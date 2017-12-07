using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioChanger : MonoBehaviour {
    public static AudioChanger Instance;
    AudioSource audioSource;

    public AudioClip[] clips;
	void Start () {
        Instance = this;
        audioSource = this.GetComponent<AudioSource>();
	}

    public void ChangeTheClip(int clipNo)
    {
        audioSource.Stop();
        audioSource.clip = clips[clipNo];
        audioSource.Play();
    }
}
