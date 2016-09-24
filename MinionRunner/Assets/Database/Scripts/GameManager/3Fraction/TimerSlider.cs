using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerSlider : MonoBehaviour {

    public Slider timeSlider;

    void Start ()
    {
        timeSlider.value = 10.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeSlider.value = Timer.getTimeLeft();
	}
}
