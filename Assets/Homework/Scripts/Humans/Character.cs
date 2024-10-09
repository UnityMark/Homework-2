using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Settings Players")]
    [SerializeField] private protected float _moveSpeed = 5f;
    [SerializeField] private protected float _rotateSpeed = 900f;

    [Header("Components")]
    [SerializeField] private protected Movement _movement;
    [SerializeField] private protected Rigidbody _rigidbody;
}
