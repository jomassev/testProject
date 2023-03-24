using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    private bool isInRange;

    [SerializeField]
    private new BoxCollider2D collider;
    private GameObject player;
    private PlayerMovement playerMovement;
    private Text PressE;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        PressE = GameObject.FindGameObjectWithTag("PressE").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isInRange && playerMovement.IsClimbing && Input.GetKeyDown(KeyCode.E))
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
            PressE.enabled = true;
            isInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PressE.enabled = false;
            isInRange = false;
            playerMovement.IsClimbing = false;
            collider.isTrigger = false;
        }
    }
}
