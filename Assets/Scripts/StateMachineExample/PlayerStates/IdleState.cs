using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    PlayerStateManager _playerSM;
    TargetAssigner _targetAssigner;
    Material _Mat;
    Color _startingColor;
    Color _idleStateColor=Color.black;

    public  IdleState(PlayerStateManager playerSM, Material material,TargetAssigner targetAssigner)
    {
        this._playerSM = playerSM;
        this._Mat = material;
        this._targetAssigner = targetAssigner;
    }

    public void Enter()
    {
        Debug.Log($"STATE CHANGE  -  IDLE");
        _targetAssigner.NewTargetAcquired += OnNewTargetAcuired;
    }

    public void Exit()
    {
        _Mat.color = _startingColor;
        _targetAssigner.NewTargetAcquired -= OnNewTargetAcuired;
    }

    public void FixedTick()
    {
        
    }

    public void Tick()
    {
        
    }

    void OnNewTargetAcuired(Vector3 newPosition)
    {
        _playerSM.ChangeState(_playerSM.SearchState);
    }
    

    // Start is called before the first frame update

}
