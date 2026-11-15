using UnityEngine;

public class EnemyScript : Spawnables
{
    public ScoreScript score;
    public HitScript hit;

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
    }

    void Update()
    {
        transform.position = transform.position + (Vector3.left * movementSpeed) * Time.deltaTime;
        if (transform.position.x < dZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Projectile")
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(hit, transform.position, transform.rotation);
            Destroy(gameObject, (float)0.8);
            movementSpeed = 0;
            audioPlayer.PlayOneShot(clip);
            score.addScore();
        }
        
        if (collision.gameObject.tag == "Shooter")
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, (float)0.8);
            movementSpeed = 0;
        }
    }

}
