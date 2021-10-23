using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("           Arrow")]
    public GameObject Arrow;
    public bool ArrowOn;

    [Header("           Coin")]
    public Image CoinImage;
    public Image KeyImage;
    public GameObject Canvas;
    public GameObject Tick;
    public TextMeshProUGUI CoinText;
    public Animator CoinAnim;

    private Animator anim;
    public GameObject Barrels;
    public GameObject BarrelsEnd;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
           GameObject arrow = Instantiate(Arrow);
           arrow.transform.position = new Vector3(other.transform.position.x + 4, other.transform.position.y + 1, other.transform.position.z);
            Destroy(arrow.gameObject, 1f);
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            Trap.instance.Active = true;
        }

        if (other.gameObject.CompareTag("Thorn"))
        {
            // dikenlerden caný iniyor
            HealthBar.instance.Health -= GameManager.instance.thorn;
            HealthBar.instance.DamageOn = true;

        }

        if (other.gameObject.CompareTag("Thrower"))
        {
            // dikenlerden caný iniyor
            HealthBar.instance.Health -= GameManager.instance.thrower;
            HealthBar.instance.DamageOn = true;

            other.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            Image Coin = Instantiate(CoinImage);
            Coin.transform.parent = Canvas.transform;
            Destroy(Coin.gameObject, 1f);
            Destroy(other.gameObject);

            GameManager.instance.CoinCount++;
            CoinText.text = GameManager.instance.CoinCount.ToString();

            CoinAnim.SetTrigger("Scale");
        }

        if (other.gameObject.CompareTag("Key"))
        {
            Image key = Instantiate(KeyImage);
            key.transform.parent = Canvas.transform;
            key.transform.GetComponent<RectTransform>().localPosition = new Vector3(0, key.transform.GetComponent<RectTransform>().localPosition.y, 0);

            Destroy(key.gameObject, 1f);
            Destroy(other.gameObject);

            Tick.gameObject.SetActive(true);

            GameManager.instance.GoGate = true;
        }

        if (other.gameObject.CompareTag("NewLevel"))
        {
            GameManager.instance.Level++;

            other.gameObject.SetActive(false);

            GameManager.instance.GoGate = false;
            Tick.gameObject.SetActive(false);

            //oyun barý 


            //CameraController.instance.anim.SetBool("FlipOn", false);
            //CameraController.instance.anim.SetBool("Don", true);

            //JoystickController.instance.MoveOff = true;

            //GameManager.instance.NextUI.SetActive(true);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            CameraController.instance.anim.SetTrigger("Win");
            GateController.instance.LevelStartPos5.gameObject.GetComponent<Animator>().SetTrigger("ExitFinish");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
         //   other.GetComponent<MeshRenderer>().materials[0].color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            for (int i = 0; i < other.GetComponent<MeshRenderer>().materials.Length; i++)
            {
                other.GetComponent<MeshRenderer>().materials[i].color = new Color(other.GetComponent<MeshRenderer>().materials[i].color.r,
                other.GetComponent<MeshRenderer>().materials[i].color.g,
                other.GetComponent<MeshRenderer>().materials[i].color.b,
                0.15f);
            }
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            Trap.instance.Active = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            for (int i = 0; i < other.GetComponent<MeshRenderer>().materials.Length; i++)
            {
                other.GetComponent<MeshRenderer>().materials[i].color = new Color(other.GetComponent<MeshRenderer>().materials[i].color.r,
                other.GetComponent<MeshRenderer>().materials[i].color.g,
                other.GetComponent<MeshRenderer>().materials[i].color.b,
                1f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gate"))
        {
            print("Kapý");
            if (GameManager.instance.GoGate == true )
            {
                collision.gameObject.GetComponent<Animator>().SetTrigger("Enter");
                if (GameManager.instance.Level == 1)                
                    GateController.instance.Level1.transform.GetComponent<Animator>().SetTrigger("Enter");

                if (GameManager.instance.Level == 2)
                    GateController.instance.Level2.transform.GetComponent<Animator>().SetTrigger("Enter");

                if (GameManager.instance.Level == 3)
                    GateController.instance.Level3.transform.GetComponent<Animator>().SetTrigger("Enter");

                if (GameManager.instance.Level == 4)
                    GateController.instance.Level4.transform.GetComponent<Animator>().SetTrigger("Enter");



                // transform.position = Vector3.Lerp(transform.position, GateController.instance.LevelStartPos2.transform.position, 0.2f);

                // JoystickController.instance.MoveOff = true;
            }
        }

        if (collision.gameObject.CompareTag("ArrowDamage"))
        {
            HealthBar.instance.Health -= GameManager.instance.thrower;
            HealthBar.instance.DamageOn = true;
        }

        if (collision.gameObject.CompareTag("Barrel"))
        {
            collision.transform.GetComponent<BoxCollider>().enabled = false;
            //collision.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(SetBarrel());
        }

        if (collision.gameObject.CompareTag("BarrelEnd"))
        {
            collision.transform.GetComponent<BoxCollider>().enabled = false;
            //collision.transform.GetChild(0).transform.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(SetBarrelEnd());
        }
    }

    public void StopPlayer()
    {
        JoystickController.instance.MoveOff = true;
    }

    public void WalkPlayer()
    {
        JoystickController.instance.MoveOff = false;
    }

    IEnumerator SetBarrel()
    {
        anim.SetTrigger("Torch");

        Barrels.transform.GetChild(0).transform.GetComponent<ParticleSystem>().Play();
        Barrels.transform.GetChild(1).transform.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(6.5f);

        Barrels.transform.GetChild(2).transform.GetComponent<ParticleSystem>().Play();
        Barrels.transform.GetChild(3).transform.GetComponent<ParticleSystem>().Play();
        Barrels.transform.GetChild(4).transform.GetComponent<ParticleSystem>().Play();
        Barrels.transform.GetChild(5).transform.GetComponent<ParticleSystem>().Play();
        Barrels.transform.GetChild(6).transform.GetComponent<ParticleSystem>().Play();
        Barrels.transform.GetChild(7).transform.GetComponent<ParticleSystem>().Play();
        Barrels.transform.GetChild(8).transform.GetComponent<ParticleSystem>().Play();
        Destroy(Barrels.transform.GetChild(9).gameObject);
        Destroy(Barrels.transform.GetChild(10).gameObject);
        Destroy(Barrels.transform.GetChild(0).gameObject);
        Destroy(Barrels.transform.GetChild(1).gameObject);
    }

    IEnumerator SetBarrelEnd()
    {
        anim.SetTrigger("Torch");

        BarrelsEnd.transform.GetChild(0).transform.GetComponent<ParticleSystem>().Play();
        BarrelsEnd.transform.GetChild(1).transform.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(6.5f);

        BarrelsEnd.transform.GetChild(2).transform.GetComponent<ParticleSystem>().Play();
        BarrelsEnd.transform.GetChild(3).transform.GetComponent<ParticleSystem>().Play();
        BarrelsEnd.transform.GetChild(4).transform.GetComponent<ParticleSystem>().Play();
        BarrelsEnd.transform.GetChild(5).transform.GetComponent<ParticleSystem>().Play();
        BarrelsEnd.transform.GetChild(6).transform.GetComponent<ParticleSystem>().Play();
        BarrelsEnd.transform.GetChild(7).transform.GetComponent<ParticleSystem>().Play();
        BarrelsEnd.transform.GetChild(8).transform.GetComponent<ParticleSystem>().Play();
        Destroy(BarrelsEnd.transform.GetChild(9).gameObject);
        Destroy(BarrelsEnd.transform.GetChild(10).gameObject);
        Destroy(BarrelsEnd.transform.GetChild(0).gameObject);
        Destroy(BarrelsEnd.transform.GetChild(1).gameObject);
    }
}
