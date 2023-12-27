using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    
    private Vector2 changeFactor = new Vector2(0f, 1.0f);
    private bool gravityToggled = false;
    private Vector2 newGravity;
    private GameManager gm;
    private Animator animator;
    private GameObject playerGameObj;
    private Rigidbody2D _playersRigidBody;
    public static float curGravityDir = 1.0f; // 1.0 or -1.0;
    private int curToggleCnt = 0;
    private int maxGravToggle;

    private static int gravToggleLeft;
    public static int GravToggleLeft{
        get {return gravToggleLeft;}
    }

    private bool gravReduced = false;
    private float tmpGravFactor = 0.33f;
    private float playerNormalGravScale;
    private Vector2 tmpGrav;   //for record by tmp reduce gravity

    
    // Start is called before the first frame update
    void Awake(){
        ResetGravity();
        curToggleCnt=0;
         
    }
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        if(playerGameObj==null)
            playerGameObj =  GameObject.FindWithTag("Player");
        _playersRigidBody = playerGameObj.GetComponent<Rigidbody2D>();
        if (gm == null) {
            Debug.LogWarning("GameManager not got by GravityController!");
        }
        
        maxGravToggle = SceneSpec.MaxGravToggle;
        gravToggleLeft = maxGravToggle - curToggleCnt;
        animator.SetBool("gravity", true);
        playerNormalGravScale= _playersRigidBody.gravityScale;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Q) && !gm.getIsGamePause()  ){
            if((curToggleCnt < maxGravToggle)){
                Debug.Log("max toggle cnt: " + maxGravToggle+ "cur toggle cnt: " + curToggleCnt);
                if(gravityToggled) {
                    gravityToggled = false;
                    animator.SetBool("gravity", true);
                    Debug.Log("Gravity back!");
                }
                else if(!gravityToggled) {
                    gravityToggled = true;
                    animator.SetBool("gravity", false);
                    Debug.Log("Gravity disabled !");
                }
                //newGravity = Physics2D.gravity *changeFactor * curGravityDir;
                Physics2D.gravity = Physics2D.gravity  *-1.0f;
                curGravityDir *= -1.0f;
                if(! CloudDetect.IsPlayerOnCloud){
                    tmpReducePlayerGravity(1.0f, tmpGravFactor);
                } 
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

    public void tmpReducePlayerGravity(float duration, float factor){
        if(gravReduced) return;
         _playersRigidBody.gravityScale = playerNormalGravScale * factor;
        StartCoroutine(waitForReduceGravity(duration));
       
    }

    

    IEnumerator waitForReduceGravity(float duration){
        // yield return new WaitForSecondsRealtime(1.5f);
        gravReduced = true;
        yield return new WaitForSeconds(duration);
        Debug.Log("in GravityController::waitForReduceGravity, player's gravity scale is: "+ _playersRigidBody.gravityScale);
        //but waitForSecondsRealtime is still counting
        _playersRigidBody.gravityScale = playerNormalGravScale;
        gravReduced = false;
    }
}
