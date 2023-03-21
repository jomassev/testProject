using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isInRange;

    [SerializeField]
    private new BoxCollider2D collider;
    private GameObject player;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerMovement.IsClimbing && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.IsClimbing = false;
            collider.isTrigger = false;
            return;
        }

        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.IsClimbing = true;
            collider.isTrigger = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.IsClimbing = false;
            collider.isTrigger = false;
        }
    }
}
