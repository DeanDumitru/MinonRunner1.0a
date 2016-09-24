using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HoldScene : MonoBehaviour
{

    public void PauseGame()
    {
        SceneManager.LoadScene("Level 1.1", LoadSceneMode.Additive);
        SceneManager.LoadScene("FractionEnter");

    }

  
}