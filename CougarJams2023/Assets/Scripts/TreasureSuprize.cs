using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSuprize : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject gameObject1;
    public GameObject gameObject2;
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameObject.SetActive(true);
            gameObject1.SetActive(true);
            gameObject2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
