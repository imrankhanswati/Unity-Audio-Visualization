using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FrequencyRanges
{
    NORMAL,
    HEIGH,
    LOW
};
public class RotatingBigCircule : MonoBehaviour {
    FrequencyRanges freuencyRange = FrequencyRanges.NORMAL;
    public rotatingCircule[] rotatingCircules;

    public float lowFrqRange;
    public float HighFrqRange;
    public bool EnableSizeDance;
    public bool EnableColorDance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        for (int i = 0; i < rotatingCircules.Length; i++)
        {
            FrequencyRanges FR = IdentifyFrequency(i);
            if (EnableSizeDance)
            {
                rotatingCircules[i].SizeDance(FR);
            }
            if (EnableColorDance)
            {
                rotatingCircules[i].ColorDance(FR);
            }
        }
	}

    public FrequencyRanges IdentifyFrequency(int circuleNo)
    {
        float freq = AudioManager._samples[rotatingCircules[circuleNo].frequencySample];
        if (freq > HighFrqRange)
        {
            return FrequencyRanges.HEIGH;
        }
        else if (freq < lowFrqRange)
        {
            return FrequencyRanges.LOW;
        }
        else
        {
            return FrequencyRanges.NORMAL;
        }
    }
}

[System.Serializable]
public class rotatingCircule
{
    public SpriteRenderer circule;
    [Range(0,512)]public int frequencySample;
    public Color onNormalFrequencyColor;
    public Color onLowFrequencyColor;
    public Color onHighFrequencyColor;
    public float onNormalFrequencySize;
    public float onLowFrequencySize;
    public float onHighFrequencySize;

    public void SizeDance(FrequencyRanges FR)
    {
        switch (FR)
        { 
            case FrequencyRanges.HEIGH:
                circule.gameObject.transform.localScale = new Vector3(onHighFrequencySize, onHighFrequencySize, 0);
                break;
            case FrequencyRanges.LOW:
                circule.gameObject.transform.localScale = new Vector3(onLowFrequencySize, onLowFrequencySize, 0);
                break;
            default:
                circule.gameObject.transform.localScale = new Vector3(onNormalFrequencySize, onNormalFrequencySize, 0);
                break;
        }
    }

    public void ColorDance(FrequencyRanges FR)
    {
        switch (FR)
        {
            case FrequencyRanges.HEIGH:
                circule.color = onHighFrequencyColor;
                break;
            case FrequencyRanges.LOW:
                circule.color = onLowFrequencyColor;
                break;
            default:
                circule.color = onNormalFrequencyColor;
                break;
        }
    }
}
