using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public Color Color => spriteRenderer.color;
    private Color red = new(1f, 0.25f, 0.25f, 1f);
    private Color green = new(0.4f, 1, 0.4f, 1f);
    private Color blue = new(0.3f, 0.5f, 1f, 1f);
    private void Awake()
    {
        float chance = Random.value;
        if (chance < 0.33f)
        {
            spriteRenderer.color = red;
        }
        else if (chance < 0.66f)
        {
            spriteRenderer.color = green;
        }
        else if (chance <= 1f)
        {
            spriteRenderer.color = blue;
        }
    }
}
