using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject Player;
    public GameObject OtherPlayer;
    
    Rigidbody rig;

    public GameObject TextToShow;

	// Use this for initialization
	void Start ()
    {
        rig = Player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(FractionManager.score == 2)
        {
            Player.SetActive(true);
            OtherPlayer.SetActive(false);
            TextToShow.SetActive(true);
        }
	}
}
