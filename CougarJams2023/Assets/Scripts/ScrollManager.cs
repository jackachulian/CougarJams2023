using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    [SerializeField] public float scrollSpeed = 2f;
    public bool isScrolling;

    [SerializeField] private GameObject cameraOgj;
    [SerializeField] private GameObject leftEdge;
    [SerializeField] private GameObject rightEdge;

    public ScrollingScreen scrollingScreen;

    private void Update()
    {
        if(isScrolling)
        {
            if (!scrollingScreen.isFlipped)
            {
                cameraOgj.transform.position = cameraOgj.transform.position + Vector3.right * scrollSpeed * Time.deltaTime;
                leftEdge.transform.position = leftEdge.transform.position + Vector3.right * scrollSpeed * Time.deltaTime;
                rightEdge.transform.position = rightEdge.transform.position + Vector3.right * scrollSpeed * Time.deltaTime;
            } else
            {
                cameraOgj.transform.position = cameraOgj.transform.position + Vector3.left * scrollSpeed * Time.deltaTime;
                leftEdge.transform.position = leftEdge.transform.position + Vector3.left * scrollSpeed * Time.deltaTime;
                rightEdge.transform.position = rightEdge.transform.position + Vector3.left * scrollSpeed * Time.deltaTime;
            }
            
        }
    }
}
