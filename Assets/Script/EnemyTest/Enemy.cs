using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName = "Musuh";
    public int health = 100;
    public int attackPower = 20;

    // Fungsi untuk mengecek apakah musuh masih hidup
    public bool IsEnemyAlive()
    {
        return health > 0;
    }

    // Fungsi untuk menangani serangan musuh
    public void Attack(Player player)
    {
        if (IsEnemyAlive())
        {
            int damage = Random.Range(1, attackPower + 1);
            player.ReceiveDamage(damage);
            Debug.Log($"{enemyName} menyerang player dan menyebabkan {damage} kerusakan.");
        }
    }

    // Fungsi untuk menerima kerusakan dari player
    public void ReceiveDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{enemyName} menerima {damage} kerusakan. Sisa kesehatan: {health}");

        if (!IsEnemyAlive())
        {
            Debug.Log($"{enemyName} dikalahkan!");
            // Lakukan tindakan setelah musuh dikalahkan, misalnya, hancurkan GameObject musuh atau tampilkan pesan kemenangan.
        }
    }
}
