using UnityEngine;

public class StateReactionDie : IStateReaction
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _characterTransform;

    public StateReactionDie(Transform target, Transform characterTransform)
    {
        _target = target;
        _characterTransform = characterTransform;
    }

    public Vector3 Reaction()
    {
        if(Vector3.Distance(_target.position, _characterTransform.position) < 1f)
        {
            Object.Destroy(_characterTransform.gameObject);
            Debug.Log("Destroy");
        }

        return Vector3.zero;
    }
}
