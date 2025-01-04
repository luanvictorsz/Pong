using NUnit.Framework.Internal;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BallConfig : MonoBehaviour
{
    public Rigidbody2D rig;
    [SerializeField] private float speed;
    private float initialSpeed;
    private float incrementalSpeed = 0.5f;
    private Vector2 ballSpeed;
    
    public AudioClip soundBall;
    public Transform camPosition;

    private float limitPosX = 10f;
    private float delay = 2f;

    private bool gameInit;
    void Start()
    {
        initialSpeed = speed;
    }

    void Update()
    {
        ExitScene();

        delay -= Time.deltaTime;

        if(delay <= 0 && gameInit == false)
        {
            gameInit = true;
            InitialPos();
        }
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
            speed = initialSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.CompareTag("raquete"))
        {
            AudioSource.PlayClipAtPoint(soundBall, camPosition.transform.position);
            speed += incrementalSpeed;
        }
    }
}
