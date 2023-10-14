using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] private int damage = 1;

    [SerializeField] private float destroyTime = 100f;

    private void Update() {
        destroyTime -= Time.deltaTime;
        if (destroyTime <= 0) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();

        if (enemyHealth) {
            enemyHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    public void SetDestroyTime(float destroyTime) {
        this.destroyTime = destroyTime;
    }
}