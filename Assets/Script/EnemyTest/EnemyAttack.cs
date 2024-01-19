using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 20;
    public int enragedAttackDamage = 40;
    public Transform attackPoint;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public float attackCooldown = 2f; // Waktu cooldown antar serangan
    private float nextAttackTime = 0f;

    private void Update()
    {
        // Periksa cooldown sebelum melakukan serangan
        if (Time.time >= nextAttackTime)
        {
            PerformAttack();
        }
    }

    private void PerformAttack()
    {
        enemyAttack();

        // Set waktu cooldown untuk serangan berikutnya
        nextAttackTime = Time.time + attackCooldown;
    }

    private void enemyAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(pos, attackRange, attackMask);

        foreach (Collider2D playerCollider in hitPlayers)
        {
            Health playerHealth = playerCollider.GetComponent<Health>();

            // Pastikan objek pemain memiliki komponen Health
            if (playerHealth != null)
            {
                playerHealth.takeDamage(10);
                Debug.Log("Enemy menyerang Player");
            }
        }
    }

    private void EnragedAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(attackPoint.position, attackRange, attackMask);

        if (colInfo != null)
        {
            colInfo.GetComponent<Health>().takeDamage(enragedAttackDamage);
        }
    }

    // Hanya untuk contoh, bukan implementasi yang optimal
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();

            // Pastikan objek pemain memiliki komponen Health
            if (playerHealth != null)
            {
                playerHealth.takeDamage(10);
            }
        }
    }
}
