using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class FractionSelect : MonoBehaviour {

    public static FractionSelect instance;
 //   public GameObject lives;

    public GameObject slowMotion;

    public Transform Player;

    public float SlowMoTime, SlowTimeAllowed;
    private float currentSlowMo = 0.0F;
    public float resetTime;

    public GameObject[] myFraction;
    public GameObject RightWrongAnswer;

    public GameObject[] inputPanels;
    public Slider[] sliderValue;
    public Slider[] slider2ndCheck;

    public Sprite[] reset;
    public Sprite[] oneHalf;
    public Sprite[] oneThird;
    public Sprite[] twoThird;
    public Sprite[] oneFourth;
    public Sprite[] threeFourth;

    public Sprite[] right;
    public Sprite[] wrong;
     
    private int AnswerCheck;
    private int sliderSelect;

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
        FractionSelect.resetAnimation = false;
        //      GameObject.Find("Slider 1").GetComponent<Animator>().Play("Idle", -1, 0f);


        if (other.tag == "Fraction2")
        {
            Debug.Log("HitFraction2 show me");
         //   SlowMo();
            int randomFraction = Random.Range(0, 5);

            if (randomFraction == 0)
            {
                sliderSelect = 0;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneHalf[0];
                AnswerCheck = 1;                           
            }
            else if (randomFraction == 1)
            {
                sliderSelect = 1;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneHalf[1];
                AnswerCheck = 1;
            }
            else if (randomFraction == 2)
            {
                sliderSelect = 2;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneHalf[2];
                AnswerCheck = 1;
            }
            else if (randomFraction == 3)
            {
                sliderSelect = 3;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneHalf[3];
                AnswerCheck = 1;
            }
            else if (randomFraction == 4)
            {
                sliderSelect = 4;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneHalf[4];
                AnswerCheck = 1;
            }


        }
        else if (other.tag == "Fraction3")
        {
            Debug.Log("Hit Fraction 3 show me");
    //        SlowMo();
            int randomFraction = Random.Range(0, 10);

            if (randomFraction == 0)
            {
                sliderSelect = 5;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneThird[0];
                AnswerCheck = 2;
            }
            else if (randomFraction == 1)
            {
                sliderSelect = 6;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneThird[1];
                AnswerCheck = 2;
            }
            else if (randomFraction == 2)
            {
                sliderSelect = 7;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneThird[2];
                AnswerCheck = 2;
            }
            else if (randomFraction == 3)
            {
                sliderSelect = 8;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneThird[3];
                AnswerCheck = 2;
            }
            else if (randomFraction == 4)
            {
                sliderSelect = 9;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneThird[4];
                AnswerCheck = 2;
            }
            else if (randomFraction == 5)
            {
                sliderSelect = 10;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = twoThird[0];
                AnswerCheck = 3;
            }
            else if (randomFraction == 6)
            {
                sliderSelect = 11;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = twoThird[1];
                AnswerCheck = 3;
            }
            else if (randomFraction == 7)
            {
                sliderSelect = 12;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = twoThird[2];
                AnswerCheck = 3;
            }
            else if (randomFraction == 8)
            {
                sliderSelect = 13;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = twoThird[3];
                AnswerCheck = 3;
            }
            else if (randomFraction == 9)
            {
                sliderSelect = 14;
                inputPanels[sliderSelect].gameObject.SetActive(true);
                myFraction[sliderSelect].GetComponent<Image>().overrideSprite = twoThird[4];
                AnswerCheck = 3;
            }
        

            

        }
        if (other.tag == "Fraction4")
        {
             Debug.Log("Hit Fraction 4 show me");
       ///      SlowMo();
             int randomFraction = Random.Range(0, 9);
           
                if (randomFraction == 0)
                {
                    sliderSelect = 15;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneFourth[0];
                    AnswerCheck = 4;
                }
                else if (randomFraction == 1)
                {
                    sliderSelect = 16;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneFourth[1];
                    AnswerCheck = 4;
                }
                else if (randomFraction == 2)
                {
                    sliderSelect = 17;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneFourth[2];
                    AnswerCheck = 4;
                }
                else if (randomFraction == 3)
                {
                    sliderSelect = 18;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneFourth[3];
                    AnswerCheck = 4;
                }
                else if (randomFraction == 4)
                {
                    sliderSelect = 19;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = oneFourth[4];
                    AnswerCheck = 4;
                }
                else if (randomFraction == 5)
                {
                    sliderSelect = 20;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = threeFourth[0];
                    AnswerCheck = 5;
                }
                if (randomFraction == 6)
                {
                    sliderSelect = 21;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = threeFourth[1];
                    AnswerCheck = 5;
                }
                else if (randomFraction == 7)
                {
                    sliderSelect = 22;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = threeFourth[2];
                    AnswerCheck = 5;
                }
                else if (randomFraction == 8)
                {
                    sliderSelect = 23;
                    inputPanels[sliderSelect].gameObject.SetActive(true);
                    myFraction[sliderSelect].GetComponent<Image>().overrideSprite = threeFourth[3];
                    AnswerCheck = 5;
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
        myFraction[sliderSelect].GetComponent<Image>().overrideSprite = reset[0];
        slowMotion.gameObject.SetActive(false);
        
    }

    void Reset2()
    {
        RightWrongAnswer.GetComponent<Image>().overrideSprite = reset[1];
    }

    public bool checkAnswer;
    void AnswerCheckOneHalf()
    {
        if (0.45 <= checkInput && 0.55 >= checkInput)
        {
            checkAnswer = true;
        }
        else
        {
            checkAnswer = false;
        }
         
        if (AnswerCheck == 1 && checkAnswer)
        {
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            Debug.Log("1 = 1 ... + 5");
       
            RightWrongAnswer.GetComponent<Image>().overrideSprite = right[Random.Range(0, 5)];
            Panel.playAnimation = true;
            //Invoke("Reset2", resetTime);
        }
        else if (!checkAnswer)
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
               

            }
        }
    }
    private bool AnswerWasRightOrWrong = false;
    void AnswerCheckOneThird()
    {

        if (0.27 <= checkInput && 0.36 >= checkInput)
        {
            checkAnswer = true;
        }
        else
        {
            checkAnswer = false;
        }
        if (checkAnswer && AnswerCheck == 2)
        {
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            Debug.Log("2 = 2 ... + 5");
            RightWrongAnswer.GetComponent<Image>().overrideSprite = right[Random.Range(0, 5)];
            //   Invoke("Reset2", resetTime);
            Panel.playAnimation = true;
            AnswerWasRightOrWrong = true;
        }
        else if (!checkAnswer)
        {
            if (AnswerCheck == 2)
            {
                Scoring.score = Scoring.score - 5;
               // Scoring.lives = Scoring.lives - 1;
                Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                Debug.Log("2 = 2  wrong ... - 5");
                RightWrongAnswer.GetComponent<Image>().overrideSprite = wrong[Random.Range(0, 5)];
            //    Invoke("Reset2", resetTime);
              
                AnswerWasRightOrWrong = false;
            }
        }
    }

    void AnswerCheckThreeTwoThird()
    {
        if (0.63 <= checkInput && 0.69 >= checkInput)
        {
            checkAnswer = true;
        }
        else
        {
            checkAnswer = false;
        }
        if (checkAnswer && AnswerCheck == 3)
        {
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            Debug.Log("3 = 3.... +5");
            RightWrongAnswer.GetComponent<Image>().overrideSprite = right[Random.Range(0, 5)];
            //      Invoke("Reset2", resetTime);
            Panel.playAnimation = true;
          
            AnswerWasRightOrWrong = true;
        }
        else if (!checkAnswer)
        {
            if (AnswerCheck == 3)
            {
                Scoring.score = Scoring.score - 5;
            //    Scoring.lives = Scoring.lives - 1;
                Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                Debug.Log("3 = 3  wrong ... - 5");
                RightWrongAnswer.GetComponent<Image>().overrideSprite = wrong[Random.Range(0, 5)];
          //      Invoke("Reset2", resetTime);
              
                AnswerWasRightOrWrong = false;
               
            }
        }
    }

    void AnswerCheckOneFourth()
    {
            if (0.20 <= checkInput && 0.30 >= checkInput)
            {
                checkAnswer = true;
            }
            else
            {
                checkAnswer = false;
            }
            if (checkAnswer && AnswerCheck == 4)
            {
                Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                Debug.Log("3 = 3.... +5");
                RightWrongAnswer.GetComponent<Image>().overrideSprite = right[Random.Range(0, 5)];
           //     Invoke("Reset2", resetTime);
              
                AnswerWasRightOrWrong = true;
                Panel.playAnimation = true;
        }
            else if (!checkAnswer)
            {
                if (AnswerCheck == 4)
                {
                    Scoring.score = Scoring.score - 5;
                    //    Scoring.lives = Scoring.lives - 1;
                    Time.timeScale = 1.0F;
                    Time.fixedDeltaTime = 0.02F * Time.timeScale;
                    Debug.Log("3 = 3  wrong ... - 5");
                    RightWrongAnswer.GetComponent<Image>().overrideSprite = wrong[Random.Range(0, 5)];
               //     Invoke("Reset2", resetTime);
                   
                    AnswerWasRightOrWrong = false;
            }
            }
        }

    void AnswerCheckThreeFourth()
    {
        if (0.70 <= checkInput && 0.80 >= checkInput)
        {
            checkAnswer = true;
        }
        else
        {
            checkAnswer = false;
        }

        if (checkAnswer && AnswerCheck == 5)
        {
            Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            Debug.Log("3 = 3.... +5");
            RightWrongAnswer.GetComponent<Image>().overrideSprite = right[Random.Range(0, 5)];
        //    Invoke("Reset2", resetTime);
     
            AnswerWasRightOrWrong = true;
            Panel.playAnimation = true;
        }
        else if (!checkAnswer)
        {
            if (AnswerCheck == 5)
            {
                Scoring.score = Scoring.score - 5;
                //    Scoring.lives = Scoring.lives - 1;
                Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                Debug.Log("3 = 3  wrong ... - 5");
                RightWrongAnswer.GetComponent<Image>().overrideSprite = wrong[Random.Range(0, 5)];
             //   Invoke("Reset2", resetTime);
           
                AnswerWasRightOrWrong = false;
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

    }

    public float checkInput;
    public void Submit1stSlider()
    {
        Debug.Log(sliderValue[sliderSelect].value);

        checkInput = sliderValue[sliderSelect].value;
    
        AnswerCheckOneFourth();  
        AnswerCheckOneHalf();
        AnswerCheckOneThird();
        AnswerCheckThreeTwoThird();  
        AnswerCheckThreeFourth();      
        Invoke("Reset2", resetTime);

       /* if (AnswerWasRightOrWrong == true)
        {
          GameObject.Find("Check Answer Button").SetActive(false);
        }
        */
        //   

    }
    public float check2ndInput;

    public static bool resetAnimation = false;
    public void Submit2ndSlider()
    {
        Debug.Log(slider2ndCheck[sliderSelect].value);

        check2ndInput = slider2ndCheck[sliderSelect].value;
        Panel.playAnimation = false;
        SpawnSlider.ss = false;

        if (Mathf.Abs(check2ndInput - checkInput) < 0.08)
        {
            //GameObject.Find("Check Answer Button").SetActive(true);
            GameObject.Find("Slider (2)").SetActive(false);
            resetAnimation = true;
            inputPanels[sliderSelect].gameObject.SetActive(false);
            RightWrongAnswer.GetComponent<Image>().overrideSprite = right[Random.Range(0, 5)];
            Invoke("Reset2", resetTime);
            Reset();
            Scoring.score = Scoring.score + 5;
            slider2ndCheck[sliderSelect].value = 0;
          
            

        }
        else
        {
            RightWrongAnswer.GetComponent<Image>().overrideSprite = wrong[Random.Range(0, 5)];
            Invoke("Reset2", resetTime);
        }

        
        
    }

    /*  public void gameOver()
      {
          if(Scoring.lives == 0)
          {

          }
      }*/
}


/* reset animation
 * setactive false slider
 * button and text
 * */
 