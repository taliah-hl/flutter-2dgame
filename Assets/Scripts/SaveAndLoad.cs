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
    public GameObject Ch1_2Lock;
    public GameObject Ch1_3Lock;
    public GameObject Ch2_2Lock;
    public GameObject Ch2_3Lock;
    public GameObject Ch3_2Lock;
    public GameObject Ch3_3Lock;
    public GameObject Ch4_2Lock;
    public GameObject Ch4_3Lock;
    public Button Ch1_2;
    public Button Ch1_3;
    public Button Ch2_2;
    public Button Ch2_3;
    public Button Ch3_2;
    public Button Ch3_3;
    public Button Ch4_2;
    public Button Ch4_3;
    void Start()
    {
        MainMenu = GameObject.Find("MainMenu");
    }
    public void Load()
    {
        CurrentLv = PlayerPrefs.GetInt("CurrentLv", 0);
        MainMenu.SetActive(false);

        if (CurrentLv == 0)
        {
            HelpMenu.SetActive(true);
            PlayerPrefs.SetInt("CurrentLv", 11);
        }
        else if (CurrentLv == 11)
        {
            PlayMenu.SetActive(true);
            Ch1_2Lock.SetActive(true);
            Ch1_3Lock.SetActive(true);
            Ch1_2.interactable = false;
            Ch1_3.interactable = false;
            Ch2Lock.SetActive(true);
            Ch3Lock.SetActive(true);
            Ch4Lock.SetActive(true);
        }
        else if (CurrentLv == 12)
        {
            PlayMenu.SetActive(true);
            Ch1_3Lock.SetActive(true);
            Ch1_3.interactable = false;
            Ch2Lock.SetActive(true);
            Ch3Lock.SetActive(true);
            Ch4Lock.SetActive(true);
            Ch2.interactable = false;
            Ch3.interactable = false;
            Ch4.interactable = false;
        }
        else if (CurrentLv == 13)
        {
            PlayMenu.SetActive(true);
            Ch2Lock.SetActive(true);
            Ch3Lock.SetActive(true);
            Ch4Lock.SetActive(true);
            Ch2.interactable = false;
            Ch3.interactable = false;
            Ch4.interactable = false;
        }
        else if (CurrentLv == 21)
        {
            PlayMenu.SetActive(true);
            Ch2_2Lock.SetActive(true);
            Ch2_3Lock.SetActive(true);
            Ch2_2.interactable = false;
            Ch2_3.interactable = false;
            Ch3Lock.SetActive(true);
            Ch4Lock.SetActive(true);
            Ch3.interactable = false;
            Ch4.interactable = false;
        }
        else if (CurrentLv == 22)
        {
            PlayMenu.SetActive(true);
            Ch2_3Lock.SetActive(true);
            Ch2_3.interactable = false;
            Ch3Lock.SetActive(true);
            Ch4Lock.SetActive(true);
            Ch3.interactable = false;
            Ch4.interactable = false;
        }
        else if (CurrentLv == 23)
        {
            PlayMenu.SetActive(true);
            Ch3Lock.SetActive(true);
            Ch4Lock.SetActive(true);
            Ch3.interactable = false;
            Ch4.interactable = false;
        }
        else if (CurrentLv == 31)
        {
            PlayMenu.SetActive(true);
            Ch3_2Lock.SetActive(true);
            Ch3_3Lock.SetActive(true);
            Ch3_2.interactable = false;
            Ch3_3.interactable = false;
            Ch4Lock.SetActive(true);
            Ch4.interactable = false;
        }
        else if (CurrentLv == 32)
        {
            PlayMenu.SetActive(true);
            Ch3_3Lock.SetActive(true);
            Ch3_3.interactable = false;
            Ch4Lock.SetActive(true);
            Ch4.interactable = false;
        }
        else if (CurrentLv == 33)
        {
            PlayMenu.SetActive(true);
            Ch4Lock.SetActive(true);
            Ch4.interactable = false;
        }
        else if (CurrentLv == 41)
        {
            PlayMenu.SetActive(true);
            Ch4_2Lock.SetActive(true);
            Ch4_3Lock.SetActive(true);
            Ch4_2.interactable = false;
            Ch4_3.interactable = false;
        }
        else if (CurrentLv == 42)
        {
            PlayMenu.SetActive(true);
            Ch4_3Lock.SetActive(true);
            Ch4_3.interactable = false;
        }
        else if (CurrentLv == 43)
        {
            PlayMenu.SetActive(true);
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
