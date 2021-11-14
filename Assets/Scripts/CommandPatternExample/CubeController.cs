using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float scaleUpMultiplyer;
    Vector3 lastPos;
    Vector3 deltaPos;
    // Update is called once per frame
    CommandList commands = new CommandList();
    void Update()
    {

        MovingInputs();
        ScaleInputs();
        UndoInput();
    }

    void ScaleInputs()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            commands.Execute(new ScaleCommand(scaleUpMultiplyer, this.transform));
        }

    }
    void UndoInput()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            commands.Undo();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            commands.Undo();
        }
    }
    void MovingInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            deltaPos = Input.mousePosition - lastPos;

            commands.Execute(new MoveCommand(this.transform, deltaPos, moveSpeed));
        }
       
    }
}
