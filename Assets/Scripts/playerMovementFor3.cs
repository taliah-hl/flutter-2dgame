using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//movement for ch3 inherit from playermovement_noanimator (default)
public class playerMovementFor3  : PlayerMovement_NoAnimator

{

    
    protected override void Start()
    {
        base.Start(); // This will call the Start method of PlayerMovement_NoAnimator
        // _playersRigidBody now contains the Rigidbody2D attached to the same GameObject as this script
        if(animator == null){
            Debug.Log("Potential Error: animator of playerMovementFor3 is null!!");
        }
        if(_playersRigidBody == null){
            Debug.Log("Potential Error:rigidbody of playerMovementFor3 is null!!");
        }
        if(sprite == null){
            Debug.Log("Potential Error:sprite of playerMovementFor3 is null!!");
        }
        if(gravityController == null){
            Debug.Log("Potential Error:gravityController of playerMovementFor3 is null!!");
        }
    }


    // Update is called once per frame
    protected override void Update()
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
                    _playersRigidBody.velocity = new Vector2(dir_x, PlayerJumpingForce) * gravityController.GetCurGrav();

                    ToggleTileWhenJump();
                }
                else{
                    Debug.Log("not jumped cuz isGround is false");
                }
            }
        }
        AnimationUpdate();

    }

    void ToggleTileWhenJump() {
        GameManager_3.ToggleTiles();
        _playersRigidBody.velocity = new Vector2(dir_x, PlayerJumpingForce) * gravityController.GetCurGrav();
    }

    

}

