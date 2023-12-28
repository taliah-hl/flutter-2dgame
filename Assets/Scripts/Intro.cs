using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Intro : MonoBehaviour
{
    public GameObject Control;
    public GameObject Objects;
    public GameObject Tutor1;
    public GameObject Tutor2;
    public GameObject Tutor3;
    public GameObject HelpMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadImage());
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
}
