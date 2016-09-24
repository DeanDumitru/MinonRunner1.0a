using UnityEngine;
using System.Collections;

public class UIImageRotate : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime * 2);
    }
}
