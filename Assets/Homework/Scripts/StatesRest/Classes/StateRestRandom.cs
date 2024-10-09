using UnityEngine;

public class StateRestRandom : IStateRest
{
    [SerializeField] private Transform _characterTransform;
    [SerializeField] private float _minStep = -3;
    [SerializeField] private float _maxStep = 3;
    [SerializeField] private float _time;
    [SerializeField] private float _maxTime = 2f;
    [SerializeField] private Vector3 _direction;

    public StateRestRandom(Transform transform)
    {
        _characterTransform = transform;
    }

    public Vector3 Rest()
    {
        if (_time < 0)
        {
            float x = Random.RandomRange(_minStep, _maxStep);
            float y = _characterTransform.position.y;
            float z = Random.RandomRange(_minStep, _maxStep);
            _time = _maxTime;
            _direction = new Vector3(x, y, z);
        }
        else
        {
            _time -= Time.deltaTime;
        }

        return _direction.normalized;
    }
}
