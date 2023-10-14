using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    [SerializeField] private int hp = 2;

    public void TakeDamage(int damage) {
        hp -= damage;
        if (hp <= 0) {
            Destroy(gameObject);
        }
    }
}