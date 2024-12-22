using UnityEngine;

public class BallConfig : MonoBehaviour
{
    public Rigidbody2D rig;
    public float speed;
    public Vector2 ballSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballSpeed.x = speed;
        rig.linearVelocity = ballSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
