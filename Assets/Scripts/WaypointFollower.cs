using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    private int currentWaypointIndex = 0;

    public float globalSpeed;

    [SerializeField] private float speed;

    void Start()
    {
        //globalSpeed = SceneSpec.PlatformSpeed;
        if(speed==0) speed = globalSpeed;
    }

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, Time.deltaTime * speed);
    }
}