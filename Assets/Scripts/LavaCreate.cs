using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCreate : MonoBehaviour
{
    public GameObject LavaDrop;
    // public GameObject createPoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateLava", 2, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateLava() {
        int DropNum;

        DropNum = Random.Range(4, 8);

        //開始生成怪物

        for (int i = 0; i < DropNum; i++)

        {

            //宣告生成的X座標

            float x, y;

            //產生隨機的X座標(-6到5之間)

            x = Random.Range(-0.7f, 0.7f);
            y = Random.Range(-0.3f, 0.3f);

            //生成怪物

            Instantiate(LavaDrop, new Vector2(gameObject.transform.position.x + x, gameObject.transform.position.y+y), Quaternion.identity);

        }

    }
}
