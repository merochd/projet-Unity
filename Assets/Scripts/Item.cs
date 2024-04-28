using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public event Action<Item> IsTouched;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            IsTouched?.Invoke(this);
            Debug.Log("objet detruit");
        }
    }
}
