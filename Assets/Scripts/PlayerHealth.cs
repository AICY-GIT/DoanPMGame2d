using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int Maxhealth;
    int currentHeal;
    public HealthBar HealthBar;
    public GameObject pauseMenu;
    public float safeTime = 2f; // Adjusted safeTime to 2 seconds
    private float saveTimeCooldown = 0f;

    private void Start()
    {
        currentHeal = Maxhealth;
        HealthBar.UpdateBar(currentHeal, Maxhealth);
    }

    private void Update()
    {
        // Decrement the cooldown in Update
        if (saveTimeCooldown > 0)
        {
            saveTimeCooldown -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        if (saveTimeCooldown <= 0)
        {
            currentHeal -= damage;

            if (currentHeal <= 0)
            {
                currentHeal = 0;
                pauseMenu.SetActive(true);
            }

            // Reset the damage cooldown
            saveTimeCooldown = safeTime;
            HealthBar.UpdateBar(currentHeal, Maxhealth);
        }

        // Log the remaining cooldown time in green
        Debug.Log("<color=green>Remaining Cooldown Time: " + saveTimeCooldown + "</color>");
    }
}


