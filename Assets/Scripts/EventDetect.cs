using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventDetect : MonoBehaviour
{
    public GameObject gameObj;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObj =  GameObject.Find("Player");
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gameObj.GetComponent<GravityController>().ResetGravity();
            gameObj.transform.position = new Vector3(-8.28f, -2.05f, 0f);
        }
        if (other.tag == "trap")
        {
            Died();
        }
    }

    void CheckFallOutside()
    {
        if (gameObj.transform.position.y <= -4.0f)
        {
            Died();
        }
    }

    void Died()
    {
        Destroy(gameObj);
        SceneManager.LoadScene("died");
    }
}
