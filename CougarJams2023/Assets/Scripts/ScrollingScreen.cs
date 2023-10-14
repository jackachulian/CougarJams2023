using System.Collections;
using UnityEngine;

public class ScrollingScreen : MonoBehaviour {
    public bool isFlipped;
    public ScrollManager scrollManager;
    GameObject rightEdge;
    GameObject leftEdge;
    public GameObject player;

    void Start() {
        Time.timeScale = 1;
        if (!isFlipped)
        {
            rightEdge = gameObject;
        } else
        {
            leftEdge = gameObject;
        }

        if (!player) player = GameObject.Find("Player");
    }
    void Update()
    {
        if (scrollManager.isScrolling)
        {
            if (!isFlipped)
            {
                transform.position = transform.position + Vector3.right * 2 * Time.deltaTime;
            }
            else
            {
                transform.position = transform.position + Vector3.left * 2 * Time.deltaTime;
            }
        }
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