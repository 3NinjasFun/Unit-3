using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    float speed = 30;
    private PlayerControl playerControllerScript;
    private float leftBound = -15;
    private float scoreBound = 4;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            speed = 60;
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            speed = 30;
        }
        
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle") && playerControllerScript.dash)
        {
            playerControllerScript.score += 2;
            Debug.Log("Score: " + playerControllerScript.score);
        }
        else if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            playerControllerScript.score += 1;
            Debug.Log("Score: " + playerControllerScript.score);
        }

        
    }
}
