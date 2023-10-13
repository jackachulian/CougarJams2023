using UnityEngine;

public class ScrollingScreen : MonoBehaviour {
    [SerializeField] public float scrollSpeed = 2f;

    void Start() {
        
    }

    void Update() {
        transform.position = transform.position + Vector3.right * scrollSpeed * Time.deltaTime;
    }
}