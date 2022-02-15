using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 Position;
    Rigidbody Rb;
    public float m_Thrust = 20f;
    // Start is called before the first frame update
    void Start()
    {
        Position = transform.position;
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            Rb.AddForce(transform.up * m_Thrust);
        }
    }

}
