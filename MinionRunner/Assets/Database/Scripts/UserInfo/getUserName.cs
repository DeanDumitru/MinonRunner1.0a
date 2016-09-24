using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getUserName : MonoBehaviour
{

    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;

    
        //input.onEndEdit.AddListener(SubmitName);  // This also works
    }

    private void SubmitName(string arg0)
    {
        Debug.Log(arg0);
    }
}
