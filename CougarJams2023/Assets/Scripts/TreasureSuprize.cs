using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSuprize : MonoBehaviour
{
    public GameObject prefab;
    private Vector2 spawnposition;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Instantiate(prefab, new Vector2(-73f,1.81f), Quaternion.identity);
            Instantiate(prefab, new Vector2(-60.3f, 1.81f), Quaternion.identity);
            Instantiate(prefab, new Vector2(-66.7f, 1.81f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
