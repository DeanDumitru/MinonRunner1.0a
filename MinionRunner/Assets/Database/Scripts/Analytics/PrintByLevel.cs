using UnityEngine;
using System.Collections;
//using UnityEditor;

public class PrintByLevel : MonoBehaviour
{
    public string currentLevelName;

    void Start ()
    {
        UserClass.player.problemId = currentLevelName;
        UserClass.player.score = FractionManager.score;
        UserClass.player.success = true;
        UserClass.player.hintId = "Successfully completed the level";

        UserClass.player.printUserByLevel();
        UserClass.record.Add(UserClass.player);
	}
}
