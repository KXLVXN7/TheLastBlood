using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject ButtonMenu;
    
    // Health musuh
    public int health = 100;
    private bool isDeadz = false;
    public static bool GameIsPaused = false;
    private int maxHP = 100;

    // Metode untuk mengurangi kesehatan musuh

    public void TakeDamage(int damage)
    {
        if (!isDeadz)
        {
            health -= damage;
            health = Mathf.Clamp(health, 0, maxHP);
            /*         UpdateHealthBar();*/
            StartCoroutine(VisualIndicator(Color.red));
            if (health <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Tidak ada darah lagi");
                ButtonMenu.SetActive(true);
                Diez();
            }
        }
    }
    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.35f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void Diez()
    {
        if (!isDeadz)
        {
            isDeadz = true;
            Debug.Log("Player mati!");
            /*            anim.SetBool("playerDeath", true);*/
            StartCoroutine(DeathPauseAndShowUIz());
        }
    }

    private IEnumerator DeathPauseAndShowUIz()
    {
        /*        Dead.SetActive(true);*/
        Time.timeScale = 0f;
        yield return new WaitForSeconds(3.0f);
        // Di sini Anda dapat menambahkan logika lain, seperti mengakhiri permainan atau mengatur ulang level
        Time.timeScale = 1f;
    }
}
