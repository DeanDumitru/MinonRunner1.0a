using UnityEngine;
using System.Collections;

public class LoadNext : MonoBehaviour {

    public void Click(string level)
    {
        Application.LoadLevel(level);
    }
}
