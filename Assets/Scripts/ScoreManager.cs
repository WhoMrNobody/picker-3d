using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instantiate;
    public TMP_Text scoreText_;
    

    int score=0;
    void Awake(){

        instantiate = this;
    }

    void Start() {

        scoreText_.text = score.ToString();
        
        
    }

    public void AddPoint(){
        
        score++;
        scoreText_.text = score.ToString();

    }
    

}
