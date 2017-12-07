using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{

    public DancingWalls[] _walls;
    public float BeatValue;
    float frq;
    void Update()
    {
        for (int i = 0; i < _walls.Length; i++)
        {
            frq = AudioManager._samples[_walls[i].frequencySample];
            if (frq > BeatValue)
            {
                _walls[i].OnBeatDance();
            }
            else
            {
                _walls[i].NormalMat();
            }
        }
    }
}

[System.Serializable]
public class DancingWalls
{
    public GameObject wall;
    public Material normalMat;
    public Material onBeatMat;
    [Range(0, 511)]
    public int frequencySample;
    public void OnBeatDance()
    {
        wall.GetComponent<MeshRenderer>().material = onBeatMat;
    }

    public void NormalMat()
    {
        wall.GetComponent<MeshRenderer>().material = normalMat;
    }
}
