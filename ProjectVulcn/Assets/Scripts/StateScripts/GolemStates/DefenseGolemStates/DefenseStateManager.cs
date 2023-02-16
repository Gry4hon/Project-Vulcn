using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class DefenseStateManager : MonoBehaviour
{
   DefenseStateSetter currentState;
   public WanderState wanderState = new WanderState();
   public DefendState defendState = new DefendState();
   public DefenceAttackState attackState = new DefenceAttackState();
   public DefenseDeath defenseDeath = new DefenseDeath();

    [Header("TheGolem")]
    public GameObject defenseGolem;
    public BoxCollider searchingHitBox;
    public NavMeshAgent defenseAgent;

    public Vector3 defenseLocation;
    public Quaternion defenseRotation;

    public float golemHealth = 100f;
    public Image golemHealthBar;

    [Header("Targets")]
    public GameObject movePoint;
    public GameObject scrapWolfTarget;


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


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            SwitchState(attackState);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
           scrapWolfTarget =  other.gameObject;
            searchingHitBox.enabled= false;
            SwitchState(defendState);
        }
    }





}
