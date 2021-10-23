using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    float Count;
    float Count1;
    float Count2;

    [Header("           Game")]
    public int Level;
    public TextMeshProUGUI LevelText;
    public bool MainEnemyGo;

    [Header("           Damage Amount")]
    public float thorn;
    public float thrower;
    public float ArrowDamage;
    public float EnemyAttack;


    [Header("           GameReStart")]
    public bool GoGate;

    public float CoinCount;

    [Header("           Start")]
    public bool StartGame;
    public ParticleSystem Boom;
    public GameObject GameStartUI;
    public GameObject NextUI;
    public GameObject CamWall;
    public Animator GateAnim;

    public GameObject MainEnemy;
    public Animator PlayerAnim;

    int countStart;
    void Start()
    {
        instance = this;
        Level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartGame)
        {
            countStart++;
            if (countStart == 1)
            {
                StartCoroutine(StartGameAnim());
            }
        }

        LevelText.text = "LEVEL " + Level.ToString();

        if (Timer.instance.countdownTo <= 0)
        {
            // Oyun finih ekraný
            CameraController.instance.anim.SetBool("Lose", true);
        }

        if (HealthBar.instance.Health <= 0)
        {
            CameraController.instance.anim.SetBool("Lose", true);
        }
    }


    IEnumerator StartGameAnim()
    {
        CameraController.instance.anim.enabled = false;
        Count++;
        if (Count == 1)
        {
            Boom.Play();
            CameraController.instance.SetCamera();
            GateController.instance.SetGateShake();
        }
        yield return new WaitForSeconds(2f);

        Count1++;
        if (Count1 == 1)
        {
            Boom.Play();
            CameraController.instance.SetCamera();
            GateController.instance.SetGateShake();
        }

        yield return new WaitForSeconds(2f);

        Count2++;
        if (Count2 == 1)
        {
            Boom.Play();
            CameraController.instance.SetCamera();
            GateController.instance.SetGateShake();
            GateAnim.SetTrigger("Enter");
        }

        yield return new WaitForSeconds(0.4f);

        CameraController.instance.anim.enabled = true;
        CameraController.instance.anim.SetBool("FlipOn", true);
        CamWall.transform.GetComponent<MeshRenderer>().enabled = true;
        PlayerAnim.SetBool("Fear", true);

        yield return new WaitForSeconds(1f);
        MainEnemy.GetComponent<Waypoint_Indicator>().enabled = true;
        MainEnemy.GetComponent<NavMeshAgent>().speed = 1.5f;
        MainEnemyGo = true;

    }

    public void GameUI()
    {
        PlayerAnim.SetBool("Fear", false);
        GameStartUI.SetActive(false);
        StartGame = true;

    }

    public void NextSetUI()
    {
       // PlayerAnim.SetBool("Fear", false);
       NextUI.SetActive(false);
       StartGame = true;

        CameraController.instance.anim.SetBool("FlipOn", true);
        CameraController.instance.anim.SetBool("Don", false);

        JoystickController.instance.MoveOff = false;
    }

}
