using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
public class GameManager_3 : MonoBehaviour
{
    [System.Serializable]
    private struct Tiles{
        [SerializeField]
        private Tilemap tilemap;
        [SerializeField]
        private Rigidbody2D rigidbody;
        public bool isEnabled => rigidbody.simulated;
        public void Enable(){
            Color c = tilemap.color;
            c.a = 1;
            tilemap.color = c;
            rigidbody.simulated = true;

            Debug.Log(c.a);
            Debug.Log(rigidbody.simulated);
        }
        public void Disable(){
            Color c = tilemap.color;
            c.a = 0.5f;
            
            tilemap.color = c;
            rigidbody.simulated = false;

            Debug.Log(c.a);
            Debug.Log(rigidbody.simulated);
        }
        public void Toggle(){
            if(isEnabled) Disable();
            else Enable();
        }
    }
    [SerializeField]
    private Tiles blueTiles, pinkTiles;
    [SerializeField]
    // private ImageFade imageFade;
    // private static float timer;
    // private static bool the_first_transform = true;
    private static GameManager_3 instance = null;
    private void Awake() {
        instance = this;
        // timer = 0;
        blueTiles.Disable();
        pinkTiles.Enable();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void Start() {
        // imageFade.SetColor(Color.black);
        // imageFade.StartFade(Color.clear, 1.0f);
    }
    public static void ToggleTiles(){
        Debug.Log("switch");
        instance.blueTiles.Toggle();
        instance.pinkTiles.Toggle();
        // blueTiles.Toggle();
    }

    // public static float doorTrigger() {
    //     float return_time;
    //     if(the_first_transform) {
    //         return_time = 5.0f;
    //         timer = 0;
    //         the_first_transform = false;
    //     }
    //     else {
    //         return_time = timer;
    //         if(timer > 3.0) timer = 0;
    //     }
        
    //     return return_time ;
    // }
    public static void Restart(){
        // timer = 0;
        // the_first_transform = true;
        var task = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        task.allowSceneActivation = false;
        // instance.imageFade.StartFade(Color.black, 1.0f, () => {
        //     task.allowSceneActivation = true;
        // });
    }
}


