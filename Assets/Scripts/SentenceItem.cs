using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SentenceItem
{
    [TextArea(3, 10)]
    public string text;

    public bool yesNo;
}
