using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadChapter1_1()
    {
        SceneManager.LoadScene("ch1-1_nointro");
    }

    public void LoadChapter1_2()
    {
        SceneManager.LoadScene("ch1-2");
    }
    public void LoadChapter1_3()
    {
        SceneManager.LoadScene("ch1-3");
    }
    public void LoadChapter2_1()
    {
        SceneManager.LoadScene("ch2-1_nointro");
    }
    public void LoadChapter2_2()
    {
        SceneManager.LoadScene("ch2-2");
    }
    public void LoadChapter2_3()
    {
        SceneManager.LoadScene("ch2-3");
    }
    public void LoadChapter3_1()
    {
        SceneManager.LoadScene("ch3-1_nointro");
    }
    public void LoadChapter3_2()
    {
        SceneManager.LoadScene("ch3-2");
    }
    public void LoadChapter3_3()
    {
        SceneManager.LoadScene("ch3-3");
    }
    public void LoadChapter4_1()
    {
        SceneManager.LoadScene("ch4-1_nointro");
    }
    public void LoadChapter4_2()
    {
        SceneManager.LoadScene("ch4-2");
    }
    public void LoadChapter4_3()
    {
        SceneManager.LoadScene("ch4-3");
    }
}
