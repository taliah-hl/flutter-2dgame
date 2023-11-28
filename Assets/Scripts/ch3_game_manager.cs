using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
public class ch3_game_manager : MonoBehaviour
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
    private Tiles blueTiles;
    [SerializeField]
    // private ImageFade imageFade;
    private static ch3_game_manager instance = null;
    private void Awake() {
        instance = this;
        blueTiles.Disable();
    }
    private void Start() {
        // imageFade.SetColor(Color.black);
        // imageFade.StartFade(Color.clear, 1.0f);
    }
    public static void ToggleTiles(){
        Debug.Log("switch");
        instance.blueTiles.Toggle();
        // blueTiles.Toggle();
    }
    public static void Restart(){
        var task = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        task.allowSceneActivation = false;
        // instance.imageFade.StartFade(Color.black, 1.0f, () => {
        //     task.allowSceneActivation = true;
        // });
    }
}

