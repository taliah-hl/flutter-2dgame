using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTo21 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Story1;
    public GameObject Story2;
    public GameObject Story3;
    public GameObject Story4;
    public GameObject Story5;
    public GameObject Story6;
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
        yield return new WaitForSecondsRealtime(5);
        fadeInImage.Fade_Out(Story1.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story1.SetActive(false);
        yield return new WaitForSecondsRealtime(8);
        fadeInImage.Fade_Out(Story2.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story2.SetActive(false);
        yield return new WaitForSecondsRealtime(8);
        fadeInImage.Fade_Out(Story3.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story3.SetActive(false);
        yield return new WaitForSecondsRealtime(8);
        fadeInImage.Fade_Out(Story4.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story4.SetActive(false);
        yield return new WaitForSecondsRealtime(5);
        fadeInImage.Fade_Out(Story5.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story5.SetActive(false);
        yield return new WaitForSecondsRealtime(5);
        fadeInImage.Fade_Out(Story6.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story6.SetActive(false);
        yield return new WaitForSecondsRealtime(8);
        fadeInImage.Fade_Out(Story_Img.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        StoryObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
