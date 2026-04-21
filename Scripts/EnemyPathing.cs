using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    //Array of waypoints
    [SerializeField] GameObject[] path;
    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Go to first waypoint position
        transform.position = path[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // If the enemy is not at the end of the path
        if(waypointIndex < path.Length)

        {
            // Find the target position (next waypoint)
            var targetPosition = path[waypointIndex].transform.position;
            // Calculate how fast to move there (speed) 
            var movementPerFrame = moveSpeed * Time.deltaTime;
            // Apply the movement with speed to go to target
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementPerFrame);
            // Check to see if we have reached the target position 
            if (transform.position == targetPosition)

            {
                // Increment the waypoint index
                waypointIndex++;

            }
        }
        // Otherwise (The enemy has reached the end of the path)
        else
        {
            // Destroy the enemy
            Destroy(gameObject);
        }
    }
}
