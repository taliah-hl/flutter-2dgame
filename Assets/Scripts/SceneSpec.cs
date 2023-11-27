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

    
    void Awake(){
        maxGravToggle = lvSpec.maxGravToggle;
    }


}
