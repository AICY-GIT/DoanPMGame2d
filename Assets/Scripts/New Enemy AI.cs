using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewEnemyAI : MonoBehaviour
{
    public Animator animator;

    public bool roaming = true;
    public float moveSpeed;
    public float nextWPDistance;

   
    public Seeker seeker;
    public bool upDateContinuesPath;
    bool reachDestination = false;
    Path path;
    Coroutine moveCorotine;
    //shoot
    public bool isShootable = false;  
    public GameObject EnemyBullet; 
    public float bulletSpeed;
    public float timeBtwFire;
    private float fireCoolDown;
    private void Start()
    {
       
        InvokeRepeating("CalculatePath", 0f, 0.5f);
        reachDestination = true;
    }

    public void CalculatePath()
    {
        Vector2 target = FindTarget();
        if (seeker.IsDone()&&(reachDestination|| upDateContinuesPath))
        {
            seeker.StartPath(transform.position, target, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (p.error) return;
        path = p;
        //move to target 
        MoveToTarget();
    }
    public void MoveToTarget()
    {
        if (moveCorotine != null) StopCoroutine(moveCorotine);
        moveCorotine = StartCoroutine(MoveToTargetCorotine());
    }
    private void Update()
    {
        fireCoolDown -= Time.deltaTime;
        if (fireCoolDown < 0)
        {
            fireCoolDown = timeBtwFire;
            EmemyFireBullet();
        }
    }
    void EmemyFireBullet()
    {
        var bullet = Instantiate(EnemyBullet, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector3 playerPos = FindObjectOfType<PlayerMovement>().transform.position;
        Vector3 direction = playerPos - transform.position;
        rb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);

    }
    IEnumerator MoveToTargetCorotine()
    {
        int currentWP = 0;
        reachDestination = false;
        animator.SetBool("IsWalking", true);

        while (currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)force;

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWPDistance)
            {
                currentWP++;
            }
            yield return null;
        }

        reachDestination = true;
        animator.SetBool("IsWalking", false);
    }

   
    Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<PlayerMovement>().transform.position;
        if (roaming==true)
        {
           return (Vector2)playerPos + Random.Range(10f,50f)*new Vector2(Random.Range(-1,1),Random.Range(-1,1)).normalized;
        }
        else
        {
            return playerPos;
        }
    }
}
