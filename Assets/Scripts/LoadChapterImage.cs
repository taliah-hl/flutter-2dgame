using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class LoadChapterImage : MonoBehaviour
{
    public GameObject ChptImg;
    void Start()
    {
        Debug.Log("Start");
        StartCoroutine(LoadImage());
    }
    IEnumerator LoadImage()
    {
        ChptImg.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        ChptImg.SetActive(false);
    }
    
}
