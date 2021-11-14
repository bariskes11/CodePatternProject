using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCommand : ICommand
{
    private float scalefactor;
    private Transform transform;
    public ScaleCommand(float scalefactor,Transform transform)
    {
        this.scalefactor = scalefactor;
        this.transform = transform;
    }

    public void Execute()
    {
        this.transform.localScale += Vector3.one * scalefactor;
    }

    public void Undo()
    {
        this.transform.localScale -= Vector3.one * scalefactor;
    }

    // Start is called before the first frame update
 
}
