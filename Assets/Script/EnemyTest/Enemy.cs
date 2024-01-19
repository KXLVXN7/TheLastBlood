using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName = "Enemy";
    public int health = 50;
    public int attackPower = 5;
    private Player player;  // Reference to the Player script

    private void Start()
    {
        player = FindObjectOfType<Player>();  // Find the Player script in the scene
    }

    private bool IsEnemyAlive()
    {
        return health > 0;
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{enemyName} received {damage} damage. Remaining health: {health}");

        if (!IsEnemyAlive())
        {
            Debug.Log($"{enemyName} has been defeated!");
            // Perform actions after the enemy is defeated.
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        if (player != null)
        {
/*            // You can modify this part based on your attack logic
            player.ReceiveDamage(attackPower);*/
/*            Debug.Log($"{enemyName} attacked {player.playerName} and caused {attackPower} damage.");*/
        }
    }
}
