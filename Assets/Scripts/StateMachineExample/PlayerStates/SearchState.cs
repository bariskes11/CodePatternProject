using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : IState
{
    PlayerStateManager _playerSM;
    Rigidbody _rbd;
    Material _material;
    Color _stateColor = Color.red;
    public SearchState(PlayerStateManager playerStateMan,Material material,Rigidbody rb)
    {
        _rbd = rb;
        _material = material;
        _playerSM = playerStateMan;
    }
    public void Enter()
    {
        Debug.Log($"STATE CHANE - Search");
        _material.color = _stateColor;
    }

    public void Exit()
    {
       
    }

    public void FixedTick()
    {
        float distanceFromtarget = Vector3.Distance(_playerSM.TargetPosition, _rbd.position);
        if (distanceFromtarget < .8F)
        {
            _playerSM.ChangeState(_playerSM.FoundState);
        }
        else
        {
            RotateTowardsTarget();
            MoveTowerdsTarget();
        }
    }
    void RotateTowardsTarget()
    {
        Quaternion lookrotation = Quaternion.LookRotation(_playerSM.TargetPosition - _rbd.position);
        lookrotation = Quaternion.Slerp(_rbd.rotation, lookrotation, _playerSM.RotateSpeed * Time.deltaTime);
        _rbd.MoveRotation(lookrotation);
    }
    void MoveTowerdsTarget()
    {
//        Vector3 moveoffset = _playerSM.transform.forward * _playerSM.MoveSpeed;
        _rbd.MovePosition(Vector3.Lerp(_playerSM.transform.position, _playerSM.TargetPosition,_playerSM.MoveSpeed));
    }

    public void Tick()
    {
   
    }
}
