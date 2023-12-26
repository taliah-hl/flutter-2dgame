using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDetect : MonoBehaviour
{
    private GameObject gameObj;
    private Rigidbody2D _playersRigidBody;
    private float playerNormalGravScale;
    private static bool isPlayerOnCloud = false;
    //create a get function for isPlayerOnCloud
    public static bool IsPlayerOnCloud{
        get {return isPlayerOnCloud;}
    }


    void Start()
    {
        if(gameObj==null)
            gameObj =  GameObject.FindWithTag("PlayerRb");
        _playersRigidBody = gameObj.GetComponent<Rigidbody2D>();
        playerNormalGravScale= _playersRigidBody.gravityScale;
        if(_playersRigidBody==null)
            Debug.Log("player rigid body not found");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){

        
        if (other.tag == "cloud"){
            isPlayerOnCloud = true;
            Debug.Log("player collide with cloud, gravity scale changed to 1");
           
            _playersRigidBody.gravityScale = 1;
        }
        if (other.tag == "cloud05"){
            isPlayerOnCloud = true;
            Debug.Log("player collide with cloud05, gravity scale changed to 0.5");
       
            _playersRigidBody.gravityScale = 0.5f;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        
        if (other.gameObject.tag == "cloud" || other.gameObject.tag == "cloud05"){
            isPlayerOnCloud = false;
            Debug.Log("player exit cloud, gravity scale back to normal");
            _playersRigidBody.gravityScale = playerNormalGravScale;
        }
    }


}
