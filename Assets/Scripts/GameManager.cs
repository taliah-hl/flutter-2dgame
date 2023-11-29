using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameManager : MonoBehaviour
{
    
    [SerializeField] private string menuSceneName = "Menu-for-test";
    [SerializeField] private string gameOverSceneName = "died";
    [SerializeField] private string firstLvSceneName = "Lv2Scene";
    public string victorySceneName = "";
    private static bool gamePaused = false;
    public static bool IsGamePaused
    {
        get { return gamePaused; }
    }
    

    
    void Awake(){
        gamePaused = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            ReloadCurScene();
        }
        if(Input.GetKeyDown(KeyCode.O)){
            BackToMainMenu();
        }
    }
    public void pauseGame(float duration){
        if(gamePaused) return;
        Time.timeScale = 0.0f; // stop Time.deltaTime from updating
        StartCoroutine(waitForGamePause(duration));

    }

    IEnumerator waitForGamePause(float duration){
        gamePaused = true;
        yield return new WaitForSecondsRealtime(duration); // since timeScale set to 0, waitForSeconds will not count
        //but waitForSecondsRealtime is still counting
        Time.timeScale = 1.0f;  //set timeScale back to normal after waited
        gamePaused = false;
    }

    public void ReloadCurScene(){
        Debug.Log("GameManager::ReloadCurScene is called");
        Scene curScene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(curScene.name);
    }
    public void BackToMainMenu(){
        Debug.Log("GameManager::BackToMainMenu is called");
        SceneManager.LoadScene(menuSceneName);
    }
    public void GameOver(){
        Debug.Log("GameManager::GameOver is called");
        SceneManager.LoadScene(gameOverSceneName);
    }
    public void JumpToVictory(){
        Debug.Log("GameManager::JumpToVictory is called");
        SceneManager.LoadScene(victorySceneName);
    }

    public void LoadLatestLevel(){
        //load latest left level (for developer use only)
        // dont know how to do yet
    }

    public void LoadFirstLevel(){
        // Load ch1.1
        Debug.Log("GameManager::LoadFirstLevel is called");
        SceneManager.LoadScene(firstLvSceneName);
    }

    public void testfunc(){
        Debug.Log("hi i am gm");
    }

    public bool getIsGamePause(){
        return gamePaused;
    }
}
