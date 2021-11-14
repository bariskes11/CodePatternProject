using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCubeEvent : MonoBehaviour
{

    public static event Action goldUnlocked;

    bool isRedCubeOk;
    bool isBlueCubeOk;
    MeshRenderer mesh;
    BoxCollider collider;
    private void Start()
    {
        mesh = this.GetComponent<MeshRenderer>();
        collider = this.GetComponent<BoxCollider>();
        BlueCubeEvent.cubeReached += CubeEvent_cubeReached;
        RedCubeEvent.redCubeReached += RedCubeAdditionalEvent_redCubeReached;
        mesh.enabled = false;
        collider.enabled = false;


    }

    private void RedCubeAdditionalEvent_redCubeReached()
    {
        isRedCubeOk = true;
        CheckStatsAndFireGoldEvent();
    }

    private void CubeEvent_cubeReached()
    {
        isBlueCubeOk = true;
        CheckStatsAndFireGoldEvent();
    }

    private void CheckStatsAndFireGoldEvent()
    {
        if (isRedCubeOk && isBlueCubeOk) // i can fire my gold event
        {
            collider.enabled = true;
            mesh.enabled = true;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            goldUnlocked?.Invoke();
        }
    }

}
