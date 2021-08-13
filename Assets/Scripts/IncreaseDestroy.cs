using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDestroy : MonoBehaviour
{
    // Destroys IncreaseText.
    void Start()
    {
        Destroy(gameObject, 1f);
    }
}
