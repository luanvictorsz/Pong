using UnityEngine;

public class RaquetePlayer : MonoBehaviour
{
    private Vector3 myPos;
    private float posY;
    [SerializeField] private float limit;
    [SerializeField] private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        myPos.y = posY; 
        transform.position = myPos;

        if(Input.GetKey(KeyCode.UpArrow))
        {       

            if(posY < limit)
            {
                posY += speed * Time.deltaTime;
            }
        }
        if(Input.GetKey(KeyCode.DownArrow) && posY > -limit)
        {
            posY -= speed * Time.deltaTime;
        }
    }
}
