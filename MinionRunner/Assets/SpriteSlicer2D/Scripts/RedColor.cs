using UnityEngine;
using System.Collections;

public class RedColor : MonoBehaviour {

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
         
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
           

        }
    }
}
