using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text highScoreText;

    private void Start()
    {
        SaveManager.instance.LoadHighScore();

        if(SaveManager.instance.highScore != 0)
        {
            highScoreText.text = SaveManager.instance.highScoreName + " High Score: " + SaveManager.instance.highScore;
        }
        else
        {
            highScoreText.text = "High Score: 0";
        }
    }

    public void loadLevel()
    {
        Debug.Log(inputField.text);
        SaveManager.instance.SaveName(inputField.text);
        SceneManager.LoadScene("main");
    }

    public void resetScore()
    {
        highScoreText.text = "High Score: 0";
        SaveManager.instance.resetScore();
    }
}
