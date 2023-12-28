using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotation : MonoBehaviour
{
    private float zangle;
    // Start is called before the first frame update
    void Start()
    {
        zangle = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        zangle += 50.0f*Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, zangle);
    }
}
