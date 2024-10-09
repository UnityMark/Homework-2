using UnityEngine;

public class StateReactionEscape : IStateReaction
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _characterTransform;

    public StateReactionEscape(Transform target, Transform characterTransform)
    {
        _target = target;
        _characterTransform = characterTransform;
    }

    public Vector3 Reaction()
    {
        return (_characterTransform.position - _target.position).normalized;
    }
}
