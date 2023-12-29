using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeControl : MonoBehaviour
{
    private GameObject gameObj;

    private Animator animator;
    private float player_pos_upBound = 11.29f;  //11.68
    private float player_pos_lowBound = -11.29f;
    private float changeScenePause = 1.5f;        // pause time before change scene or die
    //public float player_pos_leftBound;  //not in use yet
    //public float player_pos_rightBound;     //not in use yet
    private GameManager gm;
    private const int PlayerDieFunc = 1;
    private const int PlayerGoNextLvFunc = 2;
    private static PlayerLifeControl instance = null;
    public GameObject FinishCanvas;
    private bool player_die = false;
    public AudioSource SoundEffect;
    public AudioClip nextLv;
    public AudioClip die;
    public bool DieAudioPlayed = false;
    public GameObject Chpt4EndStory;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        DieAudioPlayed = false;
        SoundEffect = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
        if (gameObj == null)
            gameObj = GameObject.FindWithTag("Player");

        gm = FindObjectOfType<GameManager>();
        if (gm == null)
        {
            Debug.LogWarning("GameManager not got from FindObjectOfType<GameManager>()");
        }
        else
        {
            Debug.Log("GameManager is found by playerLifeControl");
        }

        animator = GetComponent<Animator>();
        animator.SetBool("die", false);
        player_die = false;

    }

    // Update is called once per frame
    void Update()
    {
        CheckFallOutside();
        if (instance.animator.GetCurrentAnimatorStateInfo(0).IsName("die_down") || instance.animator.GetCurrentAnimatorStateInfo(0).IsName("die_up"))
        {
            //     instance.Invoke("call_pause", instance.animator.GetCurrentAnimatorStateInfo(0).length);
            call_pause();
        }

    }
    IEnumerator EndStory()
    {
        FinishCanvas.SetActive(true);
        gm.Pause();
        SoundEffect.PlayOneShot(nextLv);
        yield return new WaitForSecondsRealtime(1);
        FinishCanvas.SetActive(false);
        Chpt4EndStory.SetActive(true);
    }
    void SaveCurrentLv(int lv)
    {
        PlayerPrefs.SetInt("CurrentLv", lv);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "end")
        {
            if (SceneManager.GetActiveScene().name == "ch4-3")
            {
                StartCoroutine(EndStory());
                SaveCurrentLv(43);
            }
            else
            {
                Debug.Log("go to next level");
                gm.pauseGame(changeScenePause); // call pauseGame in GameManager
                Debug.Log(SceneManager.GetActiveScene().name);
                switch (SceneManager.GetActiveScene().name)
                {
                    
                    case "tutor-lv":
                        if (PlayerPrefs.GetInt("CurrentLv") < 11)
                        {
                            SaveCurrentLv(11);
                        }
                        break;

                    case "ch1-1": 
                    case "CH1-1":
                    case "ch1-1_nointro":
                        if (PlayerPrefs.GetInt("CurrentLv") < 12)
                        {
                            SaveCurrentLv(12);
                        }
                        break;
                    case "ch1-2": 
                    case "CH1-2":
                        if (PlayerPrefs.GetInt("CurrentLv") < 13)
                        {
                            SaveCurrentLv(13);
                        }
                        break;
                    case "ch1-3": case "CH1-3":
                        if (PlayerPrefs.GetInt("CurrentLv") < 21)
                        {
                            SaveCurrentLv(21);
                        }
                        break;
                    case "ch2-1": case "CH2-1":
                    case "ch2-1_nointro":
                        if (PlayerPrefs.GetInt("CurrentLv") < 22)
                        {
                            SaveCurrentLv(22);
                        }
                        break;
                    case "ch2-2": case "CH2-2":
                        if (PlayerPrefs.GetInt("CurrentLv") < 23)
                        {
                            SaveCurrentLv(23);
                        }
                        break;
                    case "ch2-3": case "CH2-3":
                        if (PlayerPrefs.GetInt("CurrentLv") < 31)
                        {
                            SaveCurrentLv(31);
                        }
                        break;
                    case "ch3-1": case "CH3-1":
                    case "ch3-1_nointro":
                        if (PlayerPrefs.GetInt("CurrentLv") < 32)
                        {
                            SaveCurrentLv(32);
                        }
                        break;
                    case "ch3-2": case"CH3-2":
                        if (PlayerPrefs.GetInt("CurrentLv") < 33)
                        {
                            SaveCurrentLv(33);
                        }
                        break;
                    case "ch3-3": case "CH3-3":
                        if (PlayerPrefs.GetInt("CurrentLv") < 41)
                        {
                            SaveCurrentLv(41);
                        }
                        break;
                    case "ch4-1": case "CH4-1":
                    case "ch4-1_nointro":
                        if (PlayerPrefs.GetInt("CurrentLv") < 41)
                        {
                            SaveCurrentLv(42);
                        }
                        break;
                    case "ch4-2": case "CH4-2":
                        if (PlayerPrefs.GetInt("CurrentLv") < 43)
                        {
                            SaveCurrentLv(43);
                        }
                        break;
                }
                StartCoroutine(waitForGmPause(PlayerGoNextLvFunc));
            }
        }
        if (other.tag == "trap")
        {

            Debug.Log("player triggerEnter with trap: " + other.gameObject.name);

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
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "lava")
        {
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

            Debug.Log("player collide with trap: " + other.gameObject.name);

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

        //these are not useful now
        // change to detect in ClooudDetec of GroundDector under player
        // if (other.gameObject.tag == "cloud"){
        //     Debug.Log("player collide with cloud, gravity scale changed to 1");

        //     _playersRigidBody.gravityScale = 1;
        // }
        // if (other.gameObject.tag == "cloud05"){
        //     Debug.Log("player collide with cloud05, gravity scale changed to 0.5");

        //     _playersRigidBody.gravityScale = 0.5f;
        // }

    }

    // void OnCollisionExit2D(Collision2D other){
    //     if (other.gameObject.tag == "cloud" || other.gameObject.tag == "cloud05"){
    //         Debug.Log("player exit cloud, gravity scale back to normal");
    //         _playersRigidBody.gravityScale = playerNormalGravScale;
    //     }
    // }
    public static void player_die_ani()
    {
        instance.player_die = true;
        instance.animator.SetBool("die", true);
        instance.animator.SetBool("running", false);
        instance.animator.SetBool("idle", false);
        instance.animator.SetBool("jump", false);
        instance.PlayDyingAudio();
    }
    public void PlayDyingAudio()
    {
        if (!DieAudioPlayed)
        {
            SoundEffect.PlayOneShot(die);
            DieAudioPlayed = true;
        }
    }
    public static bool CheckPlayerDie()
    {
        return instance.player_die;
    }

    void call_pause()
    {
        PauseAndDie();
    }

    public static void PauseAndDie()
    {
        // instance.animator.SetBool("die", true);
        // instance.animator.SetBool("running", false);
        // instance.animator.SetBool("idle", false);
        // instance.animator.SetBool("jump", false);
        //Debug.Log("PlayerLifeControl: PauseAndDie() is called");
        // yield WaitForSeconds(1.2f);
        instance.gm.pauseGame(instance.changeScenePause);  // call pauseGame in GameManager
        instance.StartCoroutine(instance.waitForGmPause(PlayerDieFunc));


        // instance.StartCoroutine(instance.waitForGmPause(instance.animator.GetCurrentAnimatorStateInfo(0).length));

        //fix error: Assets\Scripts\PlayerLifeControl.cs(103,9): error CS0120: An object reference is required for the non-static field, method, or property 'MonoBehaviour.StartCoroutine(IEnumerator)'

    }

    void CheckFallOutside()
    {
        if (gameObj.transform.position.y <= player_pos_lowBound - 2 || gameObj.transform.position.y >= player_pos_upBound + 2)
        {

            // PauseAndDie();
            // Invoke("PlayerDie", 1.0f);
            Debug.Log("player die since fall outside");
            call_pause();
        }
    }

    public void PlayerDie()
    {
        Debug.Log("PlayerLifeControl: PlayerDie() is called");
        Destroy(instance.gameObj);
        gm.GameOver();
    }

    private void PlayerGoNextLv()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //gameObj.GetComponent<GravityController>().ResetGravity();
    }

    private void testDetect()
    {
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
    IEnumerator waitForGmPause(int funcToCall)
    {     //delay function when timeScale==0
        while (Time.timeScale != 1.0f)
            yield return null;
        if (funcToCall == PlayerGoNextLvFunc)
        {
            FinishCanvas.SetActive(true);
            gm.pauseGame(1f);
            SoundEffect.PlayOneShot(nextLv);
            yield return new WaitForSecondsRealtime(1);
            FinishCanvas.SetActive(false);
            PlayerGoNextLv();
        }
        else if (funcToCall == PlayerDieFunc)
        {
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
