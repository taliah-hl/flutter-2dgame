using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeControl : MonoBehaviour
{
    public GameObject gameObj;
    private Rigidbody2D _playersRigidBody;
    [SerializeField] private  float player_pos_upBound = 14;
    [SerializeField] private  float player_pos_lowBound = -12;
    //public float player_pos_leftBound;  //not in use yet
    //public float player_pos_rightBound;     //not in use yet

    // Start is called before the first frame update
    void Start()
    {
        if(gameObj==null)
            gameObj =  GameObject.FindWithTag("Player");
        _playersRigidBody = GetComponent<Rigidbody2D>();

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
            //PlayerGoNextLv();

        }
        if (other.tag == "trap")
        {
            PlayerDie();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="lava") {
            PlayerDie();
        }
        
    }

    void CheckFallOutside()
    {
        if (gameObj.transform.position.y <= player_pos_lowBound || gameObj.transform.position.y >=player_pos_upBound )
        {
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        Destroy(gameObj);
        SceneManager.LoadScene("died");
    }

    private void PlayerGoNextLv(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameObj.GetComponent<GravityController>().ResetGravity();
    }
}
