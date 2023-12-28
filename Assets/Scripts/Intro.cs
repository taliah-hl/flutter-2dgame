using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Intro : MonoBehaviour
{
    public GameObject Control;
    public GameObject Objects;
    public GameObject Tutor1;
    public GameObject Tutor2;
    public GameObject Tutor3;
    public GameObject HelpMenu;
    public TMP_Text BtnText;
    public int flag = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        flag = 0;
        //StartCoroutine(LoadImage());
    }
    IEnumerator LoadImage()
    {
        HelpMenu.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        Control.SetActive(false);
        yield return new WaitForSecondsRealtime(3);
        Objects.SetActive(false);
        yield return new WaitForSecondsRealtime(3);
        Tutor1.SetActive(false);
        yield return new WaitForSecondsRealtime(3);
        Tutor2.SetActive(false);
        yield return new WaitForSecondsRealtime(3);
        Tutor3.SetActive(false);
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene("tutor-lv"); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        switch (flag)
        {
            case 0:
                Control.SetActive(false);
                flag++;
                break;
            case 1:
                Objects.SetActive(false);
                flag++;
                break;
            case 2:
                Tutor1.SetActive(false);
                flag++;
                break;
            case 3:
                Tutor2.SetActive(false);
                flag++;
                break;
            case 4:
                Tutor3.SetActive(false);
                BtnText.text = "Start";
                flag++;
                break;
            case 5:
                SceneManager.LoadScene("tutor-lv");
                break;
        }
    }
}
