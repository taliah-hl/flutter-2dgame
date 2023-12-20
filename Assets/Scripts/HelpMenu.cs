using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpMenu : MonoBehaviour
{
    public Scene curScene;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        curScene = SceneManager.GetActiveScene();
        Debug.Log(curScene.name);
        switch (curScene.name)
        {
            case "ch1-1": case "ch2-1": case "ch3-1" : case "ch4-1":
                gm.SetGamePaused();
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
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
