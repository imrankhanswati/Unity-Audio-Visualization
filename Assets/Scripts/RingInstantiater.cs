using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingInstantiater : MonoBehaviour {

	public GameObject _ObjectPrefab;


    public bool _EnableChangeColor;
    public Color[] _colors;
    public float GenrateBeatOn = 50;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float beat = AudioManager._samples[3];
        Debug.Log(beat);
        if (beat > GenrateBeatOn)
        {
            InstantiateRing();
        }
	}

    public void InstantiateRing()
    {
        GameObject _ring = Instantiate(_ObjectPrefab);
        _ring.transform.parent = this.transform;
        _ring.transform.position = transform.position;
        if (_EnableChangeColor)
        {
            int _colorNo = Random.Range(0, _colors.Length);
            _ring.GetComponent<SpriteRenderer>().color = _colors[_colorNo];
        }
    }
}
