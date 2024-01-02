using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public GameObject HelpMenu;
    public GameObject[] Tutors; // Array to hold tutor game objects
    public GameObject StoryObj;
    public GameObject ChptObj;
    public GameObject ChptImg_Img;
    private FadeInImage fadeInImage;
    private int currentTutorIndex = 0; // To keep track of the current tutor image
    private bool isProcessingImage = false; // Flag to prevent overlap of actions

    void Start()
    {
        fadeInImage = FindObjectOfType<FadeInImage>();
        if (Tutors.Length > 0) // Ensure there is at least one tutor
        {
            StartCoroutine(LoadTutorImage());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isProcessingImage)
        {
            SkipCurrentImage();
        }
    }

    IEnumerator LoadTutorImage()
    {
        while (currentTutorIndex < Tutors.Length)
        {
            Tutors[currentTutorIndex].SetActive(true);
            yield return new WaitForSecondsRealtime(10); // Time for display
            if (!isProcessingImage)
            {
                yield return StartCoroutine(FadeOutAndNext());
            }
        }

        ShowHelpMenuAndChapter();
    }

    private IEnumerator FadeOutAndNext()
    {
        isProcessingImage = true;
        fadeInImage.Fade_Out(Tutors[currentTutorIndex].GetComponent<Image>());
        yield return new WaitForSecondsRealtime(2); // Wait after fading out
        Tutors[currentTutorIndex].SetActive(false);
        currentTutorIndex++;
        isProcessingImage = false;
    }

    private void SkipCurrentImage()
    {
        StopCoroutine(LoadTutorImage());
        if (currentTutorIndex < Tutors.Length)
        {
            StartCoroutine(FadeOutAndNext());
        }
        else
        {
            ShowHelpMenuAndChapter();
        }
    }

    private void ShowHelpMenuAndChapter()
    {
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
}