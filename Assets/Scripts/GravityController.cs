using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    
    private Vector2 changeFactor = new Vector2(0f, 1.0f);
    private bool gravityToggled = false;
    private Vector2 newGravity;

    public static float curGravityFactor = 1.0f; // 1.0 or -1.0;
    private int testNum = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.Q)){
            
            curGravityFactor *= -1.0f;
            //newGravity = Physics2D.gravity *changeFactor * curGravityDir;
            Physics2D.gravity = Physics2D.gravity  *curGravityFactor;
            Debug.Log("Gravity toggle executed");
            Debug.Log("cur grav dir"+ curGravityFactor+ "; Grvity:" + Physics2D.gravity);
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
        return curGravityFactor;
    }
}
