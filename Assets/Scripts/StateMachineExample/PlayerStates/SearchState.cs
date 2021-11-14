using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : IState
{
    PlayerStateManager _playerSM;
    Rigidbody _rbd;
    Material _eyemat;
    Color _startingEyeColor;
    Color _searchEyeColor = Color.red;
    public SearchState(PlayerStateManager playerStateMan,Material eyeMat,Rigidbody rb)
    {
        _rbd = rb;
        _eyemat = eyeMat;
        _playerSM = playerStateMan;
    }
    public void Enter()
    {
        Debug.Log($"STATE CHANE - Search");
        _searchEyeColor = _eyemat.color;
        _eyemat.color = _searchEyeColor;
    }

    public void Exit()
    {
        _eyemat.color = _startingEyeColor;
    }

    public void FixedTick()
    {
        float distanceFromtarget = Vector3.Distance(_playerSM.TargetPosition, _rbd.position);
        if (distanceFromtarget < .1F)
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
        Vector3 moveoffset = _playerSM.transform.forward * _playerSM.MoveSpeed;
        _rbd.MovePosition(_rbd.position + moveoffset);
    }

    public void Tick()
    {
        throw new System.NotImplementedException();
    }
}
