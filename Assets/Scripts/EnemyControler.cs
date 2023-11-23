using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    PlayerHealth players;
    public int minDamage;
    public int maxDamage;
    private bool isDamaging = false;
    health enemythealth;
    private void Start()
    {
        enemythealth=GetComponent<health>();
    }
    public void TakeDamage(int damage)
    {
      
        enemythealth.TakeDam(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isDamaging)
        {
            players = collision.GetComponent<PlayerHealth>();
            isDamaging = true;
            InvokeRepeating("DamagePlayer", 0, 0.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            players = null;
            isDamaging = false;
            CancelInvoke("DamagePlayer");
        }
    }

    void DamagePlayer()
    {
        if (players != null)
        {
            int damage = UnityEngine.Random.Range(minDamage, maxDamage);
            players.TakeDamage(damage);
           
        }
    }
}

