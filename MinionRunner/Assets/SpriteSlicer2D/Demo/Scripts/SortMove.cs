using UnityEngine;

public class SortMove : MonoBehaviour
{

    public GameObject[] slicedObjects;
    public GameObject SlicedParent;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            slicedObjects = new GameObject[SlicedParent.transform.childCount];
            for (int i = 0; i < SlicedParent.transform.childCount; i++)
            {
                slicedObjects[i] = SlicedParent.transform.GetChild(i).gameObject;
            }




        }
    }
}
