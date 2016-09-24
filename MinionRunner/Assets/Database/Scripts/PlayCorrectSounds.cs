using UnityEngine;
using System.Collections;

public class PlayCorrectSounds : MonoBehaviour {

	void Awake()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
	
}
