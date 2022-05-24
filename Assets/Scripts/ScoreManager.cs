using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instantiate;
    public TMP_Text scoreText_;
    public const string HighScoreKey = "HighScore";
    int score=0;
    void Awake(){

        instantiate = this;

    }
    void Start() {

        scoreText_.text = score.ToString();  
    }

    void Update() {

        if(GameController.gameControllerInstantiate.isGameFinished){

            Debug.Log("Message from Score Manager " + GameController.gameControllerInstantiate.isGameFinished);

            int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

            if(score>currentHighScore){
                PlayerPrefs.SetInt(HighScoreKey, score);
            }

        }
 
    }

    void OnDestroy() {

        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if(score>currentHighScore){

            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }

    }


    public void AddPoint(){
        
        score++;
        scoreText_.text = score.ToString();

    }

}
