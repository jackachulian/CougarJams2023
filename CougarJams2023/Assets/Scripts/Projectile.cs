using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] private int damage = 1;

    private void OnCollisionEnter2D(Collision2D other) {
        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();

        if (enemyHealth) {
            enemyHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}