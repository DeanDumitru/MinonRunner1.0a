using UnityEngine;
using System.Collections;

public class DeactivateTimer : MonoBehaviour {

    public GameObject timer;
    int FinalFraction = 3;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (FractionManager.score == FinalFraction)
        {
            timer.SetActive(false);
        }
	}
}
