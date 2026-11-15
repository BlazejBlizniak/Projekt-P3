using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Asteroid;
    public GameObject Shooter;
    public float spawnRate;
    private float timer = 0;
    public float offset;

    void Update()
    {

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            int random = Random.Range(1, 16);
            float lowestPoint = transform.position.y - offset;
            float highestPoint = transform.position.y + offset;
            if (random < 8)
            {
                Instantiate(Enemy, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
            }
            else if(random == 15){
                Instantiate(Shooter, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
            }
            else
            {
                Instantiate(Asteroid, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
            }
            timer = 0;
        }
    }
}
