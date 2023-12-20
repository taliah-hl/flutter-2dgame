using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GravityDisplay : MonoBehaviour
{
    public TextMeshProUGUI GravityCntText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GravityCntText.text = "Toggle left: "+ GravityController.GravToggleLeft;
    }
}
