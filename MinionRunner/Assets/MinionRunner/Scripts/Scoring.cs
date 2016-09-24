using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoring : MonoBehaviour {

    private static Scoring instance;



    public Text scoreText;
  //  public Text livesText;
    public static int score;
 //   public static int lives;


    void Start () {
        score = 0;
 //       lives = 3;
	}

    void Update()
    {
        scoreText.text = "Score: " + score;
 //       livesText.text = "Lives: " + lives;
    }
}
