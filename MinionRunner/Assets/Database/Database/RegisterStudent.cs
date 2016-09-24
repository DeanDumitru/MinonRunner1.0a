using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegisterStudent : MonoBehaviour
{
    public InputField email;
    public InputField password;
    public InputField username;
    public InputField firstName;
    public InputField lastName;

    public string FirstLevelName;

    public void Register()
    {
        if (email.text != "" && password.text != "" && username.text != "" && firstName.text != "" && lastName.text != "")
        {
            string e = email.text;
            string p = password.text;
            string u = username.text;
            string f = firstName.text;
            string l = lastName.text;
            DataBaseManager.registerStudent(e, p, u, f, l, FirstLevelName);
        }
    }

	
}
