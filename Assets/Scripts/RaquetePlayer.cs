using UnityEngine;

public class RaquetePlayer : MonoBehaviour
{
    private Vector3 myPos;
    private float posY;
    [SerializeField] private float limit;
    [SerializeField] private float speed;


    public bool player1;

    void Start()
    {
        myPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        myPos.y = posY;
        transform.position = myPos;

        if (player1)
        {     
            if (Input.GetKey(KeyCode.UpArrow))
            {

                if (posY < limit)
                {
                    posY += speed * Time.deltaTime;
                }
            }
            if (Input.GetKey(KeyCode.DownArrow) && posY > -limit)
            {
                posY -= speed * Time.deltaTime;
            }
        }
        else
        { 
            if (Input.GetKey(KeyCode.W))
            {
                if (posY < limit)
                {
                    posY += speed * Time.deltaTime;
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                posY -= speed * Time.deltaTime;
            }
        }
    }
}
