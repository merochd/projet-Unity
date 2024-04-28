using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed = 20f;
    [SerializeField] private float _timeLimit = 5f;

    private float _lifeTime = 0f;
    
    void Update()
    {
        Vector3 movement = transform.forward * _projectileSpeed * Time.deltaTime;
        transform.position = transform.position + movement;
        // on deplace le projectile en ligne droite

        _lifeTime += Time.deltaTime;
        // on update le TTL (Time To Live) du projectile selon le temps qu'il est rester sur la scene
        
        if (_lifeTime > _timeLimit)
        {
            Destroy(this.gameObject);
            // on casse le projectile si il reste trop longtemps sur la scene
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destructible"))
        {
			Destroy(other.gameObject);
			Destroy(this.gameObject);
            // si le projectile touche un GameObject avec le tag "Destructible" on le casse lui et le GameObject touché
        }

        if (other.gameObject.CompareTag("Decor"))
        {
            Destroy(this.gameObject);
            // si le projectile touche un GameObject avec le tag "Decor" on le casse
        }
    }
}
