using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformDoor2 : MonoBehaviour
{
    // private float timer;
    public GameObject aimdoor;
    // Start is called before the first frame update
    void Start()
    {
        // timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // timer = timer + Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if(TransformDoor_Controller.doorTrigger(2)>2.0f) {
            other.gameObject.transform.position = aimdoor.transform.position;
            // timer = 0;
            Debug.Log("Transform2");
        }
    }
}
