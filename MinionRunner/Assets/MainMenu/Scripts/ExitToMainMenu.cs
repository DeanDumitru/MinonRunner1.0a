using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitToMainMenu : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
