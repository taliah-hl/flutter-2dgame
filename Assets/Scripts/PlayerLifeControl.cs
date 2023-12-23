using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeControl : MonoBehaviour
{
    public GameObject gameObj;
    public GameObject ChptFinishedImg;
    private Rigidbody2D _playersRigidBody;
    private Animator animator;
    [SerializeField] private float player_pos_upBound = 14;
    [SerializeField] private float player_pos_lowBound = -12;
    [SerializeField] private float changeScenePause = 0.5f;        // pause time before change scene or die
    //public float player_pos_leftBound;  //not in use yet
    //public float player_pos_rightBound;     //not in use yet
    private GameManager gm;
    private const int PlayerDieFunc = 1;
    private const int PlayerGoNextLvFunc = 2;
    private static PlayerLifeControl instance = null;
    private float playerNormalGravScale;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        if(gameObj==null)
            gameObj =  GameObject.FindWithTag("Player");
        _playersRigidBody = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
        if (gm == null) {
            Debug.LogWarning("GameManager not got from FindObjectOfType<GameManager>()");
        }
        else{
            Debug.Log("GameManager is found by playerLifeControl");
        }
        playerNormalGravScale = _playersRigidBody.gravityScale;
        animator = GetComponent<Animator>();
        animator.SetBool("die", false);
             

    }

    // Update is called once per frame
    void Update()
    {
        CheckFallOutside();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.tag == "end")
        {
           if (SceneManager.GetActiveScene().name == "ch4-3")
            {
                StartCoroutine(LoadImage());
            }
            else
            {
                Debug.Log("go to next level");
                gm.pauseGame(changeScenePause); // call pauseGame in GameManager
                StartCoroutine(waitForGmPause(PlayerGoNextLvFunc));
            }
        }
        if (other.tag == "trap")
        {
            // animator.SetBool("die", true);
            // animator.SetBool("running", false);
            // animator.SetBool("idle", false);
            // animator.SetBool("jumps", false);
            // Debug.Log("player triggerEnter with trap");
            // if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("die_down") || this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("die_up")) 
            // {

            //     Invoke("PauseAndDie", this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                
            //     // Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            // }
            // PauseAndDie();
            //PlayerDie();
            player_die_ani();
        }
        if (other.tag == "switchBlockInternal")
        {
            Debug.Log("player triggerEnter with switchBlockInternal");
            // animator.SetBool("die", true);
            // animator.SetBool("running", false);
            // animator.SetBool("idle", false);
            // animator.SetBool("jumps", false);
            // if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("die_down") || this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("die_up")) 
            // {
                
                // Invoke("PauseAndDie", this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                
                // Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            // }
            // PauseAndDie();
            //PlayerDie();
            player_die_ani();
        }
 
    }
    IEnumerator LoadImage()
    {
        ChptFinishedImg.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        ChptFinishedImg.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="lava") {
            // animator.SetBool("die", true);
            // animator.SetBool("running", false);
            // animator.SetBool("idle", false);
            // animator.SetBool("jumps", false);
            // if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("die_down") || this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("die_up")) 
            // {
                
            //     Invoke("PauseAndDie", this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                
            //     // Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            // }
            // PauseAndDie(); //call PlayerDie() after some time
            player_die_ani();
        }
        if (other.gameObject.tag == "trap")
        {
            // animator.SetBool("die", true);
            // animator.SetBool("running", false);
            // animator.SetBool("idle", false);
            // animator.SetBool("jumps", false);
            // Debug.Log("player collide with trap");
            
            // // if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("die_down") || this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("die_up")) 
            // // {
                
            // Invoke("PauseAndDie", 1);
                
                // Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            // }
            player_die_ani();
            // PauseAndDie(); //call PlayerDie() after some time
        }
        if (other.gameObject.tag == "cloud"){
            Debug.Log("player collide with cloud, gravity scale changed to 1");
           
            _playersRigidBody.gravityScale = 1;
        }
        if (other.gameObject.tag == "cloud05"){
            Debug.Log("player collide with cloud05, gravity scale changed to 0.5");
       
            _playersRigidBody.gravityScale = 0.5f;
        }
        
    }
    void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.tag == "cloud" || other.gameObject.tag == "cloud05"){
            Debug.Log("player exit cloud, gravity scale back to normal");
            _playersRigidBody.gravityScale = playerNormalGravScale;
        }
    }

    void player_die_ani() {
        animator.SetBool("die", true);
        animator.SetBool("running", false);
        animator.SetBool("idle", false);
        animator.SetBool("jump", false);
        Invoke("call_pause", 1.0f);
    }

    void call_pause() {
        PauseAndDie();
    }
    public static void PauseAndDie(){
        // instance.animator.SetBool("die", true);
        // instance.animator.SetBool("running", false);
        // instance.animator.SetBool("idle", false);
        // instance.animator.SetBool("jump", false);
        Debug.Log("PlayerLifeControl: PauseAndDie() is called");
        // yield WaitForSeconds(1.2f);
        instance.gm.pauseGame(instance.changeScenePause);  // call pauseGame in GameManager
        instance.StartCoroutine(instance.waitForGmPause(PlayerDieFunc));
        
        
        // instance.StartCoroutine(instance.waitForGmPause(instance.animator.GetCurrentAnimatorStateInfo(0).length));
        
        //fix error: Assets\Scripts\PlayerLifeControl.cs(103,9): error CS0120: An object reference is required for the non-static field, method, or property 'MonoBehaviour.StartCoroutine(IEnumerator)'
        
    }

    void CheckFallOutside()
    {
        if (gameObj.transform.position.y <= player_pos_lowBound-2 || gameObj.transform.position.y >=player_pos_upBound+2 )
        {
            
            // PauseAndDie();
            // Invoke("PlayerDie", 1.0f);
            call_pause();
        }
    }

    public void PlayerDie()
    {
        Debug.Log("PlayerLifeControl: PlayerDie() is called");
        Destroy(instance.gameObj);
        gm.GameOver();
    }

    private void PlayerGoNextLv(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //gameObj.GetComponent<GravityController>().ResetGravity();
    }

    private void testDetect(){
        gm.pauseGame(5.0f);
    }

    // IEnumerator waitForGmPause(int funcToCall){     //delay function when timeScale==0
    //     while(Time.timeScale !=1.0f)
    //         yield return null;
    //     if (funcToCall == PlayerGoNextLvFunc)
    //         PlayerGoNextLv();
    //     else if(funcToCall == PlayerDieFunc)
    //         PlayerDie();
    //     yield break;
        
    // }
    IEnumerator waitForGmPause(int funcToCall){     //delay function when timeScale==0
        while(Time.timeScale != 1.0f)
            yield return null;
        if (funcToCall == PlayerGoNextLvFunc) {
            // yield return new WaitForSeconds(1);
            PlayerGoNextLv();
        }
        else if(funcToCall == PlayerDieFunc) {
            // instance.animator.SetBool("running", false);
            // instance.animator.SetBool("idle", false);
            // instance.animator.SetBool("jump", false);
            // yield return new WaitForSeconds(1.2f);
            // if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("die_down") || this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("die_up")) 
            // {
                // Invoke("PlayerDie", this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            // }
            Debug.Log("call PauseAndDie()");
            PlayerDie();
        }
        yield break;
        
    }


}
