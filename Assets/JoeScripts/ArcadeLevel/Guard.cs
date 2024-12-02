using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public int health;
    public NavMeshAgent agent;
    private Transform playerPosition;
    bool isKnocked = false;
    private Rigidbody rb;
    public GameObject hitbox;
    public float attackTime;
    public float maxAttackTime = 1;
    bool isAttacking = false;


    private void Start()
    {
        attackTime = maxAttackTime;
        rb = GetComponent<Rigidbody>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        agent.SetDestination(playerPosition.position);
        if(attackTime > 0 && Vector3.Distance(transform.position, playerPosition.position) <= 2.5) {

            attackTime -= Time.deltaTime;


        }
        else if(!isAttacking && attackTime <= 0)
        {

            StartCoroutine(AttackHit());

        }
        

    }
    private IEnumerator AttackHit()
    {

        isAttacking = true;
        yield return new WaitForSeconds(0.5f);
        hitbox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        hitbox.SetActive(false);
        attackTime = maxAttackTime;
        isAttacking = false;




    }

    void TakeDamage(int amount)
    {

        if (!isKnocked)
        {

            health -= amount;
            StartCoroutine(KnockBack());
        }
        if(health <= 0)
        {

            Destroy(gameObject);
        }


    }


    private IEnumerator KnockBack()
    {
        rb.isKinematic = false;
        rb.velocity = transform.forward * -10;
        isKnocked = true;
        yield return new WaitForSeconds(1f);
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;

        isKnocked = false;




    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BladeHitBox>())
        {
            TakeDamage(20);
        }
    }
}
