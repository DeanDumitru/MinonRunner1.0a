using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class AfterCompletionGM : MonoBehaviour
{
    public float StartDelay;
    public GameObject oldManager;
    public GameObject[] deactivateText;
    public GameObject[] activateText;
    public GameObject invetory;

    public string currentLevel;

	
	void Start ()
    {
        StartCoroutine(Pause());
        
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(StartDelay);

        oldManager.SetActive(false);
        foreach (GameObject i in deactivateText)
            i.SetActive(false);
        invetory.SetActive(true);
        
        foreach (GameObject i in activateText)
            i.SetActive(true);

        UserClass.player.problemId = currentLevel;
        UserClass.player.score = FractionManager.score;
        UserClass.player.success = true;
        UserClass.player.hintId = "Succesfully completed the level";

        UserClass.player.printUserByLevel();
        UserClass.record.Add(UserClass.player);
    }
}
