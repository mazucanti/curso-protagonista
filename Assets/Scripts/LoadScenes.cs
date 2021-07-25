using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void LoadRoom()
    {
        SceneManager.LoadScene("Classroom");
    }

    public void LoadStore()
    {
        SceneManager.LoadScene("Shop");
    }
}
