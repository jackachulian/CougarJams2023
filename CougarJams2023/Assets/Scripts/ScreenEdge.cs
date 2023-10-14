using System.Collections;
using UnityEngine;

public class ScreenEdge : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name != "Player") return;
        PlayerHealth health = FindFirstObjectByType<PlayerHealth>();
        Time.timeScale = 0;
        StartCoroutine(HealthTimer(health));
    }
    private IEnumerator HealthTimer(PlayerHealth health)
    {
        while (health.health != 0)
        {
            yield return new WaitForSeconds(0.5f);
            health.health -= 1;
        }
    }
}