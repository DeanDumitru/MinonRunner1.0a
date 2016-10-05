using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DUOTOTS : MonoBehaviour {

    public Text Username;

    void Start () {
        Username.text = UserClass.player.userId;
	}

}
