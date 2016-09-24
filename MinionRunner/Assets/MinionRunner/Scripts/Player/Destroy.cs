using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Destroy : MonoBehaviour {

    public GameObject HighScore;
    public GameObject EnterName;

	void Update () {
        if (gameObject.transform.position.y <= -30)
        {
            HighScore.gameObject.SetActive(true);
            EnterName.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
