using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndImage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Img;
    private FadeInImage fadeInImage;
    void Start()
    {
        StartCoroutine(LoadImage());
        fadeInImage = FindObjectOfType<FadeInImage>();
    }
    IEnumerator LoadImage()
    {
        yield return new WaitForSecondsRealtime(6);
        Img.SetActive(true);
        fadeInImage.Fade_In(Img.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(8);
        fadeInImage.Fade_Out(Img.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}