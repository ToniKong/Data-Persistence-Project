using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public string currentSavedName;

    public int highScore;
    public string highScoreName;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string currentScoreName;
        public string highScoreName;
        public int highScore;
    }

    public void SaveName(string newName)
    {
        Debug.Log("Saving Name: " + newName);
        currentSavedName = newName;
        SaveData data = new SaveData();
        data.currentScoreName = newName;
        data.highScoreName = highScoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        Debug.Log("Loading the High Score");

        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            highScoreName = data.highScoreName;
            Debug.Log("Score: " + highScore + " Name: " + highScoreName);
        }
        else
        {
            Debug.Log("unable to find high score");
        }
    }

    public void SaveHighScore(int newScore)
    {
        Debug.Log("Doing Save High Score Score: " + newScore + " Name: " + currentSavedName);
        SaveData data = new SaveData();
        data.currentScoreName = currentSavedName;
        data.highScoreName = currentSavedName;
        data.highScore = newScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        highScore = newScore;
        highScoreName = currentSavedName;
    }

    public void resetScore()
    {
        Debug.Log("Resetting the Score");
        SaveData data = new SaveData();
        data.highScoreName = "";
        data.highScore = 0;
        data.currentScoreName = "";

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        highScore = 0;
        highScoreName = "";
    }
}
