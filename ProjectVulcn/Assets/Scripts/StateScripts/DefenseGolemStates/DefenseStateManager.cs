using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseStateManager : MonoBehaviour
{
    Vector3 defenseLocation;
    Quaternion defenseRotation;

    DefenseStateSetter currentState;
   public WanderState wanderState = new WanderState();
   public DefendState defendState = new DefendState();
   public DefenseDeath defenseDeath = new DefenseDeath();



    public GameObject generateButton;

    public GameObject defenseGolem;

    public List<GameObject> defensePointz;

    public bool patrolPointSet = false;

    void Start()
    {
        currentState = wanderState;
        defenseLocation = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1f);
        defenseRotation = Quaternion.identity;
    }

    void Update()
    {
        currentState.RunCurrentState(this);
    }

    public void SwitchState(DefenseStateSetter nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }








}
