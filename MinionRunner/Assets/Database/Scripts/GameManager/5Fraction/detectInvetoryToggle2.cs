using UnityEngine;
using System.Collections;

public class detectInvetoryToggle2 : MonoBehaviour
{
    public GameObject oldText;
    public GameObject oldBackgroud;
    public GameObject newText;
    public GameObject newBackground;

    // Update is called once per frame
    void Update()
    {
        if (InventoryGUI2.InventoryStatus() || Input.GetKeyDown(KeyCode.I))
        {
            oldText.SetActive(false);
            oldBackgroud.SetActive(false);
            newText.SetActive(true);
            newBackground.SetActive(true);
        }
	}
}
