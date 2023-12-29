using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRemain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject currentBGM = GameObject.Find("BGM");
        if (currentBGM == null)
        {
            AudioSource spawned = Instantiate(this.gameObject.GetComponent<AudioSource>());
            spawned.Play();
            DontDestroyOnLoad(spawned);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
