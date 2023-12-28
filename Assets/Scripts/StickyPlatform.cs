using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("sticky platform collision with: "+other.gameObject.tag);
        if (other.gameObject.tag == "PlayerRb" || other.gameObject.name=="stickCloud")
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerRb" )
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
