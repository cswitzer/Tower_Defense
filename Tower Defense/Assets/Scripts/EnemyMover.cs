using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    // Pass in some waypoints that the enemy will follow along
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        // enemy will move to every waypoint in the path in a smooth fashion
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            // enemy will always look at the end position
            transform.LookAt(endPosition);

            // move the enemy to the position of the next waypoint
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                // coroutine will be revisited at the end of every frame
                yield return new WaitForEndOfFrame();
            }
        }
    }
}

/*
 *  yield means to give up control and come back to me in 'n' seconds
 *  yield return new WaitForSeconds(waitTime);
 */