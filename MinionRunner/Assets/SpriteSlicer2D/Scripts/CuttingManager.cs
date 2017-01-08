/********************************************************         
 *       Scripted and Designed for MinionRunner         *   
 *                                                      *   
 *       Authors:  Christoph Drechsler                  *
 *                 Dean Dumitru                         *
 *                                                      *
 *       Contact: drechslerc@uindy.edu                  *
 *                dumitrud@uindy.edu                    *   
 *                                                      *   
 *                                                      *   
 *               All Rights Reserved.                   *   
 *                                                      *   
 ********************************************************/

/*
blank
1/2
1/3 2/3
1/4 2/4 3/4
1/5 2/5 3/5 4/5
1/6 2/6 3/6 4/6 5/6
1/7 2/7 3/7 4/7 5/7 6/7
1/8 2/8 3/8 4/8 5/8 6/8 7/8
1/9 2/9 3/9 4/9 5/9 6/9 7/9 8/9
1/10 2/10 3/10 4/10 5/10 6/10 7/10 8/10 9/10
1/11 2/11 3/11 4/11 5/11 6/11 7/11 8/11 9/11 10/11
1/12 2/12 3/12 4/12 5/15 6/12 7/12 8/12 9/12 10/12 11/12 
*/


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CuttingManager : MonoBehaviour
{

    private string[] fractions = new string[67] {
            "blank",
            "1/2",
            "1/3", "2/3",
            "1/4", "2/4", "3/4",
            "1/5", "2/5", "3/5", "4/5",
            "1/6", "2/6", "3/6", "4/6", "5/6",
            "1/7", "2/7", "3/7", "4/7", "5/7", "6/7",
            "1/8", "2/8", "3/8", "4/8", "5/8", "6/8", "7/8",
            "1/9", "2/9", "3/9", "4/9", "5/9", "6/9", "7/9", "8/9",
            "1/10", "2/10", "3/10", "4/10", "5/10", "6/10", "7/10", "8/10", "9/10",
            "1/11", "2/11", "3/11", "4/11", "5/11", "6/11", "7/11", "8/11", "9/11", "10/11",
            "1/12", "2/12", "3/12", "4/12", "5/12", "6/12", "7/12", "8/12", "9/12", "10/12", "11/12" };

    private int[] ap = new int[67];
    const int NrFractions = 67;
    private int fractionCounter = 1;
    private int textCounter = 1;

    private string givenFration;

    private Transform[] cuts;
    private Transform[] lines;

    private GameObject fractionStrip;

    private int num = 1;
    private int denom = 2;

    public GameObject CutterObjectHolder;
    public GameObject LinesHolder;
    public GameObject Colors;
    public Text TitleText;

    public GameObject[] fractionStrips;
    public GameObject SpawnPoint;
    public GameObject bar;
    public GameObject MainCamera;

    void Start()
    {
        foreach (int i in ap)
            ap[i] = 0;
        TitleText.text = "Cut the following fraction: " + fractions[textCounter];
        givenFration = fractions[textCounter];

        Debug.Log(givenFration);

        textCounter++;
        fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter++], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        fractionStrip.transform.parent = bar.transform;
        SpawnPoint.SetActive(false);
    }

    public void button_colors()
    {
        Colors.SetActive(true);
        //Colors.SetActive(false);
    }


    public void check_button()
    {
        destroyLines();

        Rigidbody2D rbFirstCut;
        Rigidbody2D rbSecondCut;
        cuts = gameObject.GetComponentsInChildren<Transform>();
        rbFirstCut = cuts[1].GetComponent<Rigidbody2D>();
        rbSecondCut = cuts[2].GetComponent<Rigidbody2D>();

        float firstCutMass = rbFirstCut.mass;
        float secondCutMass = rbSecondCut.mass;
        float correctCutMass = 0.0f;
        float errorPercentage = 0.0f;


        if (givenFration == "1/2")
        {
            correctCutMass = (float)(1.0 / 2.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            if (firstCutMass < correctCutMass && correctCutMass - firstCutMass < errorPercentage)
            {
                spawnNextFraction();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else if (firstCutMass > correctCutMass && firstCutMass - correctCutMass < errorPercentage)
            {
                spawnNextFraction();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else Debug.Log("Incorrect");
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter-1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }


        if (givenFration == "1/3")
        {
            correctCutMass = (float)(1.0 / 3.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if(checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
                
            }
            else if(checkMass(secondCutMass, correctCutMass, errorPercentage) == true )
            {
                ok = 1;
            }

            if(ok == 1)
            {
                spawnNextFraction();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "2/3")
        {
            correctCutMass = (float)(2.0 / 3.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }

        if (givenFration == "1/4")
        {
            correctCutMass = (float)(1.0 / 4.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "2/4")
        {
            correctCutMass = (float)(2.0 / 4.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "3/4")
        {
            correctCutMass = (float)(3.0 / 4.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }

        if (givenFration == "1/5")
        {
            correctCutMass = (float)(1.0 / 5.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "2/5")
        {
            correctCutMass = (float)(2.0 / 5);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "3/5")
        {
            correctCutMass = (float)(3.0 / 5.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "4/5")
        {
            correctCutMass = (float)(4.0 / 5.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }

        if (givenFration == "1/6")
        {
            correctCutMass = (float)(1.0 / 6.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "2/6")
        {
            correctCutMass = (float)(2.0 / 6.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "3/6")
        {
            correctCutMass = (float)(3.0 / 6.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "4/6")
        {
            correctCutMass = (float)(4.0 / 6.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "5/6")
        {
            correctCutMass = (float)(5.0 / 6.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }

        if (givenFration == "1/7")
        {
            correctCutMass = (float)(1.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "2/7")
        {
            correctCutMass = (float)(2.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "3/7")
        {
            correctCutMass = (float)(3.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "4/7")
        {
            correctCutMass = (float)(4.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "5/7")
        {
            correctCutMass = (float)(5.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }  
        if (givenFration == "6/7")
        {
            correctCutMass = (float)(6.0 / 7.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }

        if (givenFration == "1/8")
        {
            correctCutMass = (float)(1.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "2/8")
        {
            correctCutMass = (float)(2.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "3/8")
        {
            correctCutMass = (float)(3.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "4/8")
        {
            correctCutMass = (float)(4.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "5/8")
        {
            correctCutMass = (float)(5.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "6/8")
        {
            correctCutMass = (float)(6.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "7/8")
        {
            correctCutMass = (float)(7.0 / 8.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }

        if (givenFration == "1/9")
        {
            correctCutMass = (float)(1.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "2/9")
        {
            correctCutMass = (float)(2.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "3/9")
        {
            correctCutMass = (float)(3.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }  
        if (givenFration == "4/9")
        {
            correctCutMass = (float)(4.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "5/9")
        {
            correctCutMass = (float)(5.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "6/9")
        {
            correctCutMass = (float)(6.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "7/9")
        {
            correctCutMass = (float)(7.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "8/9")
        {
            correctCutMass = (float)(8.0 / 9.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }

        if (givenFration == "1/10")
        {
            correctCutMass = (float)(1.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "2/10")
        {
            correctCutMass = (float)(2.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "3/10")
        {
            correctCutMass = (float)(3.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "4/10")
        {
            correctCutMass = (float)(4.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "5/10")
        {
            correctCutMass = (float)(5.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "6/10")
        {
            correctCutMass = (float)(6.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "7/10")
        {
            correctCutMass = (float)(7.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "8/10")
        {
            correctCutMass = (float)(8.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "9/10")
        {
            correctCutMass = (float)(9.0 / 10.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }

        if (givenFration == "1/11")
        {
            correctCutMass = (float)(1.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "2/11")
        {
            correctCutMass = (float)(2.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "3/11")
        {
            correctCutMass = (float)(3.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "4/11")
        {
            correctCutMass = (float)(4.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "5/11")
        {
            correctCutMass = (float)(5.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "6/11")
        {
            correctCutMass = (float)(6.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "7/11")
        {
            correctCutMass = (float)(7.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "8/11")
        {
            correctCutMass = (float)(8.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "9/11")
        {
            correctCutMass = (float)(9.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "10/11")
        {
            correctCutMass = (float)(10.0 / 11.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }

        if (givenFration == "1/12")
        {
            correctCutMass = (float)(1.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "2/12")
        {
            correctCutMass = (float)(2.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "3/12")
        {
            correctCutMass = (float)(3.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "4/12")
        {
            correctCutMass = (float)(4.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "5/12")
        {
            correctCutMass = (float)(5.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "6/12")
        {
            correctCutMass = (float)(6.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "7/12")
        {
            correctCutMass = (float)(7.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "8/12")
        {
            correctCutMass = (float)(8.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "9/12")
        {
            correctCutMass = (float)(9.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "10/12")
        {
            correctCutMass = (float)(10.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
        if (givenFration == "11/12")
        {
            correctCutMass = (float)(11.0 / 12.0);
            errorPercentage = (float)((correctCutMass * 5.0) / 100.0);

            int ok = 0;

            if (checkMass(firstCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;

            }
            else if (checkMass(secondCutMass, correctCutMass, errorPercentage) == true)
            {
                ok = 1;
            }

            if (ok == 1)
            {
                spawnNextFraction();
                Destroy(fractionStrip);
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);
            }
            else
            {
                Destroy((cuts[1] as Transform).gameObject);
                Destroy((cuts[2] as Transform).gameObject);

                Destroy(fractionStrip);
                SpawnPoint.SetActive(true);
                fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                fractionStrip.transform.parent = bar.transform;
                SpawnPoint.SetActive(false);
            }
        }
    }

    void spawnNextFraction()
    {
        if (num + 1 == denom)
        {
            TitleText.text = "Cut the following fraction: " + fractions[textCounter];
            givenFration = fractions[textCounter];
            textCounter++;

            Debug.Log(givenFration);

            num = 1;
            denom++;

            Destroy(fractionStrip);
            SpawnPoint.SetActive(true);
            fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter++], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            fractionStrip.transform.parent = bar.transform;
            SpawnPoint.SetActive(false);

        }
        else
        {
            TitleText.text = "Cut the following fraction: " + fractions[textCounter];
            givenFration = fractions[textCounter];
            textCounter++;

            Debug.Log(givenFration);

            num++;

            /*Destroy(fractionStrip);
            SpawnPoint.SetActive(true);
            fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter++], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            fractionStrip.transform.parent = bar.transform;
            SpawnPoint.SetActive(false);*/
        }
    }

    private bool checkMass(float cutMass, float correctMass, float error)
    {
        if (cutMass < correctMass && correctMass - cutMass < error)
        {
            /*spawnNextFraction();
            Destroy((cuts[1] as Transform).gameObject);
            Destroy((cuts[2] as Transform).gameObject);*/
            return true;
        }
        else if (cutMass > correctMass && cutMass - correctMass < error)
        {
            /*spawnNextFraction();
            Destroy((cuts[1] as Transform).gameObject);
            Destroy((cuts[2] as Transform).gameObject);*/
            return true;
        }
        else 
        {
            /*Destroy((cuts[1] as Transform).gameObject);
            Destroy((cuts[2] as Transform).gameObject);

            Destroy(fractionStrip);
            SpawnPoint.SetActive(true);
            fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter - 1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            fractionStrip.transform.parent = bar.transform;
            SpawnPoint.SetActive(false);*/
            return false;
        }
    }

    private void destroyLines()
    {
        lines = LinesHolder.GetComponentsInChildren<Transform>();
        for (int i = 1; i < lines.Length; i++)
            Destroy((lines[i] as Transform).gameObject);
    }


    public void selectColorButtonRed()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<RedColor>();

            Destroy(gameObject.GetComponent<BlueColor>());
            Destroy(gameObject.GetComponent<YellowColor>());
            Destroy(gameObject.GetComponent<GreenColor>());
        }
        CutterObjectHolder.SetActive(false);
    }

    public void selectColorButtonBlue()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<BlueColor>();

            Destroy(gameObject.GetComponent<RedColor>());
            Destroy(gameObject.GetComponent<YellowColor>());
            Destroy(gameObject.GetComponent<GreenColor>());
        }
        CutterObjectHolder.SetActive(false);

    }

    public void selectColorButtonYellow()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<YellowColor>();

            Destroy(gameObject.GetComponent<RedColor>());
            Destroy(gameObject.GetComponent<BlueColor>());
            Destroy(gameObject.GetComponent<GreenColor>());
        }
        CutterObjectHolder.SetActive(false);
    }

    public void selectColorButtonGreen()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<GreenColor>();

            Destroy(gameObject.GetComponent<RedColor>());
            Destroy(gameObject.GetComponent<YellowColor>());
            Destroy(gameObject.GetComponent<BlueColor>());
        }
        CutterObjectHolder.SetActive(false);
    }


    public void ActivateDrag()
    {
        //  index = 0;
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<MouseDrag>();
        }

        CutterObjectHolder.SetActive(false);
        MainCamera.GetComponent<DrawLine>().enabled = false;

    }


    public void ActivateCutting()
    {
        // index = 1;
        CutterObjectHolder.SetActive(true);
        MainCamera.GetComponent<DrawLine>().enabled = true;
    }

    /*

    public void twoTwo()
    {
        GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[0], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        chocolateBar.transform.parent = bar.transform;
        Destroy(SpawnPoint);
        Objects.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void twoThree()
    {
        GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[1], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        chocolateBar.transform.parent = bar.transform;
        Destroy(SpawnPoint);
        Objects.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void twoFour()
    {
        GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[2], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        chocolateBar.transform.parent = bar.transform;
        Destroy(SpawnPoint);
        Objects.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void threeThree()
    {
        GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[3], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        chocolateBar.transform.parent = bar.transform;
        Destroy(SpawnPoint);
        Objects.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void threeFour()
    {
        GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[4], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        chocolateBar.transform.parent = bar.transform;
        Destroy(SpawnPoint);
        Objects.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void fourFour()
    {
        GameObject chocolateBar = (GameObject)Instantiate(chocolateBars[5], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        chocolateBar.transform.parent = bar.transform;
        Destroy(SpawnPoint);
        Objects.SetActive(false);
        MainMenu.SetActive(true);
    }*/

}
