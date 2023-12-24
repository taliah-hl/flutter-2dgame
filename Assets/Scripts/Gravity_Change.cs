using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gravity_Change : MonoBehaviour
{
    [SerializeField]
    private Image midBg;
    [SerializeField]
    private Image outerBg;
    [SerializeField] 
    private Image downArrow;
    [SerializeField] 
    private Image upArrow;

    public bool gravitydown;

    private static Gravity_Change instance = null;

    //       ----      Colour Code     ------       //
    // purple Color32( 69, 45, 102, 200 );
    // palepurple = new Color32( 207, 197, 237, 200 );
    //dark orange = new Color32( 187, 92, 34, 200 );
    // light orange = new Color32( 238, 153, 102, 200 );

    // private Color cup = new Color32( 173, 173, 173, 200 );
    // private Color cdown = new Color32( 0, 0, 0, 200 );

    private void Awake() {
        Debug.Log("Gravity_Change is attached to "+gameObject.name);
        instance = this;
        Down();
    }

    public void Down(){
        midBg.color = new Color32( 69, 45, 102, 255 ); //purple
        outerBg.color = new Color32( 207, 197, 237, 255 );   //pale purple
        downArrow.enabled = true;
        upArrow.enabled = false;

        gravitydown = true;
        Debug.Log("Gravity dir indicator in sidebar changed to up");
    }

    public void UP(){
        midBg.color = new Color32( 187, 92, 34, 255 );
        outerBg.color = new Color32( 238, 153, 102, 255 );
        downArrow.enabled = false;
        upArrow.enabled = true;
        gravitydown = false;
        Debug.Log("Gravity dir indicator in sidebar changed to down");
    }

    public void Toggle(){
        if(gravitydown) UP();
        else Down();
    }

    public static void ToggleBG(){
        Debug.Log("Gravity_Change::ToggleBG is called");
        instance.Toggle();
    }

    public static void Restart(){
        instance.Down();
    }
}