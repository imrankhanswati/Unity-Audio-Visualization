using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiater : MonoBehaviour
{

    public GameObject _ObjectPrefab; 
    public GameObject[] _instantiatedObjects;
    public GameObject _halo;
    public Camera camera;
    public Light light;
    public int _ObjectsCount = 512;
    public float _objectAngle;
    public float _objectScaleMantaner;
    public float _circuleRidus = 80;
    public float barXscale = 1;
    public float barZscale = 1;

    public bool PlayInReverse = false;

    public Color _HighestFrequencyColor;
    public Color _TooHighFrequencyColor;
    public Color _HighFrequencyColor;
    public Color _NormalFrequencyColor;
    public Color _LowFrequencyColor;
    public Color _TooLowFrequencyColor;
    public Color _LowestFrequencyColor;


    public bool enableDanacingBars = true;
    public bool enableDanceingCirculs = true;
    public bool enableDanceingHalo = true;
    public bool enableDanceingCamera = true;
    public bool enableDanceingLight = true;

    private float cameraY;
    void Start() {
        _objectAngle=(float)(360f/_ObjectsCount);
        _instantiatedObjects = new GameObject[_ObjectsCount];

        if (enableDanceingCamera)
        {
            cameraY = camera.transform.position.y;
        }
        for (int i = 0; i < _ObjectsCount; i++)
        {
            GameObject _instentaitedObject = Instantiate(_ObjectPrefab);
            _instentaitedObject.transform.parent = this.transform;
            _instentaitedObject.transform.eulerAngles = new Vector3(0, _objectAngle * i, 0);
            _instentaitedObject.transform.position = _instentaitedObject.transform.forward * _circuleRidus;
            _instantiatedObjects[i] = _instentaitedObject;
        }
        
	}

    void Update()
    {
        if (enableDanacingBars)
        {
            this.DanceThePrefabs();
        }

        if (enableDanceingCirculs)
        {
            this.DanceTheCircule();
        }

        if (enableDanceingHalo)
        {
            this.DanceHalo();
        }

        if (enableDanceingCamera)
        {
            this.DanceCamera();
        }
        if (enableDanceingLight)
        {
            this.DancingLight();
        }
    }

    public void DanceThePrefabs()
    {
        if (PlayInReverse)
        {
            int j=0;
            for (int i = 0; i < _ObjectsCount; i++)
            {
                j = _ObjectsCount - i - 1;
                float _yScale = (AudioManager._samples[i] * _objectScaleMantaner) + 1;
                if (_yScale < 2.0)
                {
                    _instantiatedObjects[j].GetComponent<MeshRenderer>().material.color = _LowestFrequencyColor;
                    _instantiatedObjects[j].transform.localScale = new Vector3(barXscale, _yScale, barZscale);
                }
                else if (_yScale < 6.0)
                {
                    _instantiatedObjects[j].GetComponent<MeshRenderer>().material.color = _TooLowFrequencyColor;
                    _instantiatedObjects[j].transform.localScale = new Vector3(barXscale, _yScale, barZscale);
                }
                else if (_yScale < 9.0)
                {
                    _instantiatedObjects[j].GetComponent<MeshRenderer>().material.color = _LowFrequencyColor;
                    _instantiatedObjects[j].transform.localScale = new Vector3(barXscale, _yScale, barZscale);
                }
                else if (_yScale < 11.0)
                {
                    _instantiatedObjects[j].GetComponent<MeshRenderer>().material.color = _NormalFrequencyColor;
                    _instantiatedObjects[j].transform.localScale = new Vector3(barXscale, _yScale, barZscale);
                }
                else if (_yScale < 15.0)
                {
                    _instantiatedObjects[j].GetComponent<MeshRenderer>().material.color = _HighFrequencyColor;
                    _instantiatedObjects[j].transform.localScale = new Vector3(barXscale, _yScale, barZscale);
                }
                else if (_yScale < 20.0)
                {
                    _instantiatedObjects[j].GetComponent<MeshRenderer>().material.color = _TooHighFrequencyColor;
                    _instantiatedObjects[j].transform.localScale = new Vector3(barXscale, _yScale, barZscale);
                }
                else
                {
                    _instantiatedObjects[j].GetComponent<MeshRenderer>().material.color = _HighestFrequencyColor;
                    _instantiatedObjects[j].transform.localScale = new Vector3(barXscale, _yScale, barZscale);
                }

            }
        }
        else
        {
            for (int i = 0; i < _ObjectsCount; i++)
            {

                float _yScale = (AudioManager._samples[i] * _objectScaleMantaner) + 1;
                if (_yScale < 2.0)
                {
                    _instantiatedObjects[i].GetComponent<MeshRenderer>().material.color = _LowestFrequencyColor;
                    _instantiatedObjects[i].transform.localScale = new Vector3(barXscale, _yScale, barZscale);
                }
                else if (_yScale < 6.0)
                {
                    _instantiatedObjects[i].GetComponent<MeshRenderer>().material.color = _TooLowFrequencyColor;
                    _instantiatedObjects[i].transform.localScale = new Vector3(barXscale, _yScale, barZscale);
                }
                else if (_yScale < 9.0)
                {
                    _instantiatedObjects[i].GetComponent<MeshRenderer>().material.color = _LowFrequencyColor;
                    _instantiatedObjects[i].transform.localScale = new Vector3(barXscale, _yScale, barZscale);
                }
                else if (_yScale < 11.0)
                {
                    _instantiatedObjects[i].GetComponent<MeshRenderer>().material.color = _NormalFrequencyColor;
                    _instantiatedObjects[i].transform.localScale = new Vector3(barXscale, _yScale, barZscale);
                }
                else if (_yScale < 15.0)
                {
                    _instantiatedObjects[i].GetComponent<MeshRenderer>().material.color = _HighFrequencyColor;
                    _instantiatedObjects[i].transform.localScale = new Vector3(barXscale, _yScale, barZscale);
                }
                else if (_yScale < 20.0)
                {
                    _instantiatedObjects[i].GetComponent<MeshRenderer>().material.color = _TooHighFrequencyColor;
                    _instantiatedObjects[i].transform.localScale = new Vector3(barXscale, _yScale, barZscale);
                }
                else
                {
                    _instantiatedObjects[i].GetComponent<MeshRenderer>().material.color = _HighestFrequencyColor;
                    _instantiatedObjects[i].transform.localScale = new Vector3(barXscale, _yScale, barZscale);
                }

            }
        }
    }

    public void DanceTheCircule()
    {
        float _yScaleOfFirstObject = _instantiatedObjects[0].transform.localScale.y;
        if (_yScaleOfFirstObject < 40)
        {
            for (int i = 0; i < _ObjectsCount; i++)
            {
                _instantiatedObjects[i].transform.position = _instantiatedObjects[i].transform.forward * _circuleRidus;
            }
        }
        else
        {
            if ((_yScaleOfFirstObject - 40) < 10)
            {
                for (int i = 0; i < _ObjectsCount; i++)
                {
                    _instantiatedObjects[i].transform.position = _instantiatedObjects[i].transform.forward * (_circuleRidus + 2);
                }
            }
            else
            {
                for (int i = 0; i < _ObjectsCount; i++)
                {
                    _instantiatedObjects[i].transform.position = _instantiatedObjects[i].transform.forward * (_circuleRidus + 3);
                }
            }
            
        }   
    }

    public void DanceHalo()
    {
        float _yScale = _instantiatedObjects[3].transform.localScale.y;
        _halo.GetComponent<Light>().range = (_yScale * 1.2f);
    }

    public void DanceCamera()
    {
        Vector3 cameraPos=camera.transform.position;
        cameraPos = cameraPos = new Vector3(cameraPos.x, cameraY, cameraPos.z);
        float _yScale = _instantiatedObjects[3].transform.localScale.y;
        if (_yScale > camera.fieldOfView)
        {
            cameraPos = new Vector3(cameraPos.x, cameraPos.y - 10, cameraPos.z);
            camera.transform.position = cameraPos;
            Debug.Log(camera.transform.position);
        }
        else
        {
            cameraPos = new Vector3(cameraPos.x, cameraY, cameraPos.z);
            camera.transform.position = cameraPos;
        }
        
    }

    public void DancingLight()
    {
        float _yScale = _instantiatedObjects[3].transform.localScale.y;
        light.intensity = _yScale * 2;
    }
}
