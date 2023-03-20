
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private Transform cameraTransform;
    private Transform playerTransform;

    private void Awake()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Spawn initial
        playerTransform.position = transform.position;
        cameraTransform.position = transform.position;
    }

}
