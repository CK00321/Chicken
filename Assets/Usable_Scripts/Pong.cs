using UnityEngine;

public class Pong : MonoBehaviour
{
    //things required for a raycast operation
    //public Vector2 PointOfStart;
    //public Vector2 PathOfRay;
    public float range = 10.00f;

    //bool
    public bool paddlehit1 = false;

    public GameObject ray;
    public GameObject paddle1;

    void Update()
    {
        float dt = Time.deltaTime;
        float paddleSpeed = 5.0f;
        if (Input.GetKey(KeyCode.W))
        {
            if (paddle1.transform.position.y < 16.00f)
            {
                paddle1.transform.position += Vector3.up * paddleSpeed * dt;

            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (paddle1.transform.position.y > -16.00f)
            {
                paddle1.transform.position += Vector3.down * paddleSpeed * dt;

            }
        }


        
        RaycastHit2D paddlehit1 = Physics2D.Raycast(ray.transform.position,Vector2.right,0.1f);
        Debug.DrawRay(ray.transform.position, Vector2.right * paddlehit1.distance, Color.red);

        if (paddlehit1)

        {
            Debug.Log("gothim"+ paddlehit1.collider.name);

            //Ping_Pong.transform.position += Vector3.right * 0.5f * dt;
        }
    }
}
