using UnityEngine;

public class ScrollingScreen : MonoBehaviour {
    [SerializeField] public float scrollSpeed = 2f;

    void Start() {
        Time.timeScale = 1;
    }

    void Update() {
        transform.position = transform.position + Vector3.right * scrollSpeed * Time.deltaTime;
    }
}