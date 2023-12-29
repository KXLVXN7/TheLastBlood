using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName = "Player";
    public int health = 100;
    public int attackPower = 10;
    public Animator playerAnim;
    private bool IsPlayerAlive()
    {
        return health > 0;
    }

    private void Update()
    {
        Attack1();
    }

    // Fungsi ini akan dipanggil setiap frame
    private void Attack1()
    {
        if (IsPlayerAlive() && Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetBool("attack_1", true);
            Debug.Log("Anim attack");
        }
        else if (IsPlayerAlive() && !Input.GetKeyDown(KeyCode.Space)) 
        {
            playerAnim.SetBool("attack_1", false);
        }
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{playerName} menerima {damage} kerusakan. Sisa kesehatan: {health}");

        if (!IsPlayerAlive())
        {
            Debug.Log($"{playerName} dikalahkan!");
            // Lakukan tindakan setelah player dikalahkan.
        }
    }

    public void Attack(Enemy enemy)
    {
        if (enemy != null && enemy.IsEnemyAlive())
        {
            int damage = Random.Range(1, attackPower + 1);
            enemy.ReceiveDamage(damage);
            Debug.Log($"{playerName} menyerang {enemy.enemyName} dan menyebabkan {damage} kerusakan.");
        }
    }
}
