using UnityEngine;
using System.Collections;

public class MenuMusicStop : MonoBehaviour {

	public void StopMusicOnClick()
    {
        MenuMusic.Instance.StopMusic();

    }
}
