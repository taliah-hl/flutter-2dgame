using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_NoAnimator : MonoBehaviour
{
   // Start is called before the first frame update
    [SerializeField] protected float playerSpeed = 6.0f;
    protected float SpeedWhileJump = 6.0f;

    

    [SerializeField] protected float PlayerJumpingForce = 12.0f;
    [SerializeField] protected LayerMask JumpableGround;




    //private float _playersMovementDirection = 0.0f; //this will give the direction of the players movement.   

    protected GameObject playerGameObj;
    protected Rigidbody2D _playersRigidBody; //reference of the players rigid body.
    protected Animator animator;


    protected Vector2 _moveInput;
    protected float dir_x = 0f;
    protected SpriteRenderer sprite;
    
    protected GravityController gravityController;
    protected GameManager gm;
    protected float jump_duration = 0.0f;
    protected bool jumping = false;
    protected bool speedReduced = false;




    protected virtual void Awake()
    {


    }
    // private void OnEnable(){
    //     _playerActions.Player.Enable(); //Player is name of map
    // }

    // private void OnDisable(){
    //     _playerActions.Player.Disable();//Player is name of map
    // }
    protected virtual void Start()
    {
        playerGameObj = GameObject.FindGameObjectWithTag("Player");
        _playersRigidBody = GetComponent<Rigidbody2D>();
        animator = playerGameObj.GetComponent<Animator>();
        sprite = playerGameObj.GetComponent<SpriteRenderer>();
        gravityController = GetComponent<GravityController>();
        jump_duration = 0.0f;
        jumping = false;
        gm = FindObjectOfType<GameManager>();
        if (gm == null) 
            Debug.Log("GM not found by PlayerMovement");
        
    }



    protected virtual void FixedUpdate()
    {
    }



    // Update is called once per frame
    protected virtual void Update()
    {
        bool gamePaused = GameManager.IsGamePaused;
        if(jumping && jump_duration < 1.5f) {
            jump_duration += Time.deltaTime;
        }
        if(jump_duration >= 1.5f) {
            jump_duration = 0.0f;
            jumping  = false;
        }
        if( !gamePaused){
            dir_x = Input.GetAxisRaw("Horizontal");
            _playersRigidBody.velocity = new Vector2(dir_x * playerSpeed, _playersRigidBody.velocity.y);

            if (Input.GetButtonDown("Jump")){
                
                Debug.Log("Jump pressed");
                if (IsGrounded()){

                    jumping = true;
                    // animator.SetBool("idle", false);
                    animator.SetBool("jump", true);
                    Debug.Log("jumping");
                    tmpReducePlayerSpeed(2.0f, SpeedWhileJump);
                    _playersRigidBody.velocity = new Vector2(dir_x , PlayerJumpingForce) * gravityController.GetCurGrav();
                }
                else{
                    Debug.Log("isGound is false");
                }
            }
        }
        
        AnimationUpdate();
    }

    protected virtual void AnimationUpdate()
    {
        if(!PlayerLifeControl.CheckPlayerDie()) {
            if(IsGrounded()==false && jumping ) {
                animator.SetBool("jump", true);
                // animator.SetBool("idle", true);
                // animator.SetBool("running", false);
            }
            else {
                animator.SetBool("jump", false);
                if (dir_x > 0)
                {
                    
                    animator.SetBool("idle", false);
                    animator.SetBool("running", true);
                    sprite.flipX = false;
                }
                else if (dir_x < 0)
                {
                    // animator.SetBool("jump", false);
                    animator.SetBool("idle", false);
                    animator.SetBool("running", true);

                    sprite.flipX = true;
                }
                else 
                {
                    // animator.SetBool("jump", false);
                    animator.SetBool("running", false);
                    animator.SetBool("idle", true);
                }
            }
        }
    }

    protected virtual bool IsGrounded()
    {
        bool isgounrd;

        //get children of player, name of child is GroundDetector
        
        //  find player's parent's child
        GameObject gd = transform.Find("GroundDetector").gameObject;
        //create a coller and get the collider of the gd
        BoxCollider2D gd_collider = gd.GetComponent<BoxCollider2D>();
        
        //isgounrd = Physics2D.BoxCast(player_collider.bounds.center, player_collider.bounds.size * 1.05f, 0f, Vector2.down, 0f, JumpableGround);
        // change above line to use box collider of ground detector
        isgounrd = Physics2D.BoxCast(gd_collider.bounds.center, gd_collider.bounds.size * 1.05f, 0f, Vector2.down, 0f, JumpableGround);
        //create a box (center, size, rotation)
        return isgounrd;
    }

    public void speedBackToNormal(){
        playerSpeed = 6.0f;
    }
    protected void tmpReducePlayerSpeed(float duration, float value){
        if(speedReduced) return;
        playerSpeed =  value;
        StartCoroutine(waitForReduceSpeed(duration));
    }

    IEnumerator waitForReduceSpeed(float duration){
        speedReduced = true;
        yield return new WaitForSeconds(duration);
        speedBackToNormal();
        speedReduced = false;
    }
    void testingfn(){
        if(Input.GetKeyDown(KeyCode.U)){
            gm.testfunc();
        }
    }
}
