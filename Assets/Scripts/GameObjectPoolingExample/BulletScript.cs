using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    
    void Update()
    {
        // speed can be a serializefield its for demostration.
        this.transform.position += Vector3.forward * 30F * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet Collision");
        this.gameObject.SetActive(false);
    }
}
