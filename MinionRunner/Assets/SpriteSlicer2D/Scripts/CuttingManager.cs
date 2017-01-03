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

    private GameObject fractionStrip;

    private int num = 1;
    private int denom = 2;

    public GameObject CutterObjectHolder;
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
        TitleText.text = "Cut the following fraction: " + fractions[textCounter++];
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
        if(num+1 == denom)
        {
            TitleText.text = "Cut the following fraction: " + fractions[textCounter++];

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
            TitleText.text = "Cut the following fraction: " + fractions[textCounter++];

            num++;

            /*Destroy(fractionStrip);
            SpawnPoint.SetActive(true);
            fractionStrip = (GameObject)Instantiate(fractionStrips[fractionCounter++], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            fractionStrip.transform.parent = bar.transform;
            SpawnPoint.SetActive(false);*/
        }
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
