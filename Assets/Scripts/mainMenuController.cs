using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mainMenuController : MonoBehaviour
{
    [SerializeField] public TMP_Text HighScoreText_;

    void Start()
    {
        OnApplicationFocus(true);
    }

    void OnApplicationFocus(bool focusStatus) {

        if(!focusStatus){return;}

        CancelInvoke();

        int highScore = PlayerPrefs.GetInt(ScoreManager.HighScoreKey, 0);

        HighScoreText_.text=$"High Score : {highScore}";
        
    }

    public void StartTheGame(){

        SceneManager.LoadScene(1);
    }

    public void QuiteGame(){

        Application.Quit();

    }
}
