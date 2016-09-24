using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public void ResumeGame()
    {
        HoldScene gp = FindObjectOfType<HoldScene>();
     //  gp._paused = false;
        SceneManager.UnloadScene("Level 1.1");
        
    }

}
    