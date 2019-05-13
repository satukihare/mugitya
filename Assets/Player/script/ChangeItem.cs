using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeItem : MonoBehaviour
{
    private int equipment;
    private Transform FireObj;
    private Transform WindObj;

    // Start is called before the first frame update
    void Start()
    {
        //　初期装備設定
        equipment = 0;
        FireObj = this.transform.Find("bonfireItem");
        WindObj = this.transform.Find("WindItem");
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
            if (equipment == 1)
            {
                Instantiate((GameObject)Resources.Load("Prefabs/bonfire"), this.transform.position, Quaternion.identity);
            }
            if (equipment == 2)
            {
                Instantiate((GameObject)Resources.Load("Prefabs/Wind"), WindObj.transform.position, this.transform.rotation);
            }
            equipment = 0;
        }
    }
}
