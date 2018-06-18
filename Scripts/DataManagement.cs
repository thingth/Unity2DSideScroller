using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManagement : MonoBehaviour
{
    public static DataManagement dataManagement; //Can be accessed by entire project
    public int HighScore;
    public int TotalScore;
    public int Life;

    void Awake()
    {
        if (dataManagement == null)
        {
            DontDestroyOnLoad(gameObject);
            dataManagement = this;
        }
        else if (dataManagement != this) //If it's another dataManagement
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        BinaryFormatter BinForm = new BinaryFormatter(); //Create a binary formatter; Encrypt
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
        gameData data = new gameData(); //Create container for data
        data.HighScore = HighScore;
        data.TotalScore = TotalScore;
        data.Life = Life;
        BinForm.Serialize(file, data); //Serializes
        file.Close();
    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter BinForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            gameData data = (gameData)BinForm.Deserialize(file);
            file.Close();
            HighScore = data.HighScore;
            TotalScore = data.TotalScore;
            Life = data.Life;
        }
    }
}

[Serializable]
class gameData
{
    public int HighScore;
    public int TotalScore;
    public int Life;
}