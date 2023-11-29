using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class transdoor_color : MonoBehaviour
{
    // Start is called before the first frame update
    private struct Tiles{
        [SerializeField]
        private Tilemap tilemap;
        [SerializeField]
        private Rigidbody2D rigidbody;
        public bool isEnabled;
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

        public void check(){
            if(isEnabled) Disable();
            else Enable();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
