using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{

    public float speed = 10f;
    public float wayPointDetectionRadius = 0.2f;

    private Transform targetTransform;
    private int waypointIndex = 0;

    void Start() {
        targetTransform = WaypointsScript.waypoints[0];
    }

    void Update() {
        // Direction enemy needs to face to point towards next waypoint
        Vector3 direction = targetTransform.position - transform.position;
        // Normalising it makes this unit vectors only (since its a direction vector)
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetTransform.position) <= wayPointDetectionRadius) {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint() {

        // Enemy is destroyed once it reaches the last waypoint
        if (waypointIndex >= WaypointsScript.waypoints.Length-1) {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        targetTransform = WaypointsScript.waypoints[waypointIndex];
    }
}
