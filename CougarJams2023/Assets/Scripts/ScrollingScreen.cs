using UnityEngine;

public class ScrollingScreen : MonoBehaviour {
    [SerializeField] public float scrollSpeed = 2f;
    public bool begin = false;
    void Start() {
        Time.timeScale = 1;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        ScreenEdge screenEdge = other.gameObject.GetComponent<ScreenEdge>();

        if (screenEdge)
        {
            begin = true;
        }
    }
    void Update() {
        if (begin)
        {
            transform.position = transform.position + Vector3.right * scrollSpeed * Time.deltaTime;
        }
    }
}