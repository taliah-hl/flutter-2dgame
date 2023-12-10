using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrigger : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player") {
            Debug.Log("cup rotatet triggrt collide with player");
            
            //rotate transform by 90 degree clockwise
            transform.Rotate(0, 0, -90);

        }

        
    }
}
