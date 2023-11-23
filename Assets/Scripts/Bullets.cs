using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;
    public bool friendlyBullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&!friendlyBullet)
        {
            int damage = UnityEngine.Random.Range(minDamage, maxDamage);
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Enemy") && friendlyBullet)
        {
           
            int damage = UnityEngine.Random.Range(minDamage, maxDamage);
            collision.GetComponent<EnemyControler>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
