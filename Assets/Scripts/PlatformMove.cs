using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float minPos;
    public float maxPos;
    public float speed = 3f;
    public PlayerMovement playerMove;
    private bool directionRight = true;
    public bool bounce = true;
    public bool moveHoriz = true;
    public bool moveVertical = false;
    public bool verticalTriggered = false;
    public float maxVert;
    void Update()
    {
        if (moveHoriz) {
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

        if (moveVertical && verticalTriggered) {
            transform.position += transform.up * speed * Time.deltaTime;
            if (transform.position.y > maxVert) {
                verticalTriggered = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (bounce) {
            playerMove.EnemyBoost();
        }
        if (moveVertical) {
            verticalTriggered = true;
        }
    }
}
