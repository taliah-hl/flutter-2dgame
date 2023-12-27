using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndLoad : MonoBehaviour
{
    public static int CurrentLv;
    public GameObject MainMenu;
    public GameObject HelpMenu;
    public GameObject PlayMenu;
    public GameObject Ch2Lock;
    public GameObject Ch3Lock;
    public GameObject Ch4Lock;
    public Button Ch2;
    public Button Ch3;
    public Button Ch4;
    void Start()
    {
        MainMenu = GameObject.Find("MainMenu");
    }
    public void Load()
    {
        CurrentLv = 21;
        MainMenu.SetActive(false);
        PlayMenu.SetActive(true);

        if (CurrentLv == 0)
        {
            //MainMenu.SetActive(false);
            //HelpMenu.SetActive(true);
        }
        else if (CurrentLv < 21) 
        {
            Ch2Lock.SetActive(true);
            Ch3Lock.SetActive(true);
            Ch4Lock.SetActive(true);
            Ch2.interactable = false;
            Ch3.interactable = false;
            Ch4.interactable = false;
        }
        else if (CurrentLv >= 21 && CurrentLv < 31)
        {
            Ch2Lock.SetActive(false);
            Ch3Lock.SetActive(true);
            Ch4Lock.SetActive(true);
            Ch2.interactable = true;
            Ch3.interactable = false;
            Ch4.interactable = false;
        }
    }
    public void Save(int lv)
    {
        PlayerPrefs.SetInt("CurrentLv", lv);
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("CurrentLv", 0);
    }
}
