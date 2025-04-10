using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [Header("Game Controller Object for controlling the game")]
    public GameController gameController;
    [Header("Default Score")]
    public float velocity = 5;
    private Rigidbody2D rb;
    private float objectHeight;

    public GameController GameController { get => gameController; set => gameController = value; }

    // Start is called before the first frame update
    void Start()
    {
        GameController = GetComponent<GameController>();
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
        }
    }
    private void OnCollisionEnter2D(Collision2D Collision)
    {
        GameObject.Find("GameController").GetComponent<GameController>().GameOver();
        if(Collision.gameObject.tag == "HighSpike" || Collision.gameObject.tag == "lowSpike" || Collision.gameObject.tag == "Ground")
        {
            Time.timeScale = 0;
        }
    }
}
