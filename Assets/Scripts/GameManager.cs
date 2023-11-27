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
    private bool isGamePaused;
    

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
        if(isGamePaused) return;
        Time.timeScale = 0.0f; // stop Time.deltaTime from updating
        StartCoroutine(waitForGamePause(duration));

    }

    IEnumerator waitForGamePause(float duration){
        isGamePaused = true;
        yield return new WaitForSecondsRealtime(duration); // since timeScale set to 0, waitForSeconds will not count
        //but waitForSecondsRealtime is still counting
        Time.timeScale = 1.0f;  //set timeScale back to normal after waited
        isGamePaused = false;
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
    private void GameOver(){
        Debug.Log("GameManager::GameOver is called");
        SceneManager.LoadScene(gameOverSceneName);
    }
    private void JumpToVictory(){
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
}
