using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameManager : MonoBehaviour
{
    
    [SerializeField] private string menuSceneName = "Menu-for-test";
    [SerializeField]  string gameOverSceneName = "died";
    public string victorySceneName = "";

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

    private void LoadLatestLevel(){
        //load latest left level (for developer use only)
    }

    private void LoadFirstLevel(){
        // Load ch1.1
    }
}
