using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private static float z;

    private static Color currentColor;

    private MeshRenderer meshRenderer;
    private SpriteRenderer splash;

    private float height = 0.58f, speed = 6;
    private float lerpAmount;

    private bool move, IsRising, gameOver, displayed;
    public bool perfectStar;
    public Material mt;

    private AudioSource failSound, hitSound;
    void Awake()
    {
        failSound = GameObject.Find("FailSound").GetComponent<AudioSource>();
        hitSound = GameObject.Find("HitSound").GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        splash = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        move = false;
        SetColor(GameController.instance.hitColor);
    }

    void Update()
    {
        if (Touch.IsPressing() && !gameOver)
        {
            move = true;
            GetComponent<SphereCollider>().enabled = true;
        }

        if (move)
        {
            Ball.z += speed * 0.025f;
        }

        transform.position = new Vector3(0, height, Ball.z);

        displayed = false;
        UpdateColor();
    }

    void UpdateColor()
    {
        meshRenderer.sharedMaterial.color = currentColor;

        if (IsRising)
        {
            currentColor = Color.Lerp(meshRenderer.material.color, GameObject.FindGameObjectWithTag("ColorBump").GetComponent<ColorBump>().GetColor()
                , lerpAmount);

            lerpAmount += Time.deltaTime;
        }

        if (lerpAmount >= 1)
        {
            IsRising = false;
        }
    } 

    public static float GetZ()
    {
        return Ball.z;
    }

    public static Color SetColor(Color color)
    {
        return currentColor = color;
    }

    public static Color GetColor()
    {
        return currentColor;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hit")
        {
            if (perfectStar && !displayed)
            {
                displayed = true;
                GameObject pointDisplay = Instantiate(Resources.Load("PointDisPlay"), transform.position, Quaternion.identity) as GameObject;
                pointDisplay.GetComponent<PointDisPlay>().SetText("PERFECT +" + PlayerPrefs.GetInt("Level") * 2);
            }
            else if (!perfectStar && !displayed)
            {
                displayed = true;
                GameObject pointDisplay = Instantiate(Resources.Load("PointDisPlay"), transform.position, Quaternion.identity) as GameObject;
                pointDisplay.GetComponent<PointDisPlay>().SetText("+" + PlayerPrefs.GetInt("Level"));
            }
            hitSound.Play();
            Destroy(other.transform.parent.gameObject);
            
        }

        if (other.tag == "ColorBump")
        {
            lerpAmount = 0;
            IsRising = true;
        }

        if (other.tag == "Fail")
        {
            print("GameOver");
            StartCoroutine(GameOver());
        }

        if (other.CompareTag("FinishLine"))
        {
            StartCoroutine(PlayNewLevel());
        }

        if (other.tag == "Star")
        {
            perfectStar = true;
        }
    }

    IEnumerator PlayNewLevel()
    {
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        move = false;
        Camera.main.GetComponent<CameraFollow>().Flash();
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        Camera.main.GetComponent<CameraFollow>().enabled = true;
        Ball.z = 0;
        GameController.instance.GenerateLevel();

    }

    IEnumerator GameOver()
    {
        failSound.Play();
        gameOver = true;
        splash.color = currentColor;
        splash.transform.position = new Vector3(0, 0.7f, Ball.z - 0.05f);
        splash.transform.eulerAngles = new Vector3(0, 0, Random.value * 360);
        splash.enabled = true;

        meshRenderer.enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        move = false;
        yield return new WaitForSeconds(1.5f);
        Camera.main.GetComponent<CameraFollow>().Flash();
        gameOver = false;
        z = 0;
        GameController.instance.GenerateLevel();
        splash.enabled = false;
        meshRenderer.enabled = true;
    }
}
