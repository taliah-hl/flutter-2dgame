using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MidCanvasColorFollow : MonoBehaviour
{
   [SerializeField] private Image midBg;
   private Image thisImage;
    void Start()
    {
        thisImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Color32 midBgColor = midBg.color;     // set this object to follow color of midBg
        thisImage.color = midBgColor;
    }
}
