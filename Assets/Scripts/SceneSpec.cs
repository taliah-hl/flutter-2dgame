using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSpec : MonoBehaviour
{
    public LevelSpec lvSpec;
    private static int maxGravToggle;
    public static int MaxGravToggle{
        get {return maxGravToggle;}
    }

    private static float maxFreeFallSpeed;
    public static float MaxFreeFallSpeed{
        get {return maxFreeFallSpeed;}
    }

    
    void Awake(){
        maxGravToggle = lvSpec.maxGravToggle;
        
        maxFreeFallSpeed = lvSpec.maxFreeFallSpeed >0? lvSpec.maxFreeFallSpeed:20;
    }


}
