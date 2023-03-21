using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private PlayerSpawn playerSpawn;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").GetComponent<PlayerSpawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSpawn.LastCheckpoint = this.transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
