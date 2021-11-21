using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAssigner : MonoBehaviour
{
    // delegate for moving player towards point
    public Action<Vector3> MoveCommand = delegate { };


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
                MoveCommand.Invoke(hit.point);
               
            }
        }
    }

    private void OnDrawGizmos()
    {
        // to see target gizmo
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.hit.point, 1F);
    }
}
