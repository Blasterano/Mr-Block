using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool won = false;
    bool paused = false;

    public float speed;
    public Rigidbody2D rb;
    public GameObject gameWon, pause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (won)
            return;

        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            pause.SetActive(true);
            paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            pause.SetActive(false);
            paused = false;
        }
        else if(paused)
            return;

        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        if(!Input.GetKey(KeyCode.Space))
            rb.velocity = new Vector2(speed * hInput, speed * vInput);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            gameWon.SetActive(true);
            won = true;
        }
    }
}
