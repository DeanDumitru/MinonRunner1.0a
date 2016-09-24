using UnityEngine;
using System.Collections;

public class detectClick : MonoBehaviour {

    public GameObject TextToHide;
    public GameObject TextToShow;
    public GameObject Player;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TextToHide.SetActive(false);
            TextToShow.SetActive(true);
        }
    }
}
