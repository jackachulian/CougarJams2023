using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollow : MonoBehaviour
{
    public Transform player;
    public float minX;
    public float maxX;
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= minX && player.transform.position.x <= maxX)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
