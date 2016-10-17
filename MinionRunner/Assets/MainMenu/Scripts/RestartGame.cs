using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{

	public void Click()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
