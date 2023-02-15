using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefenseStateManager : MonoBehaviour
{
    public GameObject movePoint;
    public NavMeshAgent defenseAgent;

    public Vector3 defenseLocation;
    public Quaternion defenseRotation;

   DefenseStateSetter currentState;
   public WanderState wanderState = new WanderState();
   public DefendState defendState = new DefendState();
   public DefenceAttackState attackState = new DefenceAttackState();
   public DefenseDeath defenseDeath = new DefenseDeath();

    public GameObject defenseGolem;

    public int directionPick = 0;

    public List<GameObject> enemyList= new List<GameObject>();

   

    void Start()
    {
        defenseAgent = GetComponent<NavMeshAgent>();
        currentState = wanderState;
        defenseLocation = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
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

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
           enemyList.Add(other.gameObject);
            SwitchState(defendState);
        }
    }




}
