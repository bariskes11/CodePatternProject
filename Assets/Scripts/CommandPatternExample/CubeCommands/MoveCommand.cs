using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{

    private Transform movingObject;
    private Vector3 direction;
    private float moveSpeed;
    public MoveCommand(Transform transform,Vector3 direction,float moveSpeed)
    {
        this.movingObject = transform;
        this.direction = direction;
        this.moveSpeed = moveSpeed;
    }
     public void Execute()
    {
        this.movingObject.transform.position += this.direction* moveSpeed;
    }

    public void Undo()
    {
        this.movingObject.transform.position -= this.direction* moveSpeed;
    }

}
