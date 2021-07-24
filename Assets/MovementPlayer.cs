using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("spacebar clicked");
            NPC.GetComponent<Interactable>().StartDialogue();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementAxis * movementSpeed * Time.fixedDeltaTime);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.CompareTag("NPC"))
        {
            Debug.Log("collision");
            collisionNPC = true;
            NPC = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("collision exit");

        collisionNPC = false;
    }
}
