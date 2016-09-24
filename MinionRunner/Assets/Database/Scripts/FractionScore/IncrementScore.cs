using UnityEngine;
using System.Collections;

public class IncrementScore : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        ScoreManager.score += 100;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
