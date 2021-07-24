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
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementAxis * movementSpeed * Time.fixedDeltaTime);
    }
}
