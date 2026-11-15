using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float speed = 10;
    public ProjectileScript projectilePrefab;
    public Transform launchOffset;
    public float fireRate;
    float nextFire;
    public ScoreScript hp;
    public AudioSource audioPlayer;
    public AudioClip clip;
    public AudioClip clip2;
    public HitScript hit;
    [SerializeField] Sprite[] playerSprites;
    [SerializeField] Sprite nextSprite;

    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();

    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        myRigidbody.velocity = new Vector2(x * speed, y * speed);

        if (transform.position.y < -9)
        {
            myRigidbody.velocity = Vector2.down * 0;
            myRigidbody.velocity = Vector2.up * speed;
        }

        if (transform.position.y > 13)
        {
            myRigidbody.velocity = Vector2.up * 0;
            myRigidbody.velocity = Vector2.down * speed;
        }
        if (transform.position.x < -26)
        {
            myRigidbody.velocity = Vector2.left * 0;
            myRigidbody.velocity = Vector2.right * speed;
        }

        if (transform.position.x > 24)
        {
            myRigidbody.velocity = Vector2.right * 0;
            myRigidbody.velocity = Vector2.left * speed;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            nextSprite = playerSprites[1];
            gameObject.GetComponent<SpriteRenderer>().sprite = nextSprite;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            nextSprite = playerSprites[0];
            gameObject.GetComponent<SpriteRenderer>().sprite = nextSprite;
        }
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time > nextFire)
            {
                nextFire = Time.time +fireRate;
                audioPlayer.PlayOneShot(clip);
                Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "EnemyProjectile")
        {
            hp.Health();
        }

        if (collision.gameObject.tag == "EnemyProjectile")
        {
            Instantiate(hit, transform.position, transform.rotation);
            audioPlayer.PlayOneShot(clip2);
        }
    }
}
