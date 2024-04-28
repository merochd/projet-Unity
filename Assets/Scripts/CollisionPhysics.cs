using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionPhysics : MonoBehaviour
{
    private Vector2 _move;
    private Rigidbody _rb;
    [SerializeField] private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = new Vector3(_move.x, 0, _move.y) * (_speed * Time.deltaTime);
    }

    public void HandleMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
        
    }
}
