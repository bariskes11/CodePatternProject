using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerStateManager : StateMachineBase
{
    #region Unity Fields
  
 
    [SerializeField]
    TargetAssigner target;
    [SerializeField]
    public  float RotateSpeed;
    [SerializeField]
    public float MoveSpeed;

    #endregion
    #region Public States
    public IdleState IdleState { get; private set; }
    public SearchState SearchState { get; private set; }
    public FoundState FoundState { get; private set; }
    #endregion
    public Vector3 TargetPosition { get;  set; }
    #region Fields
    Material stateMaterial;
    Rigidbody rbd;
    #endregion
    private void Awake()
    {
        rbd = this.GetComponent<Rigidbody>();
        stateMaterial = this.GetComponent<MeshRenderer>().material;
        IdleState = new IdleState(this, stateMaterial, target);
        SearchState = new SearchState(this, stateMaterial, rbd);
        FoundState = new FoundState(this,stateMaterial,target);
    }
    private void Start()
    {
        ChangeState(IdleState);
    }





}
