using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingDistroyer : MonoBehaviour {

    public void DestroyRing()
    {
        Destroy(this.gameObject);
    }
}
