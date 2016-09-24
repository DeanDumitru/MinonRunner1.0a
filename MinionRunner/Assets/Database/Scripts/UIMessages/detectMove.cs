using UnityEngine;
using System.Collections;

public class detectMove : MonoBehaviour
{
    public GameObject TextToHide;
    public GameObject[] CollectiblesToShow;



	// Use this for initialization
	void Start ()
    {
        
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            TextToHide.SetActive(false);
            foreach (GameObject i in CollectiblesToShow)
                i.SetActive(true);
        }
    }
}
