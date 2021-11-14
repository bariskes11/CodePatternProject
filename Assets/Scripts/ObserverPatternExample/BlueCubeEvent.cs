using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCubeEvent : MonoBehaviour
{
    public static event Action cubeReached;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")  // assume that you only looking for player
        {
            Debug.Log($"cube has been breached", this.gameObject);
            cubeReached?.Invoke();
        }
    }
}
