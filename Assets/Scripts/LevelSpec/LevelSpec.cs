using UnityEngine;


[CreateAssetMenu(fileName = "LevelSpec", menuName = "ScriptableObject/LevelSpec", order = 0)]
public class LevelSpec: ScriptableObject {
    public int maxGravToggle; // gravity toggle 次數上限
    public float maxFreeFallSpeed = 20; //  max velocity in y direction
}
