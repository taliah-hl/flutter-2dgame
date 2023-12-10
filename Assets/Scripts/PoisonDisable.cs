using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PoisonDisable : MonoBehaviour
{
    [System.Serializable]
    private struct PoisonGround{
        [SerializeField]
        private Tilemap tilemap;
        public bool valid;
        public float timer;
        [SerializeField]
        // public bool isEnabled => rigidbody.simulated;
        public void Enable(){
            valid = true;
            // Color c = tilemap.color;
            // c.a = 1;
            tilemap.color = new Color32(230, 51, 51, 255);
            // Debug.Log(c.a);
        }
        public void Disable(){
            valid = false;
            Color c = tilemap.color;
            // c.a = 0.7f; 
            tilemap.color = new Color(0, 238, 238, 0.7f);
            // Debug.Log(c.a);
        }
        public void TimeUpdate() {
            timer = timer - Time.deltaTime;
        }

        public void TimerSet() {
            timer = 10.0f;
        }
    }
    [SerializeField]
    private PoisonGround ground;
    // private Door door2;
    // private Door door3;
    [SerializeField]
    // private ImageFade imageFade;
    private static float timer;
    private static bool the_first_transform = true;
    private static PoisonDisable instance = null;
    private void Awake() {
        instance = this;
        ground.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        if(ground.timer<0 && ground.valid==false) {
            ground.Enable();
           
        }
        if(ground.valid==false) {
            ground.TimeUpdate();
        }
    }

    public static void PTrigger() {
        instance.ground.Disable();
        instance.ground.TimerSet();
    }

    public static void Restart(){
        instance.ground.Enable();
    }
}



