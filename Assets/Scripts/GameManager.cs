using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameManager : MonoBehaviour    // this is GM for all levels!!
{

    [SerializeField] private string menuSceneName = "Menu";
    [SerializeField] private string gameOverSceneName = "died";
    [SerializeField] private string firstLvSceneName = "Lv2Scene";
    public GameObject BGM;
    public string victorySceneName = "";
    public static bool gamePaused = false;
    public static bool IsGamePaused
    {
        get { return gamePaused; }
    }

    void Awake()
    {
        gamePaused = false;
        Resume();

    }
    void Start()
    {
    }
    public void GetBGM()
    {
        BGM = GameObject.Find("BGM");
    }

    public void KillBGM()
    {
        Destroy(BGM);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ReloadCurScene();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            BackToMainMenu();
        }
    }
    public void pauseGame(float duration)
    {
        if (gamePaused) return;
        Time.timeScale = 0.0f; // stop Time.deltaTime from updating
        StartCoroutine(waitForGamePause(duration));

    }

    IEnumerator waitForGamePause(float duration)
    {
        // yield return new WaitForSecondsRealtime(1.5f);
        gamePaused = true;
        yield return new WaitForSecondsRealtime(duration); // since timeScale set to 0, waitForSeconds will not count
        //but waitForSecondsRealtime is still counting
        Time.timeScale = 1.0f;  //set timeScale back to normal after waited
        gamePaused = false;
    }

    public void ReloadCurScene()
    {
        Debug.Log("GameManager::ReloadCurScene is called");
        Scene curScene = SceneManager.GetActiveScene();
        switch (curScene.name)
        {
            case "ch1-1":
            case "ch2-1":
            case "ch3-1":
            case "ch4-1":
            case "ch4-3":
            case "CH2-1":
            case "CH3-1":
            case "CH4-1":
            case "CH4-3":
                string tmp = curScene.name + "_nointro"; //comment for now as scene is changed
                Debug.Log("GameManager::going to call:" + tmp);
                SceneManager.LoadScene(tmp);
                break;
            default:
                SceneManager.LoadScene(curScene.name);
                break;
        }
    }

    public void PassLevel()
    {

        Scene curScene = SceneManager.GetActiveScene();
        switch (curScene.name)
        {
            case "ch1-1_nointro":
                SceneManager.LoadScene("ch1-2");
                break;
            case "ch2-1_nointro":
                SceneManager.LoadScene("ch2-2");
                break;
            case "ch3-1_nointro":
                SceneManager.LoadScene("ch3-2");
                break;
            case "ch4-1_nointro":
                SceneManager.LoadScene("ch4-2");
                break;
            default:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }

    }
    public void BackToMainMenu()
    {
        Debug.Log("GameManager::BackToMainMenu is called");
        SceneManager.LoadScene(menuSceneName);
    }
    public void GameOver()
    {     //control what happen when player die
        Debug.Log("GameManager::GameOver is called, GameOver will call ReloadCurScene");
        ReloadCurScene();

    }
    public void LoadGameOverScene()
    {     // not in use for now
        Debug.Log("GameManager::GameOver is called");
        SceneManager.LoadScene(gameOverSceneName);
    }
    public void JumpToVictory()
    {
        Debug.Log("GameManager::JumpToVictory is called");
        SceneManager.LoadScene(victorySceneName);
    }

    public void LoadLatestLevel()
    {
        //load latest left level (for developer use only)
        // dont know how to do yet
    }

    public void LoadFirstLevel()
    {
        // Load ch1.1
        Debug.Log("GameManager::LoadFirstLevel is called");
        SceneManager.LoadScene(firstLvSceneName);
    }

    public void testfunc()
    {
        Debug.Log("hi i am gm");
    }

    public bool getIsGamePause()
    {
        return gamePaused;
    }

    public void SetGamePaused()
    {
        Debug.Log("Paused");
        gamePaused = true;
    }

    public void ResetGamePaused()
    {
        Debug.Log("Resumed");
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
