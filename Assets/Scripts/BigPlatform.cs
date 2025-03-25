using UnityEngine;

public class BigPlatform : MonoBehaviour
{
    public Collider2D leftCollider;
    public Collider2D rightCollider;
    public SpriteRenderer leftSr;
    public SpriteRenderer rightSr;
    void Start()
    {
        leftCollider.enabled = false;
        rightCollider.enabled = false;
        leftSr.enabled = false;
        rightSr.enabled = false;
    }

    void OnCollisionEnter2D (Collision2D collision) {
        leftCollider.enabled = true;
        rightCollider.enabled = true;
        leftSr.enabled = true;
        rightSr.enabled = true;
    }
}
