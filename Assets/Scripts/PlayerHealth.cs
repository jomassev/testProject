using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool isInvincible = false;
    public SpriteRenderer graphics;

    public float invincibilityTime;
    public float invicibilityFlashDelay;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance de PlayerHealth");
            return;
        }

        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        invicibilityFlashDelay = 0.15f;
        invincibilityTime = 2f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(60);
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

            if (currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void Die()
    {
        // Bloquer mouvements du perso
        PlayerMovement.instance.enabled = false;

        // Jouer animation de mort
        PlayerMovement.instance.Animator.SetTrigger("Death");

        // Empêcher interactions avec autres éléments de la scène
        PlayerMovement.instance.Rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.PlayerCollider.enabled = false;

        // Lance le menu Game Over
        GameOverManager.instance.OnPlayerDeath();
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
        while (isInvincible)
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
