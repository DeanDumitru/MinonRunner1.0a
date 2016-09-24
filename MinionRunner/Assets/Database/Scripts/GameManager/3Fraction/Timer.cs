using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    static float timeLeft = 10.0f;
    public GameObject TextFail;
    public GameObject RestartButton;
    public GameObject OtherText;
    public GameObject Player;
    public GameObject OtherPlayer;
    public GameObject[] ToHide;

    bool isMoving;
    // Use this for initialization
    void Start ()
    {
        timeLeft = 10.0f;
	    
	}
    

    void Update()
    {
        checkMove();
        if (isMoving)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0 && timeLeft > -1)
            {
                isMoving = false;
                //Application.LoadLevel(Application.loadedLevel);
                TextFail.SetActive(true);
                RestartButton.SetActive(true);
                Player.SetActive(true);
                OtherPlayer.SetActive(false);
                OtherText.SetActive(false);

                foreach (GameObject i in ToHide)
                    i.SetActive(false);

                UserClass.player.problemId = "2out3";
                UserClass.player.score = -1;
                UserClass.player.success = false;
                UserClass.player.hintId = "Failed to sprint in time";

                UserClass.player.printUserByLevel();
                UserClass.record.Add(UserClass.player);


            }
        }
    }

    void checkMove()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            isMoving = true;
    }

    public static float getTimeLeft()
    {
        return timeLeft;
    }
  
}
