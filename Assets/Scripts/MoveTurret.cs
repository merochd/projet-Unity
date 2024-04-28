using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTurret : MonoBehaviour
{
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _canonTurnSpeed;
    [SerializeField] private Transform _canon;
	[SerializeField] public GameObject timer;
    private Timer targetScript;
    
    private float _inputTurn;
    private float _inputUpDown;
    


    // Start is called before the first frame update
    void Start()
    {
		targetScript = timer.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetScript.GameEnd == false)
        {
            _canon.Rotate(Vector3.up, _inputTurn * _turnSpeed * Time.deltaTime);
            _canon.Rotate(Vector3.right, _inputUpDown * _canonTurnSpeed * Time.deltaTime);
            // verifie si le canon doit tourner
        }

    }
    
    public void HandleTurn(InputAction.CallbackContext context)
    {
        _inputTurn = context.ReadValue<float>();
        // recupere les mouvement du joystick droit (gauche/droite)
    }
    public void HandleTurnUpDown(InputAction.CallbackContext context)
    {
        _inputUpDown = context.ReadValue<float>();
        // recupere les mouvement du joystick droit (avant/arriere)
    }
}
