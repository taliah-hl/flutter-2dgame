using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectiveCover : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer Cover;
    private float timer, pretimer, ca;
    void Start()
    {
        Cover = gameObject.GetComponent<SpriteRenderer>();
        Color c = Cover.color;
        c.a = 0.7f;
        ca = 0.7f;
        Cover.color = c;
        // Cover.color.a = 0.7f;
        timer = 0;
        pretimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>10.0f) {
            Destroy(this.gameObject);
        }
        timer = timer + Time.deltaTime;
        if(timer-pretimer>=0.5f) {
            pretimer = timer;
            ca -= 0.025f;
            decade(ca);
        }
    }

    void decade(float n) {
        // Cover.a = Cover.a - 0.05f;
        Color c = Cover.color;
        c.a = n;
        Cover.color = c;
    }
}
