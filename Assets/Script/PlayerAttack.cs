using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Experimental.GraphView;

public class PlayerAttack : MonoBehaviour
{
    public Animator playerAnim;
    public Transform attackPoint;
/*    public Vector3 direction;*/
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private bool isAttacking = false;

    // Damage yang akan diberikan saat menyerang
    public int attackDamage = 10;

    private void Update()
    {
        AttackInput();
    }

    private void AttackInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            Attack();
            Debug.Log("Attack");
        }
        else if (!isAttacking)
        {
            // Reset the attack boolean parameter
            playerAnim.SetBool("attack_1", false);
            /*Debug.Log("Not Attacking");*/
        }
    }

    private void Attack()
    {
        PerformAttack();
    }

    private void PerformAttack()
    {
        isAttacking = true;

        // Set the attack boolean parameter to true
        playerAnim.SetBool("attack_1", true);

        // Call a method to reset the attack after a duration (adjust as needed)
        StartCoroutine(ResetAttack());

        // Detect Enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

   

        // damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(10);
            Debug.Log("Kamu telah menyerang Enemy");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
           return;
        
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }

    private IEnumerator ResetAttack()
    {
        // Wait for the duration of the attack animation
        yield return new WaitForSeconds(playerAnim.GetCurrentAnimatorClipInfo(0).Length);

        // Reset the attack boolean parameter
        playerAnim.SetBool("attack_1", false);

        isAttacking = false;
    }

   /* public void SetDirection(Vector3 newDirection)
    {
       
        direction = newDirection;
    }*/
    // Metode ini akan dipanggil ketika objek pemain bersentuhan dengan collider lain yang memiliki tag "Enemy"
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Dapatkan komponen skrip Enemy dari objek musuh
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();

            // Pastikan objek musuh memiliki komponen Enemy
            if (enemy != null)
            {
                // Panggil metode TakeDamage pada objek Enemy dengan damage yang telah ditentukan
                enemy.TakeDamage(attackDamage);
            }
        }
    }
}
