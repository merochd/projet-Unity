using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTank : MonoBehaviour
{
    [SerializeField] private float _moveIntensity;
    [SerializeField] private float _turnSpeed;
	[SerializeField] public GameObject timer;
    private Timer targetScript;
    
    private Rigidbody _rb;
    private Animator _animator;
    private float _inputTurn;
    private float _inputForward;
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
		targetScript = timer.GetComponent<Timer>();
    }

    void FixedUpdate()
    {
        if (targetScript.GameEnd == false)
		{
        	_rb.MoveRotation( _rb.rotation * Quaternion.Euler(Vector3.up * _inputTurn * _turnSpeed * Time.deltaTime));
        	_rb.AddForce(_rb.transform.forward * _inputForward * _moveIntensity);
            // verifie si on doit bouger
        }
    }
    
    public void HandleTurn(InputAction.CallbackContext context)
    {
        _inputTurn = context.ReadValue<float>();
        // recupere les mouvement du joystick gauche (avant/arriere)
    }

    public void HandleForward(InputAction.CallbackContext context)
    {
        _inputForward = context.ReadValue<float>();
        // recupere les mouvement du joystick gauche (gauche/droite)
    }
}
