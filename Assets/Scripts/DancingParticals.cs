using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingParticals : MonoBehaviour {

    ParticleSystem partcals;
    public float onBeat;
    public int frequencySample;
	void Start () {
        partcals = this.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(onBeat<AudioManager._samples[frequencySample]);
        {
            //partcals.emission.burstCount+=1;
        }
	}
}
