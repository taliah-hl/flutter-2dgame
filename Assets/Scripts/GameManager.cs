using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameManager : MonoBehaviour    // this is GM for all levels!!
{
    
    [SerializeField] private string menuSceneName = "Menu";
    [SerializeField] private string gameOverSceneName = "died";
    [SerializeField] private string firstLvSceneName = "Lv2Scene";
    public string victorySceneName = "";
    public static bool gamePaused = false;
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
        switch (curScene.name)
        {
            case "ch2-1": case "ch3-1": case "ch4-1":
                //string tmp = curScene.name + "_nointro"; //comment for now as scene is changed
                string tmp = curScene.name;
                Debug.Log("GameManager::going to call:"+tmp);
                SceneManager.LoadScene(tmp);
                break;
            default:
                SceneManager.LoadScene(curScene.name);
                break;
        }
    }
    public void BackToMainMenu(){
        Debug.Log("GameManager::BackToMainMenu is called");
        SceneManager.LoadScene(menuSceneName);
    }
    public void GameOver(){     //control what happen when player die
        Debug.Log("GameManager::GameOver is called, GameOver will call ReloadCurScene");
        ReloadCurScene();
        
    }
    public void LoadGameOverScene(){     // not in use for now
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

    public void SetGamePaused()
    {
        gamePaused = true;
    }

    public void ResetGamePaused()
    {
        gamePaused = false;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
