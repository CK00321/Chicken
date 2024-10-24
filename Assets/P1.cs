using UnityEngine;

public class P1 : MonoBehaviour
{

    BoxCollider2D collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //VECTOR_DIRECTION_FOR_TRANSFORM

        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            // RESTRAINT_THE_PADDLE_MOVEMENT_POSITIVE
            if (transform.position.y < 4.00f)
            {
                direction = Vector2.up;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            // RESTRAINT_THE_PADDLE_MOVEMENT_NEGATIVE
            if (transform.position.y > -4.00f)
            {
                direction = Vector2.down;
            }
        }

        float dt = Time.deltaTime;
        float speed = 10.0f;
        Vector3 change = direction * speed * dt;
        transform.position = transform.position + change;


    }
}