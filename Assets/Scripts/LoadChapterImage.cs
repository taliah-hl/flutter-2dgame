using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class LoadChapterImage : MonoBehaviour
{
    public GameObject ChptImg;
    public GameManager gm;
    void Start()
    {
        Debug.Log("Start");
        StartCoroutine(LoadImage());
    }
    IEnumerator LoadImage()
    {
        ChptImg.SetActive(true);
        gm.pauseGame(5);
        yield return new WaitForSecondsRealtime(5);
        ChptImg.SetActive(false);
    }
    
}
