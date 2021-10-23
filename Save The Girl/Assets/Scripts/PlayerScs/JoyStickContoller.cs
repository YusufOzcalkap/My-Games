using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickContoller : MonoBehaviour, IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    public static JoyStickContoller instance;

    public Transform player;
    [HideInInspector]
    public Vector3 move;

    Vector2 move1;
    public float moveSpeed;
    public bool moving;
    public Animator anim;
    public GameObject joys;
    public PlayerScript ps;

    public RectTransform pad;
    public Joystick joy;

    void Start()
    {
        instance = this;   
    }

    public void OnDrag(PointerEventData eventData)
    {
        //ChangeJoy(eventData.position);

        joys.transform.position = eventData.position;
        joys.transform.localPosition =
            Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.4f);

        if (PlayerScript.instance.jumpAt == false)
        {
            move = new Vector3(joys.transform.localPosition.x, 0, joys.transform.localPosition.y).normalized;
        }
        else
        {
          //  move = Vector3.zero;
        }
           
        
       

        if (ps.SuperSonicCount <= 100)
        {
            ps.SuperSonicCount += 20 * Time.deltaTime;

        }
        //if(ps.SuperSonicCount >= 100)
        //{
        //    ps.lightning.Play();
        //}
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        pad.gameObject.SetActive(false);
        joys.transform.localPosition = Vector3.zero;
        move = Vector3.zero;
        moving = false;

        //int atc = Random.Range(1, 5);

        //if (atc == 1)
        //    anim.SetTrigger("Attack");
        //if (atc == 2)
        //    anim.SetTrigger("UpperAttack");
        //if (atc == 3)
        //    anim.SetTrigger("LeftKick");
        //if (atc == 4)
        //    anim.SetTrigger("RightKick");



    }
    public void OnPointerDown(PointerEventData eventData)
    {
        print("harekert");

        moving = true;
        pad.transform.position = eventData.position;
        //move1 = eventData.position;

        //Vector2 diff = eventData.position - (Vector2)GetComponent<RectTransform>().position;
        //Vector2 modifieddiff = diff * (1f / GetComponentInParent<Canvas>().scaleFactor);
        //pad.localPosition = modifieddiff;


    }


    private void Update()
    {
        if(moving)
        {
            //pad.transform.position = move1;
            pad.gameObject.SetActive(true);
           
            player.Translate(move * moveSpeed * Time.deltaTime, Space.World);
            anim.SetBool("Run", true);

            if (move != Vector3.zero)
            {
                player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(move), 5 * Time.deltaTime);

                
            }
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    public void ChangeJoy(Vector2 pedPos)
    {
        Vector2 diff = pedPos - (Vector2)GetComponent<RectTransform>().position;
        pad.localPosition = diff;
    }

   
}
