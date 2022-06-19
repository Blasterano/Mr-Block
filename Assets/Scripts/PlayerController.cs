using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool gameOver = false;
    bool paused = false;

    public float speed;
    public Rigidbody2D rb;
    public GameObject gameWon, gameLost, pause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            return;

        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            pause.SetActive(true);
            paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            Resume();
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
            gameOver = true;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            gameLost.SetActive(true);
            gameOver = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Resume()
    {
        pause.SetActive(false);
        paused = false;
    }
}
