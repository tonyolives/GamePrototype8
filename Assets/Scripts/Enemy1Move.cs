using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    public float minPos;
    public float maxPos;
    public float speed = 3f;
    public PlayerMovement playerMove;
    private bool directionRight = true;
    void Update()
    {
        if (directionRight) {
            transform.position += transform.right * speed * Time.deltaTime;
            if (transform.position.x > maxPos) {
                directionRight = false;
            }
        }
        else {
            transform.position += -transform.right * speed * Time.deltaTime;
            if (transform.position.x < minPos) {
                directionRight = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        playerMove.EnemyBoost();
    }
}
