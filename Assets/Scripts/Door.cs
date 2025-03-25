using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int nextSceneIndex = 1;
    void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
