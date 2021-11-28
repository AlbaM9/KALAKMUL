using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    public bool hit;

    public Animator anim;
    public PlayerStats playerhealth;
   

    public Transform player;
    public Rigidbody rb;
    
    // Use this for initialization
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        playerhealth = FindObjectOfType<PlayerStats>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
       
    }
    //PROBAR CON BOOL PARA CANCELAR EL WANDER CUANDO ESTE ATACANDO;
    // Update is called once per frame
    void Update()
    {
       
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            transform.LookAt(agent.nextPosition);
            agent.SetDestination(newPos);
            
            timer = 0;


           
            
        }
        if (Vector3.Distance(transform.position, player.transform.position) <= 5f && !hit)
        {


            /*var lookPos = player.transform.position - transform.position;
             lookPos.y = 0;
             var rotation = Quaternion.LookRotation(lookPos);*/
            agent.speed = 1;
            agent.acceleration = 1;
            agent.angularSpeed = 1;
            transform.LookAt(player);
            agent.SetDestination(player.transform.position);


            anim.SetBool("Attack", false);
        }
        else
        {
            agent.speed = 0.5f;
            agent.acceleration = 0.5f;
            agent.angularSpeed = 0.5f;
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= 0.5f)
        {
            agent.SetDestination(player.transform.position);
            hit = true;
           // rb.constraints = RigidbodyConstraints.FreezeAll;
            anim.SetBool("Attack", true);
        } 
    }
    public void FinalAni()
    {
        anim.SetBool("Attack", false);
        hit = false;
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hitted");
            playerhealth.pHealth -= 10;
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Hitted");
            playerhealth.pHealth -= 10;
        } 
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            agent.SetDestination(player.transform.position);
            hit = true;
            playerhealth.pHealth -= 10*Time.deltaTime;
            anim.SetBool("Attack", true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerhealth.pHealth -= 10 * Time.deltaTime;
            
        }
    }
}
