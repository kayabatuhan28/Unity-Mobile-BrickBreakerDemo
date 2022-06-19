using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBrokenController : MonoBehaviour
{
    [SerializeField] 
    private Sprite brokenImage;

    int count;

    [SerializeField]
    GameObject brickBrokenEffect;
    GameManager gameManager;

    [SerializeField]
    GameObject skorUpPrefab;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        count = 0;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Ball")
        {
            count++;

            if(count == 1) 
            {
                GetComponent<SpriteRenderer>().sprite = brokenImage;
                gameManager.UpdateScore(5);
            }
            else if(count == 2) 
            {
                Instantiate(brickBrokenEffect, transform.position, transform.rotation);
                gameManager.UpdateScore(10);

                int randomChaince = Random.Range(1, 101); 
                if (randomChaince > 80)
                {
                    Instantiate(skorUpPrefab, transform.position, transform.rotation);
                }

                Destroy(gameObject);
            }
        }
    }
}
