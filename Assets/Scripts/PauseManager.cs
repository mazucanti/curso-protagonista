using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public Animator animator;
    public bool pause = false;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider == null)
        {
            return;
        }
        else if (hit.collider.gameObject.name == "Pause Button")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Pause();
            }
        }
        else
        {
            return;
        }
    }

    public void Pause()
    {
        animator.SetBool("isOpen", true);
        pause = true;
    }

    public void Resume()
    {
        pause = false;
        animator.SetBool("isOpen", false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
