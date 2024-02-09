using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private int currentWaypointIndex = 0;

    void Update()
    {
        var waypointPos = waypoints[currentWaypointIndex].transform.position;
        if (Vector3.Distance(waypointPos, transform.position) < .1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        transform.position = Vector3.MoveTowards(transform.position,
                                                 waypointPos, 
                                                 Time.deltaTime * speed);
    }
}
