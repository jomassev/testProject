using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool isInvincible = false;
    public SpriteRenderer graphics;

    public float invincibilityTime;
    public float invicibilityFlashDelay;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        invicibilityFlashDelay = 0.15f;
        invincibilityTime = 2f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            GainHealth(10);
        }
        currentHealth = (int)healthBar.slider.value;
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void GainHealth(int heal)
    {
        int healAmount = currentHealth + heal <= maxHealth ? heal : maxHealth - currentHealth;
        Debug.Log(currentHealth);
        Debug.Log(healAmount);
        healthBar.setHealth(currentHealth + healAmount);
    }

    public IEnumerator InvincibilityFlash()
    {
        while(isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }
}
