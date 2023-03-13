using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;

    private void Start()
    {
        posOffset.x = 2.5f;
        posOffset.y = 1.5f;
        posOffset.z = -10;
        timeOffset = 0.2f;
    }

    void Update()
    {
        if(player.GetComponent<Rigidbody2D>().velocity.x > 0.1f)
        {
            posOffset.x = Mathf.Abs(posOffset.x);
        }else if(player.GetComponent<Rigidbody2D>().velocity.x < -0.1f)
        {
            posOffset.x = -Mathf.Abs(posOffset.x);
        }
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}
