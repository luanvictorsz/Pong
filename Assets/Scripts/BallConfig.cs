using UnityEngine.SceneManagement;
using UnityEngine;

public class BallConfig : MonoBehaviour
{
    //setando configurações da bolinha
    [Header("Configure")]
    [SerializeField] public Rigidbody2D rig;
    [SerializeField] private float speed;

    //configuração de implementação de velocidade da bolinha
    private float initialSpeed;
    private float incrementalSpeed = 1f;
    private Vector2 ballSpeed;

    //Configuração de implementação de som ao jogo
    [Header("Sound settings")]
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
            rig.linearVelocity = ballSpeed;
        }
    }

    #region MetodosImplementados
    void InitialPos()
    {
        int pos = Random.Range(1, 4);

        if(pos == 1)
        {
            ballSpeed.x = speed;
            ballSpeed.y = speed;
        }
        if(pos == 2)
        {
            ballSpeed.x = speed;
            ballSpeed.y = -speed;
        }
        if(pos == 3)
        {
            ballSpeed.x = -speed;
            ballSpeed.y = speed;
        }
        if(pos == 4)
        {
            ballSpeed.x = -speed;
            ballSpeed.y = -speed;
        }
    }

    void ExitScene()
    {
        if(transform.position.x > limitPosX || transform.position.x < -limitPosX)
        {
            SceneManager.LoadScene("Game");
            speed = initialSpeed;
        }
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("raquete"))
        {
            AudioSource.PlayClipAtPoint(soundBall, camPosition.transform.position);
        }

        speed += incrementalSpeed;
    }
}