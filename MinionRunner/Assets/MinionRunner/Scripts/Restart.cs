using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour {

    public void RestartScene()
    {
        PlayerDestroy.playerDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
