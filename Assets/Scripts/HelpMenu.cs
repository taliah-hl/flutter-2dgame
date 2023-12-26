using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HelpMenu : MonoBehaviour
{
    public Scene curScene;
    public Button HelpBtn;
    public Button RetryBtn;
    public Button QuitBtn;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {   
        GetButton();
        gm = FindObjectOfType<GameManager>();
        curScene = SceneManager.GetActiveScene();
        Debug.Log(curScene.name);
        switch (curScene.name)
        {
            case "ch1-1": case "ch2-1": case "ch3-1" : case "ch4-1":
                gm.SetGamePaused();
                DisableButton();
                Pause();
                break;
            default:
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
        GetButton();
        Time.timeScale = 0f;
        DisableButton();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        EnableButton();
    }
    public void DisableButton()
    {
        RetryBtn.interactable = false;
        HelpBtn.interactable = false;
        QuitBtn.interactable = false;
    }
    public void EnableButton()
    {
        RetryBtn.interactable = true;
        HelpBtn.interactable = true;
        QuitBtn.interactable = true;
    }

    public void GetButton()
    {
        HelpBtn = GameObject.Find("HelpBtn").GetComponent<Button>();
        RetryBtn = GameObject.Find("retryBtn").GetComponent<Button>();
        QuitBtn = GameObject.Find("QuitBtn").GetComponent<Button>();
    }
}
