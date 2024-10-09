using UnityEngine;

public class Player : Character
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private string VERTICAL_AXIS = "Vertical";

    private KeyCode _keyForward = KeyCode.W;
    private KeyCode _keyBack = KeyCode.S;
    private KeyCode _keyLeft = KeyCode.A;
    private KeyCode _keyRight = KeyCode.D;

    private void FixedUpdate()
    {
        if (GetInput())
        {
            Move();
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void Move()
    {
        float verticalDirection = Input.GetAxisRaw(VERTICAL_AXIS);
        float horizontalDirection = Input.GetAxisRaw(HORIZONTAL_AXIS);

        Vector3 input = new Vector3(horizontalDirection, 0, verticalDirection);

        _movement.Move(_rigidbody, _moveSpeed, input);
        _movement.Rotator(this.transform, _rotateSpeed, input.normalized);
    }

    private bool GetInput() => Input.GetKey(_keyForward) || Input.GetKey(_keyBack) || Input.GetKey(_keyLeft) || Input.GetKey(_keyRight);
}
