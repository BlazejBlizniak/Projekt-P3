using UnityEngine;

public class ShooterScript : Spawnables
{
    public ScoreScript score;
    public HitScript hit;
    public EnemyProjectileScript projectilePrefab;
    public Transform launchOffset;
    public AudioClip clip2;
    public float fireRate;
    float nextFire;
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * movementSpeed) * Time.deltaTime;
        if(transform.position.x < 24)
        {
            movementSpeed = 0;
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                audioPlayer.PlayOneShot(clip2);
                Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(hit, transform.position, transform.rotation);
            Destroy(gameObject, (float)0.8);
            audioPlayer.PlayOneShot(clip);
            score.addScore();
        }
        if (collision.gameObject.tag == "Shooter")
        {
            if (collision.gameObject.transform.position.x < transform.position.x)
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                this.GetComponent<SpriteRenderer>().enabled = false;
                Destroy(gameObject, (float)0.8);
            }
        }
    }
}
