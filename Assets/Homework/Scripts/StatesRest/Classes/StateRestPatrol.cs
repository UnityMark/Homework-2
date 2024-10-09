using System.Collections.Generic;
using UnityEngine;

public class StateRestPatrol : IStateRest
{
    private List<Vector3> _points = new List<Vector3>();
    private Transform _characterTransform;
    private int _pointIndex = 0;
    private float _distance = 2f;

    public StateRestPatrol(List<Vector3> points, Transform characterTransform)
    {
        _points = points;
        _characterTransform = characterTransform;
    }

    public Vector3 Rest()
    {
        if(Vector3.Distance(_characterTransform.position, _points[_pointIndex]) < _distance)
        {
            _pointIndex++;
        }

        if(_pointIndex >= _points.Count)
        {
            _pointIndex = 0;
        }

        return (_points[_pointIndex] - _characterTransform.position).normalized;
    }
}
