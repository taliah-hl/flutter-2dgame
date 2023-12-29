using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInImage : MonoBehaviour
{
    // public Image image;
    public float fadeInTime = 2f;
    public float fadeOutTime = 2f;
    

    private void Start()
    {
        
    }

    public void Fade_In(Image img) {
        StartCoroutine(FadeIn(img));
    }

    IEnumerator FadeIn(Image image)
    {
        float startTime = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup - startTime <= fadeInTime)
        {
            float t = (Time.realtimeSinceStartup - startTime) / fadeInTime;
            Color newColor = new Color(image.color.r, image.color.g, image.color.b, t);
            image.color = newColor;
            yield return null;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }
    public void Fade_Out(Image img) {
        Debug.Log("FadeOut img: "+img.gameObject.name);
        StartCoroutine(FadeOut(img));
    }
    IEnumerator FadeOut(Image image)
    {
        float startTime = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup - startTime <= fadeOutTime)
        {
            float t = 1f - (Time.realtimeSinceStartup - startTime) / fadeOutTime;
            Color newColor = new Color(image.color.r, image.color.g, image.color.b, t);
            image.color = newColor;
            yield return null;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }

    
}