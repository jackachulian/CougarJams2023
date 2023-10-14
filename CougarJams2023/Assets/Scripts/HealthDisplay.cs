using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public GameObject[] hearts;

    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        if (!playerHealth) playerHealth = FindFirstObjectByType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        health = playerHealth.health;
        maxHealth = playerHealth.maxHealth;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].GetComponent<Image>().sprite = fullHeart;
            }
            else
            {
                hearts[i].GetComponent<Image>().sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].GetComponent<Image>().enabled = true;
            }
            else
            {
                hearts[i].GetComponent<Image>().enabled = false;
            }
        }
    }
}
