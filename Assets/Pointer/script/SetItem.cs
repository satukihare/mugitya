using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetItem : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private GamePad gamepad;
    public GameObject FireObj;
    public GameObject WindObj;
    bool IsSet;
    int ItemNum;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Pointer");
        gamepad = Player.GetComponent<GamePad>();
        FireObj= (GameObject)Resources.Load("Prefabs/bonfire");
        WindObj = (GameObject)Resources.Load("Prefabs/Wind");
        IsSet = false;
        ItemNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("L1") || Input.GetKeyDown(KeyCode.O))
        {
            ItemNum -= 1;
            if(ItemNum<0)
            {
                ItemNum = 1;
            }
        }
        if (Input.GetButtonDown("R1") || Input.GetKeyDown(KeyCode.P))
        {
            ItemNum += 1;
            if (ItemNum > 1)
            {
                ItemNum = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("B"))
        {
            if (ItemNum == 0)
            {
                Instantiate(FireObj, this.transform.position, Quaternion.identity);
            }
            if (ItemNum == 1)
            {
                Instantiate(WindObj, this.transform.position, transform.rotation = Quaternion.Euler(0, 90, 0));
            }
        }
        Debug.Log(this.transform.forward);
    }
}
