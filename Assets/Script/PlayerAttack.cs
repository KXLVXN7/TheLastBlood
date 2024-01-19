using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public Animator playerAnim;
    public Transform attackPoint;
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
    }

    private IEnumerator ResetAttack()
    {
        // Wait for the duration of the attack animation
        yield return new WaitForSeconds(playerAnim.GetCurrentAnimatorClipInfo(0).Length);

        // Reset the attack boolean parameter
        playerAnim.SetBool("attack_1", false);

        isAttacking = false;
    }

    // Metode ini akan dipanggil ketika objek pemain bersentuhan dengan collider lain yang memiliki tag "Enemy"
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Dapatkan komponen skrip Enemy dari objek musuh
            Enemy enemy = other.GetComponent<Enemy>();

            // Pastikan objek musuh memiliki komponen Enemy
            if (enemy != null)
            {
                // Panggil metode TakeDamage pada objek Enemy dengan damage yang telah ditentukan
                enemy.TakeDamage(attackDamage);
            }
        }
    }
}
