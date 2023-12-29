using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public GameObject HelpMenu;
    public GameObject Tutor1;
    public GameObject Tutor2;
    public GameObject Tutor3;
    public GameObject Tutor4;
    public GameObject Tutor5;
    public GameObject StoryObj;
    //public Animator TutorFade;
    public GameObject ChptObj;
    public GameObject ChptImg_Img;
    private FadeInImage fadeInImage;
    public int flag = 0;
    void Start()
    {
        fadeInImage = FindObjectOfType<FadeInImage>();
        StartCoroutine(LoadTutorImage());
    }

    public void TutorNext()
    {
        StartCoroutine(LoadTutorImage());
        // switch (flag)
        // {
        //     case 0:
        //         Tutor1.SetActive(false);
        //         //TutorFade.Play("Crossfade_End");
        //         flag++;
        //         break;
        //     case 1:
        //         Tutor2.SetActive(false);
        //         //TutorFade.Play("Crossfade_End");
        //         flag++;
        //         break;
        //     case 2:
        //         Tutor3.SetActive(false);
        //         //TutorFade.Play("Crossfade_End");
        //         flag++;
        //         break;
        //     case 3:
        //         Tutor4.SetActive(false);
        //         //TutorFade.Play("Crossfade_End");
        //         flag++;
        //         break;
        //     case 4:
        //         Tutor5.SetActive(false);
        //         //TutorFade.Play("Crossfade_End");
        //         flag++;
        //         break;
        //     case 5:
        //         HelpMenu.SetActive(true);
        //         //TutorFade.Play("Crossfade_End");
        //         StartCoroutine(LoadChptImage());
        //         StoryObj.SetActive(false);
        //         break;
        // }
    }
    IEnumerator LoadTutorImage()
    {
        // fadeInImage.Fade_In(Tutor1.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(5);
        fadeInImage.Fade_Out(Tutor1.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Tutor1.SetActive(false);
        yield return new WaitForSecondsRealtime(8);
        fadeInImage.Fade_Out(Tutor2.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Tutor2.SetActive(false);
        yield return new WaitForSecondsRealtime(8);
        fadeInImage.Fade_Out(Tutor3.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Tutor3.SetActive(false);
        yield return new WaitForSecondsRealtime(8);
        fadeInImage.Fade_Out(Tutor4.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Tutor4.SetActive(false);
        yield return new WaitForSecondsRealtime(5);
        fadeInImage.Fade_Out(Tutor5.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        Tutor5.SetActive(false);
        yield return new WaitForSecondsRealtime(5);
        HelpMenu.SetActive(true);
        StartCoroutine(LoadChptImage());
        StoryObj.SetActive(false);
    }
    IEnumerator LoadChptImage()
    {
        ChptObj.SetActive(true);
        fadeInImage.Fade_In(ChptImg_Img.GetComponent<Image>());
        yield return new WaitForSeconds(8);
        fadeInImage.Fade_Out(ChptImg_Img.GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2);
        ChptObj.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
