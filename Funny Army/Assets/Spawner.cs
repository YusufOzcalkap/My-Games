using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    public GameObject SelectCharacter;
    public GameObject myArmy;
    public float PriceCharacter;
    public GameObject[] outline;

    [Header("MyArmy")]
    public GameObject ArmyMage;
    public GameObject ArmyArcher;
    public GameObject ArmySwordsMan;
    public GameObject ArmyPikeMan;
    public GameObject ArmyFarmer;
    public GameObject ArmyCavalier;
    public float PriceMage;
    public float PriceArcher;
    public float PriceSwordsMan;
    public float PricePikeMan;
    public float PriceFarmer;
    public float PriceCavalier;

    public GameObject WarningText;
    private bool WarningOff;
    public bool Warning;
    public GameObject WarningRedText;
    void Start()
    {
        instance = this;
        SelectCharacter = null;
        Warning = false;


        for (int i = 0; i < outline.Length; i++)
            outline[i].SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse clicked");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Spawn" && SelectCharacter != null)
                {
                    //hit.transform.GetComponent<SpawnerController>().Count++;

                    if (GameManager.instance.MyCoins >= PriceCharacter)
                    {
                        if (hit.transform.GetComponent<SpawnerController>().Count <= hit.transform.GetComponent<SpawnerController>().SpawnPos.Length && SelectCharacter.GetComponent<SoldierController>().SoldierIndex == 6)
                        {// Cavalier
                            if (hit.transform.GetComponent<SpawnerController>().SpawnPos.Length >= 2)
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    GameManager.instance.MyCoins -= PriceCharacter;
                                    GameObject Army = Instantiate(SelectCharacter, hit.transform.GetComponent<SpawnerController>().SpawnPos[i].transform.position, Quaternion.identity);
                                    Army.transform.parent = myArmy.transform;
                                }

                                hit.transform.gameObject.SetActive(false);
                            }
                        }
                        else if (hit.transform.GetComponent<SpawnerController>().Count <= hit.transform.GetComponent<SpawnerController>().SpawnPos.Length && SelectCharacter.GetComponent<SoldierController>().SoldierIndex == 2)
                        {//Archer
                            if (hit.transform.GetComponent<SpawnerController>().SpawnPos.Length >= 3)
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    GameManager.instance.MyCoins -= PriceCharacter;
                                    GameObject Army = Instantiate(SelectCharacter, hit.transform.GetComponent<SpawnerController>().SpawnPos[i].transform.position, Quaternion.identity);
                                    Army.transform.parent = myArmy.transform;
                                }
                                hit.transform.gameObject.SetActive(false);
                            }
                        }
                        else if (hit.transform.GetComponent<SpawnerController>().Count <= hit.transform.GetComponent<SpawnerController>().SpawnPos.Length && SelectCharacter.GetComponent<SoldierController>().SoldierIndex == 1)
                        {// Mage
                            for (int i = 0; i < 1; i++)
                            {
                                GameManager.instance.MyCoins -= PriceCharacter;
                                GameObject Army = Instantiate(SelectCharacter, hit.transform.GetComponent<SpawnerController>().SpawnPos[i].transform.position, Quaternion.identity);
                                Army.transform.parent = myArmy.transform;
                            }
                            hit.transform.gameObject.SetActive(false);
                        }
                        else if (hit.transform.GetComponent<SpawnerController>().Count <= hit.transform.GetComponent<SpawnerController>().SpawnPos.Length && SelectCharacter.GetComponent<SoldierController>().SoldierIndex == 4)
                        {// Swordsman
                            if (hit.transform.GetComponent<SpawnerController>().SpawnPos.Length >= 4)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    GameManager.instance.MyCoins -= PriceCharacter;
                                    GameObject Army = Instantiate(SelectCharacter, hit.transform.GetComponent<SpawnerController>().SpawnPos[i].transform.position, Quaternion.identity);
                                    Army.transform.parent = myArmy.transform;
                                }
                                hit.transform.gameObject.SetActive(false);
                            }
                        }
                        else if (hit.transform.GetComponent<SpawnerController>().Count <= hit.transform.GetComponent<SpawnerController>().SpawnPos.Length && SelectCharacter.GetComponent<SoldierController>().SoldierIndex == 3)
                        {// PikeMan
                            if (hit.transform.GetComponent<SpawnerController>().SpawnPos.Length >= 4)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    GameManager.instance.MyCoins -= PriceCharacter;
                                    GameObject Army = Instantiate(SelectCharacter, hit.transform.GetComponent<SpawnerController>().SpawnPos[i].transform.position, Quaternion.identity);
                                    Army.transform.parent = myArmy.transform;
                                }
                                hit.transform.gameObject.SetActive(false);
                            }
                        }
                        else if (hit.transform.GetComponent<SpawnerController>().Count <= hit.transform.GetComponent<SpawnerController>().SpawnPos.Length && SelectCharacter.GetComponent<SoldierController>().SoldierIndex == 5)
                        {// Farmer
                            if (hit.transform.GetComponent<SpawnerController>().SpawnPos.Length >= 6)
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    GameManager.instance.MyCoins -= PriceCharacter;
                                    GameObject Army = Instantiate(SelectCharacter, hit.transform.GetComponent<SpawnerController>().SpawnPos[i].transform.position, Quaternion.identity);
                                    Army.transform.parent = myArmy.transform;
                                }
                                hit.transform.gameObject.SetActive(false);
                            }
                        }
                        else if (hit.transform.GetComponent<SpawnerController>().Count <= hit.transform.GetComponent<SpawnerController>().SpawnPos.Length)
                        {
                            GameManager.instance.MyCoins -= PriceCharacter;
                            GameObject Army = Instantiate(SelectCharacter, hit.transform.GetComponent<SpawnerController>().SpawnPos[hit.transform.GetComponent<SpawnerController>().Count].transform.position, Quaternion.identity);
                            Army.transform.parent = myArmy.transform;
                        }
                    }
                }
                Invoke("ChechkWarning", 0.1f);
            }
        }
    }

    public void SelectMage()
    {
        WarningOff = true;
        SelectCharacter = ArmyMage;
        PriceCharacter = PriceMage;

        for (int i = 0; i < outline.Length; i++)
            outline[i].SetActive(false);

        outline[0].SetActive(true);

        GameManager.instance._circleCount = 1;
    }

    public void SelectArcher()
    {
        WarningOff = true;
        SelectCharacter = ArmyArcher;
        PriceCharacter = PriceArcher;

        for (int i = 0; i < outline.Length; i++)
            outline[i].SetActive(false);

        outline[3].SetActive(true);

        GameManager.instance._circleCount = 3;
    }

    public void SelectSwordsMan()
    {
        WarningOff = true;
        SelectCharacter = ArmySwordsMan;
        PriceCharacter = PriceSwordsMan;

        for (int i = 0; i < outline.Length; i++)
            outline[i].SetActive(false);

        outline[1].SetActive(true);

        GameManager.instance._circleCount = 4;
    }

    public void SelectPikeMan()
    {
        WarningOff = true;
        SelectCharacter = ArmyPikeMan;
        PriceCharacter = PricePikeMan;

        for (int i = 0; i < outline.Length; i++)
            outline[i].SetActive(false);

        outline[4].SetActive(true);

        GameManager.instance._circleCount = 4;
    }

    public void SelectFarmer()
    {
        WarningOff = true;
        SelectCharacter = ArmyFarmer;
        PriceCharacter = PriceFarmer;

        for (int i = 0; i < outline.Length; i++)
            outline[i].SetActive(false);

        outline[2].SetActive(true);

        GameManager.instance._circleCount = 6;
    }

    public void SelectCavalier()
    {
        WarningOff = true;
        SelectCharacter = ArmyCavalier;
        PriceCharacter = PriceCavalier;

        for (int i = 0; i < outline.Length; i++)
            outline[i].SetActive(false);

        outline[5].SetActive(true);

        GameManager.instance._circleCount = 2;

    }

    IEnumerator SetWarning()
    {
        WarningText.SetActive(true);
        yield return new WaitForSeconds(1f);
        WarningText.SetActive(false);
    }

    IEnumerator SetRedWarning()
    {
        WarningRedText.SetActive(true);
        yield return new WaitForSeconds(1f);
        WarningRedText.SetActive(false);
    }

    public void ChechkWarning()
    {
        if (SelectCharacter == null && !WarningOff && Warning)
        {
            StartCoroutine(SetWarning());
        }
    }
}
