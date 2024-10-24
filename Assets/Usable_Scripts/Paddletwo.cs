using UnityEngine;

public class Paddletwo : MonoBehaviour
{
    public GameObject ball;
    public GameObject ray;
    public GameObject paddle2;

    Vector2 direction = Vector2.right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float dt = Time.deltaTime;
        


    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (paddle2.transform.position.y < 16.00f)
            {
                paddle2.transform.position += Vector3.up * 5 * dt;

            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (paddle2.transform.position.y > -16.00f)
            {
                paddle2.transform.position += Vector3.down * 5 * dt;

            }

        }

        RaycastHit2D paddlehit1 = Physics2D.Raycast(ray.transform.position, Vector2.left, 0.1f);
        Debug.DrawRay(ray.transform.position, Vector2.left * paddlehit1.distance, Color.red);

        if (paddlehit1 != false)

        {
            Debug.Log("gothim" + paddlehit1.collider.name);

            float angle = 30.0f * Mathf.Deg2Rad;
            direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            ball.transform.position = Vector3.zero;
            //ball.transform.position += Vector3.left * 5 * dt;

            Vector3 change = direction * 2.0f * dt;
            ball.transform.position += change;


            //Ping_Pong.transform.position += Vector3.right * 0.5f * dt;
        }


    }
}
