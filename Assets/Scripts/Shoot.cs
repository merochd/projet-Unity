using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{

    private Animator _animator;
    
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _parent;
    [SerializeField] private GameObject flame1;
    [SerializeField] private GameObject flame2;
    

    void Start()
    {
        _animator = GetComponent<Animator>();
        flame1.SetActive(false);
        flame2.SetActive(false);
    }



    public void HandleShoot(InputAction.CallbackContext context)
    {
        bool shootInput = context.ReadValueAsButton();
        Debug.Log("Is shooting ? " + shootInput);
        
        _animator.SetBool("IsShooting", shootInput);
        // on lance l'animation de tire

        if (shootInput)
        {
            Instantiate(_projectile, _parent.transform.position, _parent.transform.rotation);
            StartCoroutine(HideAndShowObject());
            // on lance la fonction qui affiche puis cache les flames
        }
        
    }
    IEnumerator HideAndShowObject()
    {
        flame1.SetActive(true);
        flame2.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        flame1.SetActive(false);
        flame2.SetActive(false);
        // on affiche puis cache (avec 50 ms de delai) les flames
    }

}
