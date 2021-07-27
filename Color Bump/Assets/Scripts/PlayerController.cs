using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lastMousePos;
    public float sensitivity = 0.16f, clampDelta = 42f;

    public float bounds = 5;

    [HideInInspector]
    public bool canMove, gameOver, finish;

    public GameObject breakablaPlayer;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bounds, bounds), transform.position.y , transform.position.z);
        if (canMove)
        {
            transform.position += FindObjectOfType<CameraFollow>().camVel;
        }

        if (!canMove && gameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }
        else if (!canMove && !finish)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FindObjectOfType<GameManager>().RemoveUI();
                canMove = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;

        }

        if (canMove && !finish)
        {
            Vector3 vector = lastMousePos - Input.mousePosition;
            lastMousePos = Input.mousePosition;
            vector = new Vector3(vector.x, 0, vector.y);

            Vector3 moveForce = Vector3.ClampMagnitude(vector, clampDelta);
            rb.AddForce((-moveForce * sensitivity -rb.velocity / 5),ForceMode.VelocityChange);
           // rb.AddForce(Vector3.forward * 2, ForceMode.VelocityChange);
        }

        rb.velocity.Normalize();
    }

    private void GameOver()
    {
        GameObject shatterShphere = Instantiate(breakablaPlayer, transform.position, Quaternion.identity);
        foreach (Transform o in shatterShphere.transform)
        {
            o.GetComponent<Rigidbody>().AddForce(Vector3.forward * rb.velocity.magnitude, ForceMode.Impulse);
        }

        canMove = false;
        gameOver = true;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        Time.timeScale = .5f;
    }

    IEnumerator NextLevel()
    {
        finish = true;
        canMove = false;
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 1) + 1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("Level"));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!gameOver)
            {
                GameOver();
            }
        }  
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Finish")
        {
            StartCoroutine(NextLevel());
        }  
    }
}
