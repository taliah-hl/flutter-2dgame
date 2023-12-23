using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverCreate : MonoBehaviour
{
    public GameObject Cover;
    private bool protect;
    private Animator animator;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        protect = false;
        timer = 0.0f;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(protect) {
            timer += Time.deltaTime;
            if(timer>10.0f) {
                protect = false;
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="cover_point") {
            protect = true;
            timer = 0.0f;
            // PoisonDisable.PTrigger();
            Destroy(other.gameObject);
            GameObject c = GameObject.Instantiate(Cover, transform.position, Quaternion.identity);
                    //设置父子关系
            c.transform.SetParent(transform);
        }
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag=="poison" && !protect) {
            // animator.SetBool("die", true);
            // animator.SetBool("running", false);
            // animator.SetBool("idle", false);
            // animator.SetBool("jumps", false);
            // if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("die_down") || this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("die_up")) 
            // {
                
            //     Invoke("PlayerLifeControl.PauseAndDie()", this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                
            //     // Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            // }
            PlayerLifeControl.PauseAndDie();
        }
        
    }
}
