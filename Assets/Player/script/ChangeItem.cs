using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeItem : MonoBehaviour
{
    private int equipment;
    private Transform FireObj;
    private Transform WindObj;
    private gameMnger gameManager;
    int Max_Wind;
    int Max_Fire;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("gameMnger").GetComponent<gameMnger>();
        //　初期装備設定
        equipment = 0;
        FireObj = this.transform.Find("bonfireItem");
        WindObj = this.transform.Find("WindItem");
        int currentSceneindex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneindex == 1)//ステージ①のアイテム数設定
        {
            Max_Fire = 8;
            Max_Wind = 5;
        }
        if (currentSceneindex == 2)//ステージ2のアイテム数設定
        {
            Max_Fire = 2;
            Max_Wind = 5;
        }

        gameManager.addInstallationTag("fire", Max_Fire);
        gameManager.addInstallationTag("wind", Max_Wind);
    }

    // Update is called once per frame
    void Update()
    {
        Change();

        Setting();
       
    }

    private void Change()
    {
        if (Input.GetButtonDown("L1") || Input.GetKeyDown(KeyCode.O))
        {
            equipment -= 1;
            if (equipment < 0)
            {
                equipment = 2;
            }
        }
        if (Input.GetButtonDown("R1") || Input.GetKeyDown(KeyCode.P))
        {
            equipment += 1;
            if (equipment > 2)
            {
                equipment = 0;
            }
        }

        if (equipment == 0)
        {
            FireObj.gameObject.SetActive(false);
            WindObj.gameObject.SetActive(false);
        }
        if (equipment == 1)
        {
            FireObj.gameObject.SetActive(true);
            WindObj.gameObject.SetActive(false);
        }
        if (equipment == 2)
        {
            FireObj.gameObject.SetActive(false);
            WindObj.gameObject.SetActive(true);
            WindObj.GetComponentInChildren<Wind>().enabled = false;
        }
    }
    void Setting()
    {
        if (Input.GetButtonDown("B") || Input.GetKeyDown(KeyCode.Space))
        {
            if (equipment == 1 && Max_Fire!=0)
            {
                Instantiate((GameObject)Resources.Load("Prefabs/bonfire"), this.transform.position, Quaternion.identity);
                Max_Fire--;
                gameManager.setInstallationNums("fire", Max_Fire);
            }
            if (equipment == 2 && Max_Wind != 0)
            {
                Instantiate((GameObject)Resources.Load("Prefabs/Wind"), WindObj.transform.position, this.transform.rotation);
                Max_Wind--;
                gameManager.setInstallationNums("wind", Max_Wind);
            }
            equipment = 0;
        }
    }
}
