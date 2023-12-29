using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTo31 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Story1;
    public GameObject Story2;
    public GameObject Story3;
    public GameObject StoryObj;
    public GameObject Story_Img;
    private FadeInImage fadeInImage;
    void Start()
    {
        fadeInImage = FindObjectOfType<FadeInImage>();
        StartCoroutine(LoadImage());
    }
    IEnumerator LoadImage()
    {
        yield return new WaitForSecondsRealtime(7);
        fadeInImage.Fade_Out(Story1.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story1.SetActive(false);
        yield return new WaitForSecondsRealtime(7);
        fadeInImage.Fade_Out(Story2.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story2.SetActive(false);
        yield return new WaitForSecondsRealtime(7);
        fadeInImage.Fade_Out(Story3.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story3.SetActive(false);
        yield return new WaitForSecondsRealtime(8);
        fadeInImage.Fade_Out(Story_Img.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        StoryObj.SetActive(false);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
