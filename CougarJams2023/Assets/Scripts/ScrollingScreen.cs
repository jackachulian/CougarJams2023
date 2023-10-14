using System.Collections;
using UnityEngine;

public class ScrollingScreen : MonoBehaviour {
    public ScrollManager scrollManager;
    GameObject rightEdge;
    public GameObject player;

    void Start() {
        Time.timeScale = 1;
        rightEdge = gameObject;

        if (!player) player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.position = transform.position + Vector3.right * 2 * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.activeSelf) return;
        if (!player) return;
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