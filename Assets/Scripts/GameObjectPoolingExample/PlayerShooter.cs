using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    Transform shootingPoint;

    GameObject currentGameObj;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           currentGameObj= CreateGameObjects.Instance.CreateGameObject("Bullet", this.transform.position, null);
            currentGameObj.transform.position = shootingPoint.transform.position;
        }
    }
}
