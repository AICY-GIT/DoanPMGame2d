using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int Maxhealth;
    int currentHeal;
    public HealthBar HealthBar;
    public GameObject pauseMenu;
    public float safeTime = 1f;
    public float saveTimeCooldown;
    private void Start()
    {
        currentHeal = Maxhealth;
        HealthBar.UpdateBar(currentHeal, Maxhealth);

    }
    public void TakeDamege(int damage)
    {
        if (saveTimeCooldown <= 0)
        {

            currentHeal -= damage;
            if (currentHeal <= 0)
            {
                currentHeal = 0;
                pauseMenu.SetActive(true);
            }
            saveTimeCooldown = safeTime;
            HealthBar.UpdateBar(currentHeal, Maxhealth);
        }
    }
    private void Update()
    {
        saveTimeCooldown-=Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            TakeDamege(20);
        }
    }
}
