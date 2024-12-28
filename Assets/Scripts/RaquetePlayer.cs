using UnityEngine;
public class RaquetePlayer : MonoBehaviour
{
    private Vector3 myPos;
    private float posY;
    public float limit = 3.5f;

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

        //Limitando a tela
        if (posY < -limit)
        {
            posY = -limit;
        }
        if (posY > limit)
        {
            posY = limit;
        }
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
                if (Input.GetKey(KeyCode.W))
                {
                    posY += deltaVelocity;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    posY -= deltaVelocity;
                }
            }
            else
            {
                //Ativando Inteligencia Artificial
                if (Input.GetKeyDown(KeyCode.Return) && !automatic)
                {
                    automatic = true;
                } 
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    posY += deltaVelocity;
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    posY -= deltaVelocity;
                }
            }   
        }
        else
        {
            //Desativando Inteligencia Artificial
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                automatic = false;
            }

            float responseTime = Random.Range(0.1f, 0.15f);
            //IA Seguindo a Posicao da Bolinha
            posY = Mathf.Lerp(posY, ballPos.position.y, responseTime);
        }
    }
}
