using System.Collections;
using UnityEngine;

public class ScreenEdge : MonoBehaviour {

    public GameObject GameOver;

    private void Awake()
    {
        ScrollingScreen begin = FindFirstObjectByType<ScrollingScreen>();
        if (!begin) 
        {
            GameOver = GameObject.Find("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        ScrollingScreen begin = FindFirstObjectByType<ScrollingScreen>();
        if (other.gameObject.name != "Player") return;
        PlayerHealth health = FindFirstObjectByType<PlayerHealth>();
        if (begin)
        {
            Time.timeScale = 0;
            StartCoroutine(HealthTimer(health));
            GameOver.SetActive(true);
        }
    }
    private IEnumerator HealthTimer(PlayerHealth health)
    {
        while (health.health != 0)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            health.health -= 1;
        }
    }


}