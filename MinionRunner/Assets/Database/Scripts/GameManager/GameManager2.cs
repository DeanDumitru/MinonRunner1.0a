using UnityEngine;
using System.Collections;

public class GameManager2 : MonoBehaviour {

    public int FinalFraction;
    public GameObject Player;
    public GameObject OtherPlayer;
    public GameObject light1;
    public GameObject[] TextToShow;
    public GameObject[] TextToHide;
    int index;
    public GameObject newGM;

    public GameObject incrementScore;

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
            incrementScore.SetActive(true);

            Player.SetActive(true);
            OtherPlayer.SetActive(false);
            TextToShow[index].SetActive(true);
            light1.SetActive(true);
            newGM.SetActive(true);

            foreach (GameObject i in TextToHide)
                i.SetActive(false);
        }
	}
}
