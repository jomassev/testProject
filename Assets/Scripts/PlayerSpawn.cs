
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private Vector2 lastCheckpoint;
    public Vector2 LastCheckpoint { get => lastCheckpoint; set => lastCheckpoint = value; }
    private Transform cameraTransform;
    private Transform playerTransform;


    private void Awake()
    {
        lastCheckpoint = transform.position;
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Spawn initial
        playerTransform.position = transform.position;
        cameraTransform.position = transform.position;
    }
}
