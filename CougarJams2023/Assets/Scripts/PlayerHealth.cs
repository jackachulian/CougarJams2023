using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 5;
    public int sanity;
    //float currTimer = 0f;
    //float immunityTimer = 1f;
    bool isImmune = false;

    public GameObject GameOver;

    private IEnumerator ImmunityTimer()
    {
        yield return new WaitForSeconds(1f);
        isImmune = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (!isImmune)
        {
            health -= amount;
            isImmune = true;
            StartCoroutine(ImmunityTimer());
        }
        
        //currTimer = 0f;
        if (health <= 0)
        {
            Time.timeScale = 0;
            if (!GameOver) GameOver = GameObject.Find("GameOver");
            GameOver.SetActive(true);
            // TODO: Strengthen Player
            sanity++;
        }

    }
}