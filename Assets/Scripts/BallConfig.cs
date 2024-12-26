using NUnit.Framework.Internal;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BallConfig : MonoBehaviour
{
    public Rigidbody2D rig;
    public float speed;
    private Vector2 ballSpeed;

    private float limitPosX = 10f;
    void Start()
    {
        InitialPos();
    }

    void Update()
    {
        ExitScene();
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

    void ExitScene()
    {
        if(transform.position.x > limitPosX || transform.position.x < -limitPosX)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
