using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickWithPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }
}
