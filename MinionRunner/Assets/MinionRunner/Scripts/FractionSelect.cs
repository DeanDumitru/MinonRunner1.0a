using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class FractionSelect : MonoBehaviour {

    public GameObject myFraction;
    public GameObject RightWrongAnswer;
    public GameObject lives;

    public GameObject slowMotion;

    public Transform Player;

    public float SlowMoTime, SlowTimeAllowed;
    private float currentSlowMo = 0.0F;
    public float resetTime;

    public Sprite[] reset;
    public Sprite[] oneHalf;
    public Sprite[] oneThird;
    public Sprite[] twoThird;
    public Sprite[] oneFourth;
    public Sprite[] threeFourth;

    public Sprite[] right;
    public Sprite[] wrong;
     
    private int AnswerCheck;
    
 /*   void OnTriggerStay(Collider other) // Activate Particle System
    {
        if (other.tag == "Fraction2" && Input.GetButtonDown("Fire1")) 
        {
            other.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true); // this is working
        }
        else if(other.tag == "Fraction3" && Input.GetButtonDown("Fire1"))
        {
            other.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true); // working
        }
        else if (other.tag == "Fraction3" && Input.GetButtonDown("Fire2"))
        {
            other.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            other.gameObject.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(other.tag == "Fraction4" && Input.GetButtonDown("Fire1"))
        {
            other.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true); // working
        }
        else if (other.tag == "Fraction4" && Input.GetButtonDown("Fire3"))
        {
            other.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            other.gameObject.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
            other.gameObject.transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(true);
        }
    }
*/
    void OnTriggerEnter(Collider other) // show the fractions 
    {
        if (other.tag == "Fraction2")
        {
            Debug.Log("HitFraction2 show me");
            SlowMo();
            int randomFraction = Random.Range(0, 6);

            if (randomFraction == 0)
            {
                myFraction.GetComponent<Image>().overrideSprite = oneHalf[0];
                AnswerCheck = 1;                           
            }
            else if (randomFraction == 1)
            {
                myFraction.GetComponent<Image>().overrideSprite = oneHalf[1];
                AnswerCheck = 1;
            }
            else if (randomFraction == 2)
            {
                myFraction.GetComponent<Image>().overrideSprite = oneHalf[2];
                AnswerCheck = 1;
            }
            else if (randomFraction == 3)
            {
                myFraction.GetComponent<Image>().overrideSprite = oneHalf[3];
                AnswerCheck = 1;
            }
            else if (randomFraction == 4)
            {
                myFraction.GetComponent<Image>().overrideSprite = oneHalf[4];
                AnswerCheck = 1;
            }
            else if (randomFraction == 5)
            {
                myFraction.GetComponent<Image>().overrideSprite = oneHalf[5];
                AnswerCheck = 1;
            }

        }
        else if (other.tag == "Fraction3")
        {
            Debug.Log("Hit Fraction 3 show me");
            SlowMo();
            int randomFraction = Random.Range(0, 11);

            if (randomFraction == 0)
            {
                myFraction.GetComponent<Image>().overrideSprite = oneThird[0];
                AnswerCheck = 1;
            }
            else if (randomFraction == 1)
            {
                myFraction.GetComponent<Image>().overrideSprite = oneThird[1];
                AnswerCheck = 1;
            }
            else if (randomFraction == 2)
            {
                myFraction.GetComponent<Image>().overrideSprite = oneThird[2];
                AnswerCheck = 1;
            }
            else if (randomFraction == 3)
            {
                myFraction.GetComponent<Image>().overrideSprite = oneThird[3];
                AnswerCheck = 1;
            }
            else if (randomFraction == 4)
            {
                myFraction.GetComponent<Image>().overrideSprite = oneThird[4];
                AnswerCheck = 1;
            }
            else if (randomFraction == 5)
            {
                myFraction.GetComponent<Image>().overrideSprite = oneThird[5];
                AnswerCheck = 1;
            }
            else if (randomFraction == 6)
            {
                myFraction.GetComponent<Image>().overrideSprite = twoThird[0];
                AnswerCheck = 2;
            }
            else if (randomFraction == 7)
            {
                myFraction.GetComponent<Image>().overrideSprite = twoThird[1];
                AnswerCheck = 2;
            }
            else if (randomFraction == 8)
            {
                myFraction.GetComponent<Image>().overrideSprite = twoThird[2];
                AnswerCheck = 2;
            }
            else if (randomFraction == 9)
            {
                myFraction.GetComponent<Image>().overrideSprite = twoThird[3];
                AnswerCheck = 2;
            }
            else if (randomFraction == 10)
            {
                myFraction.GetComponent<Image>().overrideSprite = twoThird[4];
                AnswerCheck = 2;
            }
            else if (randomFraction == 11)
            {
                myFraction.GetComponent<Image>().overrideSprite = twoThird[5];
                AnswerCheck = 2;
            }

        }
        if (other.tag == "Fraction4")
        {
             Debug.Log("Hit Fraction 4 show me");
             SlowMo();
             int randomFraction = Random.Range(0, 11);
           
                if (randomFraction == 0)
                {
                    myFraction.GetComponent<Image>().overrideSprite = oneFourth[0];
                    AnswerCheck = 1;
                }
                else if (randomFraction == 1)
                {
                    myFraction.GetComponent<Image>().overrideSprite = oneFourth[1];
                    AnswerCheck = 1;
                }
                else if (randomFraction == 2)
                {
                    myFraction.GetComponent<Image>().overrideSprite = oneFourth[2];
                    AnswerCheck = 1;
                }
                else if (randomFraction == 3)
                {
                    myFraction.GetComponent<Image>().overrideSprite = oneFourth[3];
                    AnswerCheck = 1;
                }
                else if (randomFraction == 4)
                {
                    myFraction.GetComponent<Image>().overrideSprite = oneFourth[4];
                    AnswerCheck = 1;
                }
                else if (randomFraction == 5)
                {
                    myFraction.GetComponent<Image>().overrideSprite = oneFourth[5];
                    AnswerCheck = 1;
                }
                if (randomFraction == 6)
                {
                    myFraction.GetComponent<Image>().overrideSprite = threeFourth[0];
                    AnswerCheck = 3;
                }
                else if (randomFraction == 7)
                {
                    myFraction.GetComponent<Image>().overrideSprite = threeFourth[1];
                    AnswerCheck = 3;
                }
                else if (randomFraction == 8)
                {
                    myFraction.GetComponent<Image>().overrideSprite = threeFourth[2];
                    AnswerCheck = 3;
                }
                else if (randomFraction == 9)
                {
                    myFraction.GetComponent<Image>().overrideSprite = threeFourth[3];
                    AnswerCheck = 3;
                }
                else if (randomFraction == 10)
                {
                    myFraction.GetComponent<Image>().overrideSprite = threeFourth[4];
                    AnswerCheck = 3;
                }

           }
        }

    void SlowMo()
    {
        if (Time.timeScale == 1.0F)
        {
            Time.timeScale = SlowMoTime;
            slowMotion.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }          
    }

    void Reset()
    {
        myFraction.GetComponent<Image>().overrideSprite = reset[0];
        slowMotion.gameObject.SetActive(false);
        
    }

    void Reset2()
    {
        RightWrongAnswer.GetComponent<Image>().overrideSprite = reset[1];
    }

    void AnswerCheckOne()
    {

        if (Input.GetButtonDown("Fire1") && AnswerCheck ==1 )
        {
            Scoring.score = Scoring.score + 5;
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            Debug.Log("1 = 1 ... + 5");
            AnswerCheck = 10;
            RightWrongAnswer.GetComponent<Image>().overrideSprite = right[Random.Range(0, 5)];
            Reset();
            Invoke("Reset2", resetTime);
        }
        else if (Input.GetButtonDown("Fire0") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3") || Input.GetButtonDown("Fire4"))
        {
            if (AnswerCheck == 1)
            {
                Scoring.score = Scoring.score - 5;
              //  Scoring.lives = Scoring.lives - 1;
                Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                Debug.Log("1 = 1 wrong ... - 5");
                RightWrongAnswer.GetComponent<Image>().overrideSprite = wrong[Random.Range(0, 5)];
                Invoke("Reset2", resetTime);
                AnswerCheck = 10;
                Reset();
            }
        }
    }

    void AnswerCheckTwo()
    {
        if (Input.GetButtonDown("Fire2") && AnswerCheck == 2)
        {
            Scoring.score = Scoring.score + 5;
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            Debug.Log("2 = 2 ... + 5");
            RightWrongAnswer.GetComponent<Image>().overrideSprite = right[Random.Range(0, 5)];
            Invoke("Reset2", resetTime);
            AnswerCheck = 10;
            Reset();
        }
        else if (Input.GetButtonDown("Fire0") || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire3") || Input.GetButtonDown("Fire4"))
        {
            if (AnswerCheck == 2)
            {
                Scoring.score = Scoring.score - 5;
               // Scoring.lives = Scoring.lives - 1;
                Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                Debug.Log("2 = 2  wrong ... - 5");
                RightWrongAnswer.GetComponent<Image>().overrideSprite = wrong[Random.Range(0, 5)];
                Invoke("Reset2", resetTime);
                AnswerCheck = 10;
                Reset();
            }
        }
    }

    void AnswerCheckThree()
    {
        if (Input.GetButtonDown("Fire3") && AnswerCheck == 3)
        {
            Scoring.score = Scoring.score + 5;
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            Debug.Log("3 = 3.... +5");
            RightWrongAnswer.GetComponent<Image>().overrideSprite = right[Random.Range(0, 5)];
            Invoke("Reset2", resetTime);
            AnswerCheck = 10;
            Reset();

        }
        else if (Input.GetButtonDown("Fire0") || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire4"))
        {
            if (AnswerCheck == 3)
            {
                Scoring.score = Scoring.score - 5;
            //    Scoring.lives = Scoring.lives - 1;
                Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                Debug.Log("3 = 3  wrong ... - 5");
                RightWrongAnswer.GetComponent<Image>().overrideSprite = wrong[Random.Range(0, 5)];
                Invoke("Reset2", resetTime);
                AnswerCheck = 10;
                Reset();

            }
        }
    }


    void Update()
    {
        if (Player)
        {
            transform.position = new Vector3(Player.transform.position.x, 0, 0);
        }
        else if (!Player)
        {
            transform.position = transform.position;
        }

        AnswerCheckOne();
        AnswerCheckTwo();
        AnswerCheckThree();

    }

  /*  public void gameOver()
    {
        if(Scoring.lives == 0)
        {

        }
    }*/
}
