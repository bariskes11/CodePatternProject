using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCubeEvent : MonoBehaviour
{
    public static event Action redCubeReached;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")  // assume that you only looking for player
            redCubeReached?.Invoke();
    }
}
