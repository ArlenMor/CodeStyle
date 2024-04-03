using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _waypointsParent;

    private Transform[] _waypoints;
    private int _waypointsCounter = 0;
    private float _offset = 0.001f;

    private void Start()
    {
        _waypoints = new Transform[_waypointsParent.childCount];

        for (int i = 0; i < _waypoints.Length; i++)
            _waypoints[i] = _waypointsParent.GetChild(i);
    }

    public void Update()
    {
        Transform waypoint = _waypoints[_waypointsCounter];
        transform.position = Vector3.MoveTowards(transform.position, waypoint.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoint.position) <= _offset)
        {
            _waypointsCounter = (_waypointsCounter + 1) % _waypoints.Length;
            transform.LookAt(_waypoints[_waypointsCounter]);
        }
    }
}