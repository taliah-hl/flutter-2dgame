using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gravity_Change : MonoBehaviour
{
    // Start is called before the first frame update

    [System.Serializable]
    private struct BackGround{
        [SerializeField]
        private Image bg;
        [SerializeField]
        public bool gravitydown;
        // private Color cup = new Color32( 173, 173, 173, 200 );
        // private Color cdown = new Color32( 0, 0, 0, 200 );
        public void UP(){
            // Color c = tilemap.color;
            // c.a = 1;
            bg.color = new Color32( 0, 200, 0, 200 );
            gravitydown = false;
            // rigidbody.simulated = true;
            // Debug.Log(c.a);
            Debug.Log("change color up");
        }
        public void Down(){
            bg.color = new Color32( 200, 0, 0, 200 );
            gravitydown = true;
            Debug.Log("change color up");
        }
        public void Toggle(){
            if(gravitydown) UP();
            else Down();
        }
    }
    [SerializeField]
    private BackGround outer_bg;
    [SerializeField]
    // private ImageFade imageFade;
    private static Gravity_Change instance = null;
    private void Awake() {
        instance = this;
        outer_bg.Down();
    }
    private void Start() {
        // imageFade.SetColor(Color.black);
        // imageFade.StartFade(Color.clear, 1.0f);
    }
    public static void ToggleBG(){
        Debug.Log("switch");
        instance.outer_bg.Toggle();
        // blueTiles.Toggle();
        // Toggle();
    }
    public static void Restart(){
        instance.outer_bg.Down();
        // instance.imageFade.StartFade(Color.black, 1.0f, () => {
        //     task.allowSceneActivation = true;
        // });
    }
}
