using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName = "Player";
    public int health = 100;
    public int attackPower = 10;
    public Animation playerAnim;
    private bool IsPlayerAlive()
    {
        return health > 0;
    }

    // Fungsi ini akan dipanggil setiap frame
    void OnCollisionEnter2D()
    {
        // Pemain dapat menanggapi serangan musuh selama pemain masih hidu
        if (IsPlayerAlive())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Pemain menyerang saat tombol spasi ditekan
                Attack(FindObjectOfType<Enemy>());
            }
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
