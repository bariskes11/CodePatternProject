using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAssigner : MonoBehaviour
{
    public Action<Vector3> NewTargetAcquired = delegate { };

    #region Fields
    Ray ray;
    RaycastHit hit;
    #endregion

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                NewTargetAcquired.Invoke(hit.point);
            }
        }
    }

}
