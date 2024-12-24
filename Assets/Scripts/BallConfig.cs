using NUnit.Framework.Internal;
using UnityEngine;

public class BallConfig : MonoBehaviour
{
    public Rigidbody2D rig;
    public float speed;
    private Vector2 ballSpeed;

    void Start()
    {
        InitialPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitialPos()
    {
        int pos = Random.Range(1, 4);

        if(pos == 1)
        {
            ballSpeed.x = speed;
            ballSpeed.y = speed;
        }
        if (pos == 2)
        {
            ballSpeed.x = speed;
            ballSpeed.y = -speed;
        }
        if(pos == 3)
        {
            ballSpeed.x = -speed;
            ballSpeed.y = speed;
        }
        else
        {
            ballSpeed.x = -speed;
            ballSpeed.y = -speed;
        }

        rig.linearVelocity = ballSpeed;
    }
}
