using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseStateManager : MonoBehaviour
{
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
        if(collision.collider.tag == "Scrap")
        {
            print("owie");
        }



        if(collision.collider.tag == "Ship")
        {
            wanderState.moveSpeed = 0.0f;
            StartCoroutine(rotateTimer());
            IEnumerator rotateTimer()
            {
                if(wanderState.newGolemX > 0.0f)
                {
                    wanderState.newGolemX -= 10.0f;
                }
                if(wanderState.newGolemX < 0.0f)
                {
                    wanderState.newGolemX += 10.0f;
                }
                yield return new WaitForSeconds(0.5f);
                wanderState.moveSpeed = 1.5f;
            }
        }
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
