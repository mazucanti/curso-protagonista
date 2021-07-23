using UnityEngine;
using UnityEngine.UI;

public class e : MonoBehaviour
{
    public Sprite[] sprites;
    public float interval = 0.1f;

    Image image;
    float curTime;
    int spriteIdx;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > interval)
        {
            curTime -= interval;
            spriteIdx = (spriteIdx + 1) % sprites.Length;

            image.sprite = sprites[spriteIdx];

        }
    }
}
