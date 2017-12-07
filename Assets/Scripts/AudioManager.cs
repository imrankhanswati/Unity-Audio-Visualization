using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public int _sampleCount = 512;
    public int _bandsCount = 8;

    public static float[] _samples;
    public static float[] _bands;
    public float[] _samplesShow;
    AudioSource _audioSource;
	void Start () {
        _samples = new float[_sampleCount];
        _samplesShow = new float[_sampleCount];
        _bands = new float[_bandsCount];
        _audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        GetAudioSourceSpectrumSamples();
	}

    public void GetAudioSourceSpectrumSamples()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
        _samplesShow = _samples;
    }

    public void MakeBands()
    {

    }
}
