using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _waypointsParent;

    private Transform[] _waypoints;
    private int _waypointsCounter = 0;

    private void Start()
    {
        _waypoints = new Transform[_waypointsParent.childCount];

        for (int i = 0; i < _waypointsParent.childCount; i++)
            _waypoints[i] = _waypointsParent.GetChild(i).GetComponent<Transform>();
    }

    public void Update()
    {
        Transform _waypoint = _waypoints[_waypointsCounter];
        transform.position = Vector3.MoveTowards(transform.position, _waypoint.position, _speed * Time.deltaTime);

        if (transform.position == _waypoint.position)
        {
            _waypointsCounter = (_waypointsCounter + 1) % _waypoints.Length;
            transform.LookAt(_waypoints[_waypointsCounter]);
        }
    }
}