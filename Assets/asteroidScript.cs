using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidScript : MonoBehaviour
{
    public float rotation;
    public float minSpeed, maxSpeed;
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;


    Rigidbody asteroid;
    // Start is called before the first frame update
    void Start()
    {
        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotation;
        asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
    
        
    }
    // Будет вызван при столкновении с другим объектом (other)
    private void OnTriggerEnter(Collider other)
    {   
        if(other.tag == "GameBoundary" || other.tag == "Asteroid")
        {
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        if(other.tag == "Player")
        {
            //Взорвать игрока
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        } else 
        {
            GameControllerScript.getInstance().increaseScore(5);
        }
        
    }
}