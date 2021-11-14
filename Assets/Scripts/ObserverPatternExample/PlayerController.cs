using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    bool isGameFinished;
    void Start()
    {
        isGameFinished = false;
        GoldCubeEvent.goldUnlocked += GoldCube_goldUnlocked;
    }

    private void GoldCube_goldUnlocked()
    {

        isGameFinished = true;
        Debug.Log("Player You have Reach the end of level Controls disabled now" );
        
    }

    /// <summary>
    /// Very basic  movement system
    /// </summary>
    void Update()
    {
        if (isGameFinished)
            return;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 p = this.transform.position;
        p.x += h * moveSpeed;
        p.z += v * moveSpeed;
        this.transform.position = p;
    }
}
