using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    // Pass in some waypoints that the enemy will follow along
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintWaypointName());
    }

    IEnumerator PrintWaypointName()
    {
        foreach(Waypoint waypoint in path)
        {
            // move the enemy to the position of the next waypoint
            transform.position = waypoint.transform.position;
            // yield means to give up control and come back to me in 'n' seconds
            yield return new WaitForSeconds(waitTime);
        }
    }
}
