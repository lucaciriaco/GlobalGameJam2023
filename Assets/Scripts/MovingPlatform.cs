using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pathHolder;
    public float speed;
    public float waitTime;

    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        Vector3[] _waypoints = new Vector3[pathHolder.childCount];
        line.positionCount = pathHolder.childCount;
        for (int i=0;i<_waypoints.Length;i++)
        {
            _waypoints[i] = pathHolder.GetChild(i).position;
            line.SetPositions(_waypoints);
        }
        StartCoroutine(FollowPath(_waypoints));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];
        int _targetWaypointIndex = 1;
        Vector3 _targetWaypoint = waypoints[_targetWaypointIndex];
        while(true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetWaypoint, speed * Time.deltaTime);
            if(transform.position == _targetWaypoint)
            {
                _targetWaypointIndex = (_targetWaypointIndex + 1) % waypoints.Length;
                _targetWaypoint = waypoints[_targetWaypointIndex];
                yield return new WaitForSeconds(waitTime);
            }
            yield return null;
        }
    }


    private void OnDrawGizmos()
    {
        Vector3 _startPosition = pathHolder.GetChild(0).position;
        Vector3 _previousPosition = _startPosition;

        foreach (Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, 0.3f);
            Gizmos.DrawLine(_previousPosition, waypoint.position);
            _previousPosition = waypoint.position;
        }
        Gizmos.DrawLine(_previousPosition, _startPosition);
    }
}
