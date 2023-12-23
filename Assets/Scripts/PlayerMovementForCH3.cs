using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementForCH3 : MonoBehaviour
{
   // Start is called before the first frame update
    [SerializeField] private float PlayersMovementSpeed = 10.0f;
    [SerializeField] private float PlayerJumpingForce = 16.0f;
    [SerializeField] private float BoxCast_y_offset = .5f;
    [SerializeField] private LayerMask JumpableGround;
    private float jump_duration = 0.0f;
    private bool jumping = false;



    //private float _playersMovementDirection = 0.0f; //this will give the direction of the players movement.   

    private Rigidbody2D _playersRigidBody; //reference of the players rigid body.
    private Animator animator;

    private Vector2 _moveInput;
    private float dir_x = 0f;
    private SpriteRenderer sprite;
    private BoxCollider2D player_collider;
    private GravityController gravityController;
    private GameManager gm;




    void Awake()
    {


    }
    // private void OnEnable(){
    //     _playerActions.Player.Enable(); //Player is name of map
    // }

    // private void OnDisable(){
    //     _playerActions.Player.Disable();//Player is name of map
    // }
    private void Start()
    {
        _playersRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player_collider = GetComponent<BoxCollider2D>();
        gravityController = GetComponent<GravityController>();
        jump_duration = 0.0f;
        jumping = false;
        gm = FindObjectOfType<GameManager>();
        if (gm == null) 
            Debug.Log("GM not found.");
        else Debug.Log("GM is found by PlayerMovementForCH3.");


    }



    private void FixedUpdate()
    {
    }



    // Update is called once per frame
    void Update()
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
            _playersRigidBody.velocity = new Vector2(dir_x * PlayersMovementSpeed, _playersRigidBody.velocity.y);

            if (Input.GetButtonDown("Jump")){
                Debug.Log("Jump pressed");
                if (IsGrounded())
                {
                    // ch3_game_manager.ToggleTiles();
                    // _playersRigidBody.velocity = new Vector2(dir_x, PlayerJumpingForce) * gravityController.GetCurGrav();
                    Jump();
                }
            }
        }
        
        
        //AnimationUpdate();
        

    }

    void AnimationUpdate()
    {
        if(IsGrounded()==false && jumping) {
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

    void Jump() {
        ch3_game_manager.ToggleTiles();
        jumping = true;
        
        animator.SetBool("jump", true);
        Debug.Log("jumping");
        _playersRigidBody.velocity = new Vector2(dir_x, PlayerJumpingForce) * gravityController.GetCurGrav();
    }

    private bool IsGrounded()
    {
        bool isgounrd;
        isgounrd = Physics2D.BoxCast(player_collider.bounds.center, player_collider.bounds.size * 1.05f, 0f, Vector2.down, 0f, JumpableGround);
        //create a box (center, size, rotation)
        Debug.Log("is ground is:" + isgounrd);
        return isgounrd;
    }
    void testingfn(){
        if(Input.GetKeyDown(KeyCode.U)){
            gm.testfunc();
        }
    }
}
