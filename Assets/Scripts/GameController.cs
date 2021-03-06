using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController gameControllerInstantiate;
    [SerializeField] public TMP_Text PlayText_;
    [SerializeField] TMP_Text CurrentScoreText_;
    [SerializeField] GameObject gameOverCanvas;

    private static bool GameControllerCreated = false;
    public Passage passage;
    PlayerMovement player;
    AsyncOperation asyncScene;
    int activeScene;
    public bool isGameStarted=false;
    public bool isLevelCompleted=false;
    public bool isGameFinished=false;

    void Awake() {

        gameControllerInstantiate=this;
        passage = FindObjectOfType<Passage>();
        player = FindObjectOfType<PlayerMovement>();
        
    }

    void Start() {

        asyncScene=SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
        asyncScene.allowSceneActivation=false;
        DontDestroytheObject();
    }
        

    void Update() {

        activeScene= SceneManager.GetActiveScene().buildIndex;

        if(passage.isCounting()==true){

            StartCoroutine(GameOver());

        }else{
            StopCoroutine(GameOver());
        }

        if(isLevelCompleted==true){
            StartCoroutine(nameof(LevelCompleted));
        }

    }

    public void ResumeGame(){

        passage.PassActivated();
        player.PickerMoveForward();
        StopCoroutine(GameOver());

    }

    public void BackToMainMenu(){

        StopAllCoroutines();
        Destroy(this.gameObject);
        SceneManager.LoadScene(0);
        
    }

    public void RestartLevel(){

        gameOverCanvas.SetActive(false);
        Destroy(this.gameObject);
        player.transform.position= new Vector3(0f, 2f, 0f);
        isLevelCompleted=false;
        isGameStarted=false;
        PlayText_.enabled=true;
        passage.isCounting_=false;
        SceneManager.LoadScene(activeScene);

    }

    IEnumerator LevelCompleted(){

        yield return new WaitForSeconds(2f);
        player.transform.position= new Vector3(0f, 1f, 0f);
        isLevelCompleted=false;
        isGameStarted=false;
        PlayText_.enabled=true;
        passage.isCounting_=false;
        asyncScene.allowSceneActivation=true;
        player = FindObjectOfType<PlayerMovement>();
        passage = FindObjectOfType<Passage>();
        
    }

    IEnumerator GameOver(){

        yield return new WaitUntil(passage.isCounting);
        Invoke(nameof(GameFailed), 5f);
        
    }

    void GameFailed(){

        if(passage.isPlatformLifted_==true){ return; }
        
        CurrentScoreText_.text=ScoreManager.instantiate.scoreText_.text;
        gameOverCanvas.SetActive(true);
        isGameStarted=false;

    }

    public void GameFinished(){

        isGameFinished=true;
        SceneManager.LoadScene(0);
        Destroy(this.gameObject);

    }

    void DontDestroytheObject(){

        DontDestroyOnLoad(gameObject);

        if(GameControllerCreated){

            Destroy(this.gameObject);
            GameControllerCreated = false;

        }
    }

}
