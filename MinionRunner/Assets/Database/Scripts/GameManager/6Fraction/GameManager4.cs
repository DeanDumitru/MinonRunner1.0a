using UnityEngine;
using System.Collections;

public class GameManager4 : MonoBehaviour {

    public int FinalFraction;
    public GameObject[] TextToShow;
    public GameObject oldText;
    public GameObject oldBackground;
    public GameObject newText;
    public GameObject newBackground;
    public GameObject button;

    public bool invetoryStatus = false;

    public GameObject failBackground;
    public GameObject failText;
    public GameObject failButton;
    public GameObject disableWhole;
    public GameObject disableWholeText;

    public string currentLevel;

    private int index;

    // Use this for initialization
    void Start ()
    {
        index = Random.Range(0, TextToShow.Length);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(FractionManager.score == FinalFraction)
        {
            TextToShow[index].SetActive(true);
            oldBackground.SetActive(false);
            oldText.SetActive(false);
            newBackground.SetActive(true);
            newText.SetActive(true);
            button.SetActive(true);
            disableWhole.SetActive(false);
            disableWholeText.SetActive(false);
            if(FinalFraction == 6)
                 InventoryGUI.inventoryToggle = invetoryStatus;
            else if(FinalFraction == 5)
            InventoryGUI2.inventoryToggle = invetoryStatus;

            UserClass.player.score = FractionManager.score;
            UserClass.player.success = true;
            UserClass.player.hintId = "Correctly did subtraction";
            UserClass.player.problemId = currentLevel;

            UserClass.player.printUserByLevel();
            UserClass.record.Add(UserClass.player);
        }
        else if(FractionManager.score < FinalFraction)
        {
            oldBackground.SetActive(false);
            oldText.SetActive(false);
            failBackground.SetActive(true);
            failButton.SetActive(true);
            failText.SetActive(true);
            disableWhole.SetActive(false);
            disableWholeText.SetActive(false);
            if (FinalFraction == 6)
                InventoryGUI.inventoryToggle = false;
            else if (FinalFraction == 5)
                InventoryGUI2.inventoryToggle = false;

            UserClass.player.score = FractionManager.score;
            UserClass.player.success = false;
            UserClass.player.hintId = "Incorrectly did subtraction";
            UserClass.player.problemId = currentLevel;

            UserClass.player.printUserByLevel();
            UserClass.record.Add(UserClass.player);
        }
	}
}
