using UnityEngine;

public class StateReactionChase : IStateReaction
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _characterTransform;

    public StateReactionChase(Transform target, Transform characterTransform)
    {
        _target = target;
        _characterTransform = characterTransform;
    }

    public Vector3 Reaction() => (_target.position - _characterTransform.position).normalized;
}
