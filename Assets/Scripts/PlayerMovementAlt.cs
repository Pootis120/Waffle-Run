using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementAlt : MonoBehaviour
{
    [SerializeField] private float _thrust = 20f;
    [SerializeField] private int _health = 150;

    private const string _groundTag = "Ground";

    private Rigidbody _rb;
    private bool _onGround = false;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
            _rb.AddForce(Vector3.up * _thrust);

        if (_onGround)
            _health--;
    }

    //More reliable for some reason than OnCollisionStay
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
            _onGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
            _onGround = false;
    }
}
