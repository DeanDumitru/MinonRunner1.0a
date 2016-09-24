using UnityEngine;
using System.Collections;

public class detectJump : MonoBehaviour
{

    public GameObject TextToHide;
    public GameObject Player;
    


    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TextToHide.SetActive(false);
    }
}
