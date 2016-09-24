using UnityEngine;
using System.Collections;

public class showJumpText : MonoBehaviour
{

    public GameObject TextToShow;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TextToShow.SetActive(true);
        }
    }
}
