using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundState : IState
{

    PlayerStateManager _playerStateManager;
    Color foundColor = Color.green;
    Material _material;
    TargetAssigner _targetassigned;
    public FoundState(PlayerStateManager playerStateManager, Material material, TargetAssigner targetassigned)
    {
        this._playerStateManager = playerStateManager;
        this._material = material;
        this._targetassigned = targetassigned;
    }
    public void Enter()
    {

        Debug.Log("Player is at found state");
        _material.color = foundColor;
        _targetassigned.MoveCommand += NewMoveCommand;
    }
    public void Exit()
    {
        _targetassigned.MoveCommand -= NewMoveCommand;
    }

    private void NewMoveCommand(Vector3 obj)
    {
        _playerStateManager.TargetPosition = obj;
        _playerStateManager.ChangeState(_playerStateManager.SearchState);
    }
    public void FixedTick()
    {
    }

    public void Tick()
    {
    
    }
}
