using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementWakeUped : MonoBehaviour
{
    [SerializeField] private float _thrust = 20f;
    [SerializeField] private int _health = 150;

    private const string _groundTag = "Ground";

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
            _rb.AddForce(Vector3.up * _thrust);

        if (_rb.IsSleeping())
            _rb.WakeUp();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
            _health--;
    }
}
