using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    
    private Vector2 changeFactor = new Vector2(0f, 1.0f);
    private bool gravityToggled = false;
    private Vector2 newGravity;
    private GameManager gm;

    public static float curGravityDir = 1.0f; // 1.0 or -1.0;
    public static float gravityStrength = 1.0f;   //to control strgnth of gravity
    private int curToggleCnt = 0;
    public int maxGravToggle;

    private static int gravToggleLeft;
    public static int GravToggleLeft{
        get {return gravToggleLeft;}
    }

    
    // Start is called before the first frame update
    void Awake(){
        ResetGravity();
        curToggleCnt=0;
         
    }
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        if (gm == null) {
            Debug.LogWarning("GameManager not got by GravityController!");
        }
        maxGravToggle = SceneSpec.MaxGravToggle;
        gravToggleLeft = maxGravToggle - curToggleCnt;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Q) && !gm.getIsGamePause()  ){
            if((curToggleCnt < maxGravToggle)){
                Debug.Log("max toggle cnt: " + maxGravToggle+ "cur toggle cnt: " + curToggleCnt);

                //newGravity = Physics2D.gravity *changeFactor * curGravityDir;
                Physics2D.gravity = Physics2D.gravity  *-1.0f *gravityStrength;
                curGravityDir *= -1.0f;
                Gravity_Change.ToggleBG();
                Debug.Log("Gravity toggle executed");
                Debug.Log("cur grav dir: "+ curGravityDir+ "; Grvity:" + Physics2D.gravity);
                curToggleCnt += 1;
                
            } 
            else{
                Debug.Log("Gravity Toggle cnt execeeded!");
                Debug.Log("max tog: " + maxGravToggle+ "cur tog: " + curToggleCnt);
            }
            gravToggleLeft = maxGravToggle - curToggleCnt;
 
        }
    }

    public void ResetGravity()
    {
        if (Physics2D.gravity.y >= 0)
        {
            Physics2D.gravity *= -1.0f;
            
        }
        curGravityDir = 1.0f;
    }

    public float GetCurGrav(){
        return curGravityDir;
    }
}
