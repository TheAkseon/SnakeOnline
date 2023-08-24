using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _rotateSpeed = 90f;
    [SerializeField] private Transform _head;

    private Vector3 _targetDirection = Vector3.zero;

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        Quaternion targetRotation = Quaternion.LookRotation(_targetDirection);
        _head.rotation = Quaternion.RotateTowards(_head.rotation, targetRotation, Time.deltaTime * _rotateSpeed);
    }

    private void Move()
    {
        transform.position += _head.forward * Time.deltaTime * _speed;
    }

    public void LookAt(Vector3 cursorPosition)
    {
        _targetDirection = cursorPosition - _head.position;
    }
}
