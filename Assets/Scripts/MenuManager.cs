using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Animator animator;
    public GameObject sceneManager;

    float curTime, initTime;
    bool open = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > 1.5f && !open)
        {
            animator.SetBool("isOpen", true);
            open = true;
        }

    }

    public void StartGame ()
    {
        animator.SetBool("isOpen", false);
        StartCoroutine("menuEnd");

    }

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator menuEnd ()
    {
        while (!(animator.GetCurrentAnimatorStateInfo(0).IsName("MenuBoxEnd")))
        {
            yield return null;
        }
        sceneManager.GetComponent<LoadScenes>().LoadRoom();
    }

}
