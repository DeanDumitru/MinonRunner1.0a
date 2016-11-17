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
1/2 * 1/2 	2-2
1/2 * 1/3	2-3
1/2 * 1/4 	2-4
1/3 * 1/3   3-3
1/2 * 3/4   2-4
2/3 * 1/4   3-4
2/3 * 3/4   3-4
3/4 * 3/4   4-4


2-2 = 1
2-3 = 2
2-4 = 3
3-3 = 4
3-4 = 5
4-4 = 6
*/


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToolHandler : MonoBehaviour {

    public GameObject CutterObjectHolder;
    public GameObject MainMenu;
    public GameObject Colors;
    public GameObject Objects;

    public GameObject[] chocolateBars;
    public GameObject SpawnPoint;
    public GameObject bar;

    public void button_colors()
    {
        Colors.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void button_objects()
    {
        Objects.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void button_main()
    {
        Colors.SetActive(false);
        Objects.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void restart_scene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
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

    }


    public void ActivateCutting()
    {
       // index = 1;
        CutterObjectHolder.SetActive(true);
    }



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
    }

}
