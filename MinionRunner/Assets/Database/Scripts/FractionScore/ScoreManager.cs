using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{

	public static int score;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {      
       text.text = "SCORE: " + score;
    }

    void setScore(int score1)
    {
        score = score1;
    }
}
