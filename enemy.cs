using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    private Rigidbody2D body;
    public int health = 3;
    bool Attacked;
    float timer;
    public float minDistance;
    Transform player;
    private NavMeshAgent agent;
    public float speed;
    public float attackTimer;
    private Control control;
    public int damage=1;
    //bool Attacking;

    bool touchingPlayer;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        control = GameObject.FindGameObjectWithTag("Control").GetComponent<Control>();
        control.enemies++;
    }
    

    void Update()
    {
        if (health == 0) { Object.Destroy(gameObject); control.enemies--; }
        if (timer > 0) timer -= Time.deltaTime;
        else Attacked = false;
        //Debug.Log(health);

        

        if (Vector2.Distance(transform.position, player.position) < minDistance)
        {
            agent.SetDestination(player.position);
            //agent.speed = speed;
            
        }

        if (Vector2.Distance(transform.position, player.position) < 2 && attackTimer <= 0)
        {
            //Attacking = true;
            //Debug.Log("BOOM");
            attackTimer = 1;
            if (touchingPlayer) player.gameObject.GetComponent<Player>().health-=damage;
        }
        else { attackTimer -= Time.deltaTime; }  //Attacking = false; }
            //Debug.Log(attackTimer);
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Weapon")
        {

                if (!Attacked)
                {
                    health--;
                    timer = 0.32f;
                }
                Attacked = true;

        }
        if(collision.collider.tag == "Player")
        {
            //if (Attacking) { player.gameObject.GetComponent<Player>().health--; attackTimer = 1; }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            touchingPlayer = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            touchingPlayer = false;
        }
    }
}
