using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformDoor1 : MonoBehaviour
{

    private float timer;
    public GameObject aimdoor;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if(TransformDoor_Controller.doorTrigger(1)>2.0f && other.tag != "doNotTransfer") {
            other.gameObject.transform.position = aimdoor.transform.position;
            // timer = 0;
            Debug.Log("Transform1");
        }
    }
}
