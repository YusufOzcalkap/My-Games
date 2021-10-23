using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;

    public bool DamageOn;

    public float Health;
    public float Count;

    public Image FillHealth;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Health = 1;
        transform.GetComponent<Image>().enabled = false;
        transform.GetChild(0).GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
        transform.rotation = Quaternion.Euler(0, 0, 90);

        transform.GetChild(0).LookAt(Camera.main.transform.position);
        transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 90);

        if (DamageOn)
        {
            transform.GetComponent<Image>().enabled = true;
            transform.GetChild(0).GetComponent<Image>().enabled = true;
           // FillHealth.fillAmount -= FillHealth.fillAmount - Can;
            FillHealth.fillAmount = Mathf.Lerp(FillHealth.fillAmount, Health, 0.001f - Count);
            Count -= 0.001f;
            StartCoroutine(SetDamage());
        }
    }

    IEnumerator SetDamage()
    {
        yield return new WaitForSeconds(1f);
        transform.GetComponent<Image>().enabled = false;
        transform.GetChild(0).GetComponent<Image>().enabled = false;
        Count -= 0f;
        DamageOn = false;
    }
}
