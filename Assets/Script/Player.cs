using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for death control
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{  
    //}
    private Vector2 targetPos;
    public float yIncrement;

    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health = 3;
    public GameObject effect;

    //public Animator camAnim;

    private CamShake shake;

    private void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CamShake>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (health <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            //camAnim.SetTrigger("shake");
            shake.camShake();

            targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
            Instantiate(effect, transform.position, Quaternion.identity);

            //Below we set the position of target to be targetPos which we do above
            //transform.position = targetPos;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            //camAnim.SetTrigger("shake");
            shake.camShake();

            targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
            Instantiate(effect, transform.position, Quaternion.identity);

            //Below we set the position of target to be targetPos which we do above
            //transform.position = targetPos;

        }
    }
}
