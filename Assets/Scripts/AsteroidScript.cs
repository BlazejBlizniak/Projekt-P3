using UnityEngine;

public class AsteroidScript : Spawnables
{
    public HitScript hit;
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
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            Instantiate(hit, transform.position, transform.rotation);
            Destroy(gameObject, (float)0.8);
            movementSpeed = 0;
            audioPlayer.PlayOneShot(clip);
        }

        if (collision.gameObject.tag == "Projectile")
        {
            audioPlayer.PlayOneShot(clip);
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
