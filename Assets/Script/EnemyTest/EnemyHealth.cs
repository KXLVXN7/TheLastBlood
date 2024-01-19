using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    // Health musuh
    public int health = 50;

    // Metode untuk mengurangi kesehatan musuh
    public void TakeDamage(int damage)
    {
        health -= damage;

        // Tambahkan logika tambahan seperti memainkan efek suara atau animasi terkena serangan

        if (health <= 0)
        {
            // Musuh mati, tambahkan logika tambahan jika diperlukan
            Destroy(gameObject);
            Debug.Log("Enemy Mati!");
        }
    }
}
