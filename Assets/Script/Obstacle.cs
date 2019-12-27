using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour{

    public int damage;
    public float speed;
    public GameObject effect;

    private CamShake shake;

    public GameObject popSound;

    private void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CamShake>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    //If istrigger check = run this function at collide. Use paramter type Collider2D called other.
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            //shake.camShake();
            //Debug.Log(shake);
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(popSound, transform.position, Quaternion.identity);

            // Player takes damage ! 
            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);
            Destroy(gameObject);
        }
    }
}
