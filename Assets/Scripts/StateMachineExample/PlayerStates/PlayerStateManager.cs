using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerStateManager : StateMachineBase
{
    #region Unity Fields
    [SerializeField]
    Material stateMaterial;
    [SerializeField]
    TargetAssigner target;
    [SerializeField]
    public  float RotateSpeed;
    [SerializeField]
    public float MoveSpeed;

    #endregion
    public IdleState IdleState { get; private set; }
    public SearchState SearchState { get; private set; }
    public FoundState FoundState { get; private set; }
    public Vector3 TargetPosition { get; private set; }
    #region Fields
    Rigidbody rbd;
    #endregion
    private void Awake()
    {
        rbd = this.GetComponent<Rigidbody>();
        IdleState = new IdleState(this, stateMaterial, target);
        SearchState = new SearchState(this, stateMaterial, rbd);
        FoundState = new FoundState();
    }
    private void Start()
    {
        ChangeState(IdleState);
    }
}
