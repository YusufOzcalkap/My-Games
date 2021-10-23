using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public static JoystickController instance;

    public Transform player;
    [HideInInspector]
    public Vector3 move;

    Vector2 move1;
    public float moveSpeed;
    public bool moving;
    public GameObject joys;

    public RectTransform pad;
    public Joystick joy;

    public Animator anim;

    public bool MoveOff;
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

       
        move = new Vector3(joys.transform.localPosition.x, 0, joys.transform.localPosition.y).normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pad.gameObject.SetActive(false);
        joys.transform.localPosition = Vector3.zero;
        move = Vector3.zero;
        moving = false;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
      
        moving = true;
        pad.transform.position = eventData.position;
        //move1 = eventData.position;

        //Vector2 diff = eventData.position - (Vector2)GetComponent<RectTransform>().position;
        //Vector2 modifieddiff = diff * (1f / GetComponentInParent<Canvas>().scaleFactor);
        //pad.localPosition = modifieddiff;


    }


    private void Update()
    {
        if (GameManager.instance.StartGame == false)
        {
            MoveOff = true;
        }
        else
        {
            MoveOff = false;
        }

        if (moving)
        {
            //pad.transform.position = move1;
            pad.gameObject.SetActive(true);

            if (MoveOff == false)
            {
                player.Translate(move * moveSpeed * Time.deltaTime, Space.World);
            }

            anim.SetBool("Walk", true);

            if (move != Vector3.zero)
            {
                player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(move), 5 * Time.deltaTime);


            }
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }

    
}
