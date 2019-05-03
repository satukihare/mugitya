using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectBug : MonoBehaviour
{
    private GamePad gamepad;
    public bool IsTrun;
    public int BugNum;
    public int Rotspeed;
    public int totalRot;
    // Start is called before the first frame update
    void Start()
    {
        gamepad = GameObject.Find("Player").GetComponent<GamePad>();
        BugNum = 0;
        IsTrun = false;
        Rotspeed = 0;
        totalRot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsTrun==false)
        {
            if (gamepad.GetDirectionKeyX() == 1)
            {
                IsTrun = true;
                Rotspeed = 4;
                Debug.Log("右");
            }
            if (gamepad.GetDirectionKeyX() ==-1)
            {
                IsTrun = true;
                Rotspeed = -4;
                Debug.Log("左");
            }
        }
        if(IsTrun==true)
        {
            Rotation();
        }
        
    }

    void Rotation()
    {
        transform.Rotate(new Vector3(0, 0, Rotspeed));
        totalRot += Rotspeed;
        if(totalRot==72 || totalRot == -72)
        {
            totalRot = 0;
            IsTrun = false;
            Rotspeed = 0;
        }
    }
}
