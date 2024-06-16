using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVisual : MonoBehaviour
{
    public Color Color => spriteRenderer.color;
    public SpriteRenderer spriteRenderer;
    private Player player;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = player.BulletColor;
    }
    
}
