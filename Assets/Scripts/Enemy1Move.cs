using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    public float minPos;
    public float maxPos;
    public float speed = 3f;
    public PlayerMovement playerMove;
    private bool directionRight = true;
    public bool onPlatform = false;
    public GameObject platform;
    void Update()
    {
        if (directionRight) {
            transform.position += transform.right * speed * Time.deltaTime;
            if (transform.position.x > maxPos && !onPlatform) {
                directionRight = false;
            }
            if (onPlatform) {
                float newMax = platform.transform.position.x + maxPos;
                if (transform.position.x > newMax) {
                    directionRight = false;
                }
            }
        }
        else {
            transform.position += -transform.right * speed * Time.deltaTime;
            if (transform.position.x < minPos && !onPlatform) {
                directionRight = true;
            }
            if (onPlatform) {
                float newMin = platform.transform.position.x + minPos;
                if (transform.position.x < newMin) {
                    directionRight = true;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        playerMove.EnemyBoost();
    }
}
