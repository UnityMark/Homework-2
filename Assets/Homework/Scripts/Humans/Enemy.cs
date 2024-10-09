using UnityEngine;

public class Enemy : Character
{
    private IStateRest _stateRest;
    private IStateReaction _stateReaction;
    private Transform _target;
    private float _distance = 2f;

    private void Awake()
    {
        _target = GameObject.Find("Player").transform;
    }

    public void Initialize(IStateRest stateRest, IStateReaction stateReaction, Transform target)
    {
        _stateRest = stateRest;
        _stateReaction = stateReaction;
        _target = target;
    }

    private void FixedUpdate()
    {
        Vector3 direction;

        if (Vector3.Distance(this.transform.position, _target.position) < _distance)
        {
            direction = _stateReaction.Reaction();
        }
        else
        {
            direction = _stateRest.Rest();
        }

        _movement.Move(_rigidbody, _moveSpeed, direction);

        if(direction.magnitude > 0)
        {
            _movement.Rotator(this.transform, _rotateSpeed, direction);
        }
    }

}
