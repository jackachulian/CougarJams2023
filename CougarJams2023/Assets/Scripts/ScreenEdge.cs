using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenEdge : MonoBehaviour {

    public GameObject GameOver;
    public bool door;

    private void Awake()
    {
        if (!GameOver) GameOver = GameObject.Find("GameOver");
        //print(GameOver.name + " is now found.");
    }

    private void OnTriggerEnter2D(Collider2D other) {
            ScrollingScreen begin = FindFirstObjectByType<ScrollingScreen>();
            if (other.gameObject.name != "Player") return;
            PlayerHealth health = FindFirstObjectByType<PlayerHealth>();
            Time.timeScale = 0;
            StartCoroutine(HealthTimer(health));
            GameOver.SetActive(true);
        
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