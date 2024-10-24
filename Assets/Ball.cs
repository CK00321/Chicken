
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{   // GAME OBJECT ACCESS
    public Transform paddleOne; // Paddle One Controls
    public Transform paddleTwo; // Paddle Two Controls
    public Transform border1;    // BORDER FOR SCORE
    public Transform border2;    // SAME AS 
    public Text Player1;
    public Text Player2;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    public Vector2 originalPos;


    //SVORE VARIABLE
    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0 ;

    BoxCollider2D collider;

    Vector2 direction = Vector2.right; // Initial direction of the ball

    float speed = 5.0f; // X Speed of Ball

    Vector2 directionn = Vector2.up; // Y Direction of Ball

    float speedd = 2.0f; // Y Speed of Ball

    public float paddleHeight = 2.0f; // Height of Paddle

    //GAME PROPERTIES
    public SpriteRenderer sr;
    public SpriteRenderer p1;
    public SpriteRenderer p2;
    
    

    // Start is called once before the first execution of Update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();

        Player1.text = scorePlayer1.ToString();
        Player2.text = scorePlayer2.ToString();

        //Button Button = GetComponent<Button>();
        //Button.onClick.AddListener(Reset);
        transform.position = Vector3.zero;
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }


    // Update is called once per frame
    void Update()
    {
                 
        // Bounce off walls
        if (transform.position.x > 10.0f)
        {
            direction.x = -direction.x;
        }
        // If the ball is too far left, make its x-direction positive (1%)
        if (transform.position.x < -10.0f)
        {
            direction.x = -direction.x;

        }
        // If the ball is too far up, make its y-direction negative (1%)
        if (transform.position.y > 5.0f)
        {
            directionn.y = -directionn.y;
            //Debug.Log("the_score_holder");
        }
        // If the ball is too far down, make its y-direction positive (1%)
        if (transform.position.y < -5.0f)
        {
            directionn.y = -directionn.y;
            
        }

        // Move the ball
        float dt = Time.deltaTime;
        Vector3 change = direction * speed * dt;
        transform.position += change;

        float dtt = Time.deltaTime;
        Vector3 changee = directionn * speedd * dtt;
        transform.position += changee;

        // Check paddle collisions
        Vector2 ballPos = transform.position;

        // Paddle One Collision
        if (ballPos.x < paddleOne.position.x + 0.5f)
        {
            if (ballPos.x > paddleOne.position.x)
            {
                if (ballPos.y < paddleOne.position.y + paddleHeight / 2)
                {
                    if (ballPos.y > paddleOne.position.y - paddleHeight / 2)
                    {
                        direction.x = -direction.x;
                        audioSource.PlayOneShot(clip, 0.8f);
                        //color coder
                        sr.color = Random.ColorHSV();
                        p1.color = Color.black;
                        p2.color = Color.white;
                    }
                }
            }
        }


        // Paddle Two Collision
        if (ballPos.x > paddleTwo.position.x - 0.5f)
        {
            if (ballPos.x < paddleTwo.position.x)
            {
                if (ballPos.y < paddleTwo.position.y + paddleHeight / 2)
                {
                    if (ballPos.y > paddleTwo.position.y - paddleHeight / 2)
                    {
                        direction.x = -direction.x;
                        audioSource.PlayOneShot(clip, 0.8f);

                        //color coder
                        sr.color = Random.ColorHSV();
                        p1.color = Color.white;
                        p2.color = Color.black;

                    }
                }
            }
        }

        //SCORE_SCORE_AND_RESET_SCENE

        //GET_THE_SCENE_MANAGER_AND_RESET_WITH_NAME
        string SampleScene = SceneManager.GetActiveScene().name;

        if (ballPos.x > 10) 
        {
            Debug.Log("!");
            Player2.text = scorePlayer1.ToString();
            scorePlayer1 += 1;

            gameObject.transform.position = originalPos;

        }

        if (ballPos.x < -10)
        {
            Debug.Log("!!!!");
            Player1.text = scorePlayer2.ToString() ;
            scorePlayer2 += 1;

            gameObject.transform.position = originalPos;
        }

        // Load
        
        if (scorePlayer1 > 10) 
        {
            SceneManager.LoadScene(SampleScene);
        }

        if (scorePlayer2 > 10) 
        {
            SceneManager.LoadScene(SampleScene);
        }
    }
}
