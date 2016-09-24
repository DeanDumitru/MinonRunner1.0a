using UnityEngine;
using System.Collections;

public class GameManager3 : MonoBehaviour {

    public int FinalFraction;
    public GameObject Player;
    public GameObject OtherPlayer;
    public GameObject newGM;

    public GameObject incrementScore;

    //public GameObject background;
    //public GameObject endText;


    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(FractionManager.score == FinalFraction)
        {
            Player.SetActive(true);
            OtherPlayer.SetActive(false);
            newGM.SetActive(true);
            // background.SetActive(true);
            // endText.SetActive(true);

            incrementScore.SetActive(true);
        }
	}
}
