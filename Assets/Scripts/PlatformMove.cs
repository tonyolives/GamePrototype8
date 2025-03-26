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
    public bool moveUp = false;
    public bool moveDown = false;
    public bool verticalTriggered = false;
    public float maxVert;
    public float minVert;

    // for special level 2 platform
    public bool isLevel2Platform1; // the one that triggers the change
    private bool platform1Enabled = false;
    public PlatformMove platform2;
    public bool isLevel2Platform2; // the one that gets changed
    public Color newColor;
    public SpriteRenderer spike1;
    public SpriteRenderer spike2;
    public SpriteRenderer spike3;
    public SpriteRenderer spike4;
    public Collider2D spike1Coll;
    public Collider2D spike2Coll;
    public Collider2D spike3Coll;
    public Collider2D spike4Coll;

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

        if (moveUp && verticalTriggered) {
            transform.position += transform.up * speed * Time.deltaTime;
            if (transform.position.y > maxVert) {
                verticalTriggered = false;
            }
        }
        if (moveDown && verticalTriggered) {
            transform.position -= transform.up * speed * Time.deltaTime;
            if (transform.position.y < minVert) {
                verticalTriggered = false;
            }
        }
    }

    public void Level2Platform1() {
        platform1Enabled = true;
    }

    public void Level2Platform2() {
        spike1.enabled = false;
        spike1Coll.enabled = false;
        spike2.enabled = false;
        spike2Coll.enabled = false;
        spike3.enabled = false;
        spike3Coll.enabled = false;
        spike4.enabled = false;
        spike4Coll.enabled = false;
        // GetComponent<SpriteRenderer>().color = newColor;
        verticalTriggered = true;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (bounce) {
            playerMove.EnemyBoost();
        }
        if (moveUp || moveDown) {
            verticalTriggered = true;
        }
        if (isLevel2Platform1 && platform1Enabled) {
            platform2.Level2Platform2();
        }
    }
}
