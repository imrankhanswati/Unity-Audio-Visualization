using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongsSelectUIController : MonoBehaviour 
{
    public void PlaySong(int songNo)
    {
        AudioChanger.Instance.ChangeTheClip(songNo);
    }
}
