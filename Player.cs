using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 3.0f;
    public bool isAttacking;
    public float attackTime = 0.3f;
    private float attackTimer;
    float sizeX;
    float sizeY;
    public Animator anim;
    public Animator swordAnim;
    public PolygonCollider2D swordCollider;

    public int health=5;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sizeX = transform.localScale.x;
        sizeY = transform.localScale.y;
    }

    void Update()
    {
        body.velocity = MoveInput(speed);
        if (MoveInput(speed) != Vector2.zero)
            anim.SetBool("walk", true);
        else anim.SetBool("walk", false);

        if (Input.GetKeyDown(KeyCode.E) && attackTimer <= 0)
        {
            attackTimer = attackTime; swordAnim.SetTrigger("swing");
        }
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
                isAttacking = true;
            }
            else isAttacking = false;

            if (isAttacking) swordCollider.enabled = true;
            else swordCollider.enabled = false;

            transform.localScale = new Vector3(MoveInput(1).x != 0 ? sizeX * MoveInput(1).x : transform.localScale.x, transform.localScale.y);
        

        Vector2 MoveInput(float speed)
        {
            int xInput;
            int yInput;
            if (Input.GetKey(KeyCode.W)) yInput = 1;
            else if (Input.GetKey(KeyCode.S)) yInput = -1;
            else yInput = 0;
            if (Input.GetKey(KeyCode.D)) xInput = 1;
            else if (Input.GetKey(KeyCode.A)) xInput = -1;
            else xInput = 0;
            return new Vector2(xInput * speed, yInput * speed);


        }
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOve");
        }
        Debug.Log(health);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<enemy>() != null)
        {
           // health -= 1;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<enemy>() != null && collision.collider.GetComponent<enemy>().attackTimer==1)
        {
           // health -= 1;
        }
    }
}
