using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDropDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("delete", 1.8f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y>=10.9f) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer==3) {
            Destroy(gameObject, 0.1f);
        }
        
    }

    void delete() {
        Destroy(gameObject);
    }
}
 