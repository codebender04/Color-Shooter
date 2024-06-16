using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BulletVisual bulletVisual;
    private static int score = 0;
    private void Awake()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy) && enemy != null && bulletVisual.Color == enemy.enemyVisual.Color)
        {
            enemy.DestroySelf();
            score++;
            Debug.Log(score);
            UIManager.Instance.SetScore(score);
            DestroySelf();
        }
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
