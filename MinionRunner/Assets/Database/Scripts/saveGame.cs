using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class saveGame : MonoBehaviour
{
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open("Assets/RecordsTet/usersData.txt", FileMode.Open);

        bf.Serialize(file, UserClass.player);
        file.Close();
    }
}