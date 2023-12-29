using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkScprite : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    public GameManager gm;
    public float blinkTime = 3f;
    public float blinkInterval = 0.2f;
    private bool blinked=false;

    void Awake()
    {
        spriteRenderer=this.gameObject.GetComponent<SpriteRenderer>();
        gm = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        
    }
    void Update()
    {
        if((! blinked) && (!gm.getIsGamePause())){
            Debug.Log("gm.getIsGamePause() is: " + gm.getIsGamePause());
            
            StartCoroutine(BlinkAndDisappear());
            blinked = true;
        }
    }

    IEnumerator BlinkAndDisappear()
    {
        float endTime = Time.time + blinkTime;

        while (Time.time < endTime)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }

        spriteRenderer.enabled = false;
        
    }
}
