using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
public class TransformDoor_Controller : MonoBehaviour
{
    [System.Serializable]
    private struct Door{
        [SerializeField]
        private Tilemap tilemap;
        public bool valid;
        public float timer;
        [SerializeField]
        // public bool isEnabled => rigidbody.simulated;
        public void Enable(){
            valid = true;
            Color c = tilemap.color;
            c.a = 1;
            tilemap.color = c;
            Debug.Log(c.a);
        }
        public void Disable(){
            valid = false;
            Color c = tilemap.color;
            c.a = 0.3f; 
            tilemap.color = c;
            Debug.Log(c.a);
        }
        public void TimeUpdate() {
            timer = timer + Time.deltaTime;
        }

        public void TimerSet() {
            timer = 0;
        }
        public void TimerSet5() {
            timer = 5.0f;
        }
    }
    [SerializeField]
    private Door door1, door2, door3;
    // private Door door2;
    // private Door door3;
    [SerializeField]
    // private ImageFade imageFade;
    private static float timer;
    private static bool the_first_transform = true;
    private static TransformDoor_Controller instance = null;
    private void Awake() {
        instance = this;
        door1.TimerSet5();
        door2.TimerSet5();
        door3.TimerSet5();
        door1.Enable();
        door2.Enable();
        door3.Enable();
        // timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        // timer = timer + Time.deltaTime;
        door1.TimeUpdate();
        door2.TimeUpdate();
        door3.TimeUpdate();
        if((door1.timer>2.0f) && (!door1.valid)) {
            door1.Enable();
        }
        if((door2.timer>2.0f) && (!door2.valid)) {
            door2.Enable();
        }
        if((door3.timer>2.0f) && (!door3.valid)) {
            door3.Enable();
        }
    }

    public static float doorTrigger(int n) {
        float return_time = 0;
        if(n==1) {
            if(instance.door1.valid) {
                return_time = instance.door1.timer;
                instance.door1.TimerSet();
                instance.door1.Disable();
            }
            else return_time = instance.door1.timer;
        }
        if(n==2) {
            if(instance.door2.valid) {
                return_time = instance.door2.timer;
                instance.door2.TimerSet();
                instance.door2.Disable();
            }
            else return_time = instance.door2.timer;
        }
        if(n==3) {
            if(instance.door3.valid) {
                return_time = instance.door3.timer;
                instance.door3.TimerSet();
                instance.door3.Disable();
            }
            else return_time = instance.door3.timer;
        }
        
        return return_time ;
    }
    public static void Restart(){
        instance.door1.TimerSet5();
        instance.door2.TimerSet5();
        instance.door3.TimerSet5();
        instance.door1.Enable();
        instance.door2.Enable();
        instance.door3.Enable();
        // instance.imageFade.StartFade(Color.black, 1.0f, () => {
        //     task.allowSceneActivation = true;
        // });
    }
}


