using UnityEngine;

public class ScreenEdge : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name != "Player") return;
        PlayerHealth health = FindFirstObjectByType<PlayerHealth>();
        Time.timeScale = 0;
        health.TakeDamage(999);
    }
}