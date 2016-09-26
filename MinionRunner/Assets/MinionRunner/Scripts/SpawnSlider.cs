using UnityEngine;
using System.Collections;

public class SpawnSlider : MonoBehaviour {

    public GameObject[] slider;

    public static SpawnSlider instance;

    public static bool ss = false;
    public void pressedButton()
    {
        if (Panel.playAnimation == true)
        {
 
        }
    }

    void Update()
    {
        if (ss == true)
        {
            Invoke("appear", 2);
            ss = false;
        }
    }

    public void appear()
    {
        for (int i = 2; i >= 0; i--)
        {
            slider[i].gameObject.SetActive(true);
        }
    }
}
