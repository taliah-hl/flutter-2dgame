using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallRigidControll : MonoBehaviour
{
    private bool rigidon = false;
    
    private void Awake() {
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Fall rigid collisionEnter with "+other.gameObject.tag);
        if((other.gameObject.tag=="Player"  || other.gameObject.tag=="PlayerRb") && !rigidon) {
            // UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(gameObject, "Assets/Scripts/FallRigidControll.cs (22,13)", "RigidBody2D");
            Invoke("AddRigid", 2);
        }
        
    }

    void AddRigid() {
        gameObject.AddComponent<Rigidbody2D>();
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}




