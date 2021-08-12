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
        bool endOfDialogue = FindObjectOfType<DialogueManager>().endOfDialogue;

        movementAxis.x = Input.GetAxisRaw("Horizontal");
        movementAxis.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("X", movementAxis.x);
        animator.SetFloat("Y", movementAxis.y);
        animator.SetFloat("Vel", movementAxis.magnitude);

        if((movementAxis.magnitude > 0.02) && (!pause) && endOfDialogue)
        {
            animator.SetFloat("LastX", movementAxis.x);
            animator.SetFloat("LastY", movementAxis.y);
        }

        // Starts the dialogue when player collides with a NPC and press spacebar + stop player animation
        if (collisionNPC && Input.GetKeyDown(KeyCode.Space))
        {
            NPC.GetComponent<Interactable>().StartDialogue();
        }

        // Player cant walk when in pause state and when a dialogue is active.
        if (pause || (!endOfDialogue))
        {
            movementSpeed = 0;
            animator.SetBool("Stop", true);
        }
        else
        {
            movementSpeed = 5f;
            animator.SetBool("Stop", false);
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
