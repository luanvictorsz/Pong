using UnityEngine;
using static UnityEditor.PlayerSettings;

public class RaquetePlayer : MonoBehaviour
{
    private Vector3 myPos;
    private float posY;
    private float limit;

    [SerializeField] private float speed;

    public Transform ballPos;
    public bool player1;
    public bool automatic = false;

    void Start()
    {
        myPos = transform.position;
    }

    void Update()
    {
       
        

        Move();
    }

    void Move()
    {
        float deltaVelocity = speed * Time.deltaTime;
        transform.position = myPos;
        myPos.y = posY;

        if (!automatic)
        {
            if (player1)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    posY += deltaVelocity;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    posY -= deltaVelocity;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    posY += deltaVelocity;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    posY -= deltaVelocity;
                }
            }
        }
        else
        {
            posY = ballPos.position.y;
        }
    }
}
