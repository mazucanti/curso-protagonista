using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movementAxis;
    public Animator animator;
    private bool collisionNPC;
    private Collider2D NPC;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bool pause = FindObjectOfType<PauseManager>().pause;

        movementAxis.x = Input.GetAxisRaw("Horizontal");
        movementAxis.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("X", movementAxis.x);
        animator.SetFloat("Y", movementAxis.y);
        animator.SetFloat("Vel", movementAxis.magnitude);

        if(movementAxis.magnitude > 0.02)
        {
            animator.SetFloat("LastX", movementAxis.x);
            animator.SetFloat("LastY", movementAxis.y);
        }
        if (collisionNPC && Input.GetKeyDown(KeyCode.Space))
        {
            movementSpeed = 0;
            NPC.GetComponent<Interactable>().StartDialogue();
        }

        if (pause)
        {
            movementSpeed = 0;
        }

        if ((FindObjectOfType<DialogueManager>().endOfDialogue) && !pause)
        {
            movementSpeed = 5f;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementAxis * movementSpeed * Time.fixedDeltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("NPC"))
        {
            collisionNPC = true;
            NPC = collision.collider;
        }
    }

    private void OnCollisionExit2D (Collision2D collision)
    {
        collisionNPC = false;
    }

}
