using UnityEngine;

// this script is for create a large frictional collider
// for player when it enter cup of lv1-3
public class CreateCollForCup : MonoBehaviour
{
    private GameObject playerRbGameObj;
    [SerializeField] private float cupAreaUp;
    [SerializeField] private float cupAreaDown;
    [SerializeField] private float cupAreaLeft;
    [SerializeField] private float cupAreaRight;
    private GameObject largeBoxCollider;
    private bool isEnabled = false;

    void Start()
    {
        
        largeBoxCollider = transform.Find("LargeBoxCollider").gameObject;
        largeBoxCollider.SetActive(false);
    }

    void Update()
    {
        
        if(transform.position.x >=cupAreaLeft && transform.position.x <= cupAreaRight 
            && transform.position.y >= cupAreaDown && transform.position.y <= cupAreaUp)
        {

            if(!isEnabled){
                largeBoxCollider.SetActive(true);
                isEnabled = true;
            }
            
        }
        else{
            if(isEnabled){
                largeBoxCollider.SetActive(false);
                isEnabled = false;
            }
        }
    }
}