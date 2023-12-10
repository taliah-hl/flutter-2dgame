using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeControl : MonoBehaviour
{
    public GameObject gameObj;
    private Rigidbody2D _playersRigidBody;
    [SerializeField] private float player_pos_upBound = 14;
    [SerializeField] private float player_pos_lowBound = -12;
    [SerializeField] private float changeScenePause = 1.5f;        // pause time before change scene or die
    //public float player_pos_leftBound;  //not in use yet
    //public float player_pos_rightBound;     //not in use yet
    private GameManager gm;
    private const int PlayerDieFunc = 1;
    private const int PlayerGoNextLvFunc = 2;
    private static PlayerLifeControl instance = null;

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

            Debug.Log("go to next level");
            gm.pauseGame(changeScenePause); // call pauseGame in GameManager
            StartCoroutine(waitForGmPause(PlayerGoNextLvFunc));

        }
        if (other.tag == "trap")
        {
            Debug.Log("player triggerEnter with trap");
            gm.pauseGame(changeScenePause);
            StartCoroutine(waitForGmPause(PlayerDieFunc));
            //PlayerDie();
        }
 
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="lava") {
            StartCoroutine(waitForGmPause(PlayerDieFunc));  //call PlayerDie() after some time
        }
        if (other.gameObject.tag == "trap")
        {
            Debug.Log("player collide with trap");
            gm.pauseGame(changeScenePause);
            StartCoroutine(waitForGmPause(PlayerDieFunc)); //call PlayerDie() after some time
            
        }
        
    }

    void CheckFallOutside()
    {
        if (gameObj.transform.position.y <= player_pos_lowBound || gameObj.transform.position.y >=player_pos_upBound )
        {
            gm.pauseGame(changeScenePause);
            StartCoroutine(waitForGmPause(PlayerDieFunc));
            //PlayerDie();
        }
    }

    public static void PlayerDie()
    {
        Destroy(instance.gameObj);
        instance.gm.GameOver();
    }

    private void PlayerGoNextLv(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //gameObj.GetComponent<GravityController>().ResetGravity();
    }

    private void testDetect(){
        gm.pauseGame(5.0f);
    }

    IEnumerator waitForGmPause(int funcToCall){     //delay function when timeScale==0
        while(Time.timeScale !=1.0f)
            yield return null;
        if (funcToCall == PlayerGoNextLvFunc)
            PlayerGoNextLv();
        else if(funcToCall == PlayerDieFunc)
            PlayerDie();
        yield break;
        
    }


}
