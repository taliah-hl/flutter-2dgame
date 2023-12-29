using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryToEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Story1;
    public GameObject Story2;
    public GameObject Story3;
    public GameObject Story4;
    public GameObject Story5;
    public GameObject Story6;
    public GameObject Story7;
    public GameObject Story8;
    public GameObject Story9;
    public GameObject Story10;
    public GameObject StoryObj;
    private FadeInImage fadeInImage;
    void Start()
    {
        fadeInImage = FindObjectOfType<FadeInImage>();
        StartCoroutine(LoadImage());
    }
    IEnumerator LoadImage()
    {
        yield return new WaitForSecondsRealtime(9);
        fadeInImage.Fade_Out(Story1.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story1.SetActive(false);
        yield return new WaitForSecondsRealtime(5);
        fadeInImage.Fade_Out(Story2.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story2.SetActive(false);
        yield return new WaitForSecondsRealtime(11);
        fadeInImage.Fade_Out(Story3.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story3.SetActive(false);
        yield return new WaitForSecondsRealtime(13);
        fadeInImage.Fade_Out(Story4.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story4.SetActive(false);
        yield return new WaitForSecondsRealtime(5);
        fadeInImage.Fade_Out(Story5.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story5.SetActive(false);
        yield return new WaitForSecondsRealtime(9);
        fadeInImage.Fade_Out(Story6.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story6.SetActive(false);
        yield return new WaitForSecondsRealtime(5);
        fadeInImage.Fade_Out(Story7.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story7.SetActive(false);
        yield return new WaitForSecondsRealtime(7);
        fadeInImage.Fade_Out(Story8.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story8.SetActive(false);
        yield return new WaitForSecondsRealtime(6);
        fadeInImage.Fade_Out(Story9.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story9.SetActive(false);
        yield return new WaitForSecondsRealtime(5);
        fadeInImage.Fade_Out(Story10.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Story10.SetActive(false);
        yield return new WaitForSecondsRealtime(6);
        SceneManager.LoadScene("player_story_end");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
