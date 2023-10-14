using System.Collections;
using UnityEngine;

public class ScrollingScreen : MonoBehaviour {
    public ScrollManager scrollManager;
    GameObject rightEdge;
    public GameObject player;

    void Start() {
        Time.timeScale = 1;
        rightEdge = gameObject;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player.GetComponent<Collider2D>())
        {
            scrollManager.isScrolling = true;
            StartCoroutine(StartupTimer());      
        }
            
    }

    private IEnumerator StartupTimer()
    {
        yield return new WaitForSecondsRealtime(2f);
        rightEdge.AddComponent<ScreenEdge>();
    }
}