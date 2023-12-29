using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformDoor2 : MonoBehaviour
{
    // private float timer;
    public GameObject aimdoor;
    public AudioSource SoundEffect;
    public AudioClip tpSound;
    
    // Start is called before the first frame update
    void Start()
    {
        // timer = 0;
        SoundEffect = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // timer = timer + Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
   {
        Debug.Log("transform2 triggerEnter with " + other.tag);
            if ( (other.tag != "doNotTransfer")) {
                if(TransformDoor_Controller.doorTrigger(2)>2.0f ) {
                    if(other.tag=="Player")
                    {
                        // transform other's parent's position
                        other.gameObject.transform.parent.transform.position = aimdoor.transform.position;
                        SoundEffect.PlayOneShot(tpSound);
                    }
                    else
                    {
                        other.gameObject.transform.position = aimdoor.transform.position;
                    }
               //someGameObj.transform.position = aimdoor.transform.position;
                // timer = 0;
                Debug.Log("Transform2 ");
            }
        }
        
    }
}
