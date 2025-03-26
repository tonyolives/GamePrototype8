using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int nextSceneIndex = 1;
    public bool isBlueLevel2Door = false;
    public PlatformMove platform1;
    public GameObject heart;
    public Vector2 teleportPos;
    public GameObject player;
    void OnTriggerEnter2D(Collider2D other) {
        if (!isBlueLevel2Door) {
            SceneManager.LoadScene(nextSceneIndex);
        }
        if (isBlueLevel2Door) {
            Destroy(heart);
            player.transform.position = teleportPos;
            platform1.Level2Platform1();
        }
    }
}
