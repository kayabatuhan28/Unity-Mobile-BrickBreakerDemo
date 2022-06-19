using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PaddleController : MonoBehaviour
{
    [SerializeField]
    float speed;

    //Sað ve sol alana limit koyduk dýþýna çýkmamasý için
    [SerializeField]
    float leftTarget,rightTarget;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {

        if (gameManager.gameOver)
        {
            return;
        }

       
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        transform.Translate(Vector2.right * h * Time.deltaTime * speed);

        
        Vector2 temp = transform.position;
        temp.x = Mathf.Clamp(temp.x, leftTarget, rightTarget);
        transform.position = temp;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "LivesUp")
        {
            gameManager.UpdateLives(1);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "SkorUp")
        {
            gameManager.UpdateScore(10);
            Destroy(other.gameObject);
        }
    }
}
