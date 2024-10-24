using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 vel;
    Vector2 direction = Vector2.right;
    public GameObject ray;
    public float velocity = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float dt = Time.deltaTime;
        float angle = 30.0f * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        transform.position = Vector3.zero;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dt = Time.deltaTime;
        
        RaycastHit2D paddlehit2 = Physics2D.Raycast(ray.transform.position,Vector2.right, 0.06f);
        Debug.DrawRay(ray.transform.position, Vector2.right * paddlehit2.distance, Color.red);
        
        if (paddlehit2 != false)

        {

            Debug.Log("gothim" + paddlehit2.collider.name);
            direction.y = -direction.y;
            Vector3 change = direction * 100 * dt;
            transform.position = change;
        }

        if (paddlehit2 == false) 
        {
            transform.position += Vector3.right * 3.0f * dt;
        }



        void OnCollisionEnter2D(Collision2D collision)
        {
            // Reflect the velocity
            Vector2 reflectedVelocity = Vector2.Reflect(collision.contacts[0].normal, velocity);

            // Update the object's position based on the reflected velocity
            transform.position += reflectedVelocity * Time.deltaTime;







        }
}
