using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    
    private Vector2 changeFactor = new Vector2(0f, 1.0f);
    private bool gravityToggled = false;
    private Vector2 newGravity;

    public static float curGravityDir = 1.0f; // 1.0 or -1.0;
    public static float gravityStrength = 1.0f;   //to control strgnth of gravity

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.Q)){
            
            
            //newGravity = Physics2D.gravity *changeFactor * curGravityDir;
            Physics2D.gravity = Physics2D.gravity  *-1.0f *gravityStrength;
            curGravityDir *= -1.0f;
            Gravity_Change.ToggleBG();
            Debug.Log("Gravity toggle executed");
            Debug.Log("cur grav dir: "+ curGravityDir+ "; Grvity:" + Physics2D.gravity);
        }
        
    }

    public void ResetGravity()
    {
        if (Physics2D.gravity.y >= 0)
        {
            Physics2D.gravity *= -1.0f;
            
        }
    }

    public float GetCurGrav(){
        return curGravityDir;
    }
}
