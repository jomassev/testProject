using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    private Animator fadeSystem;
    private GameObject player;
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.5f);
        collision.transform.position = playerMovement.GetLastCheckpoint();
        fadeSystem.SetTrigger("FadeOut");
        playerHealth.TakeDamage(30);
    }
}
