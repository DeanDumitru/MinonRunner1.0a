using UnityEngine;
using System.Collections;

public class SliderNew : MonoBehaviour {


    public Transform knob;
    public Vector3 targetPos;

	void Start () {
        targetPos = knob.position;
	}
	
	void Update () {
        knob.position = Vector3.Lerp(knob.position, targetPos, Time.deltaTime * 7);
	}

    void OnTouchStay(Vector3 point)
    {
        targetPos = new Vector3(point.x, targetPos.y, targetPos.z);
    }
}
