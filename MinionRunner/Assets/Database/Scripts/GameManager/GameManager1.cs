using UnityEngine;
using System.Collections;

public class GameManager1 : MonoBehaviour {

    public int FinalFraction;
    public GameObject Player;
    public GameObject OtherPlayer;
    public GameObject light1;
    public GameObject NextButton;
    public GameObject[] TextToShow;
    public GameObject[] TextToHide;

    public GameObject PrintDataSuccess;
    public GameObject incrementScore;

    int index;

    /*public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;*/

    // Use this for initialization
    void Start ()
    {
        index = Random.Range(0, TextToShow.Length);
        // Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(FractionManager.score == FinalFraction)
        {
            PrintDataSuccess.SetActive(true);
            incrementScore.SetActive(true);

            Player.SetActive(true);
            OtherPlayer.SetActive(false);
            TextToShow[index].SetActive(true);
            light1.SetActive(true);
            NextButton.SetActive(true);

            /*Cursor.visible = true;
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);*/

            foreach (GameObject i in TextToHide)
                i.SetActive(false);

        }
	}

    
}
