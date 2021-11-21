using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    PlayerStateManager _playerSM;
    TargetAssigner _targetAssigner;
    Material _material;
    Color _stateColor=Color.yellow;

    public  IdleState(PlayerStateManager playerSM, Material material,TargetAssigner targetAssigner)
    {

        this._playerSM = playerSM;
        this._material = material;
        this._targetAssigner = targetAssigner;
    }

    public void Enter()
    {
        Debug.Log("Idle State Enter");
        _material.color = _stateColor;
        _targetAssigner.MoveCommand += OnNewTargetAcuired;
    }

    public void Exit()
    {
        _targetAssigner.MoveCommand -= OnNewTargetAcuired;
    }

    public void FixedTick()
    {
        
    }

    public void Tick()
    {
        //
        Debug.Log("Idle State Tick");
    }

    void OnNewTargetAcuired(Vector3 newPosition)
    {

        _playerSM.TargetPosition = newPosition;
        _playerSM.ChangeState(_playerSM.SearchState);
    }
    

    // Start is called before the first frame update

}
