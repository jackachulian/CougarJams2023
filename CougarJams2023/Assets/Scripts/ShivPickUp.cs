using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShivPickUp : MonoBehaviour
{
    public PlayerAttack playerAttack;
    public GameObject model;

    private void Start() {
        if (!playerAttack) playerAttack = FindFirstObjectByType<PlayerAttack>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        playerAttack.enabled = true;
        model.SetActive(false);
        gameObject.SetActive(false);
    }
}
