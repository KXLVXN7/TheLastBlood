using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Animator playerAnim;
    private bool isAttacking = false;

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
}
