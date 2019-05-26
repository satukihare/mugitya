using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePad : MonoBehaviour
{
    public float LeftStickX;                                    // 左スティックX値
    public float LeftStickY;                                    // 左スティックY値
    public float RightStickX;                                    // 左スティックX値
    public float RightStickY;                                    // 左スティックY値
    public float DirectionKeyX;
    public float DirectionKeyY;
    public bool Is_OnL1;                                        // ON/OFF判定
    public bool Is_OnL2;                                        // ON/OFF判定
    public bool Is_OnR1;                                        // ON/OFF判定
    public bool Is_OnR2;                                        // ON/OFF判定
    public bool Is_OnCross;
    public bool Is_OnCircle;
    public bool Is_OnSquare;
    public bool Is_OnTriangle;
    public bool Is_OnMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftStickX = Input.GetAxisRaw("Horizontal");
        LeftStickY = Input.GetAxisRaw("Vertical") * -1.0f;
        RightStickX= Input.GetAxisRaw ("BoxRightHorizontal");
        RightStickY = Input.GetAxisRaw("BoxRightVertical") * -1.0f;
        DirectionKeyX = Input.GetAxis("BoxDirectionKeyX");
        DirectionKeyY = Input.GetAxis("BoxDirectionKeyY");
        if (Input.GetAxis("Box_Trigger") == -1.0f) { Is_OnL2 = true; }
        if (Input.GetAxis("Box_Trigger") > -1.0f) { Is_OnL2 = false; }
        if (Input.GetAxis("Box_Trigger") == 1.0f) { Is_OnR2 = true; }
        if (Input.GetAxis("Box_Trigger") < 1.0f) { Is_OnR2 = false; }
        if (Input.GetButtonDown("A")) { Is_OnCross = true; }
        if (Input.GetButtonDown("X")) { Is_OnSquare = true; }
        if (Input.GetButtonDown("Y")) { Is_OnTriangle = true; }
        if (Input.GetButtonDown("B")) { Is_OnCircle = true; }
        if (Input.GetButtonUp("A")) { Is_OnCross = false; }
        if (Input.GetButtonUp("X")) { Is_OnSquare = false; }
        if (Input.GetButtonUp("Y")) { Is_OnTriangle = false; }
        if (Input.GetButtonUp("B")) { Is_OnCircle = false; }
        if (Input.GetButtonDown("L1")) { Is_OnL1 = true; }
        if (Input.GetButtonDown("R1")) { Is_OnR1 = true; }
        if (Input.GetButtonUp("L1")) { Is_OnL1 = false; }
        if (Input.GetButtonUp("R1")) { Is_OnR1 = false; }
        if (Input.GetButtonDown("Menu")) { Is_OnMenu = true; }
        if (Input.GetButtonUp("Menu")) { Is_OnMenu = false; }

    }

    public bool GetCross()    { return Is_OnCross; }
    public bool GetCircle()   { return Is_OnCircle; }
    public bool GetSquare()   { return Is_OnSquare; }
    public bool GetTriangle() { return Is_OnTriangle; }
    public bool GetL1() { return Is_OnL1; }
    public bool GetL2() { return Is_OnL2; }
    public bool GetR1() { return Is_OnR1; }
    public bool GetR2() { return Is_OnR2; }
    public float GetLeftStickX() { return LeftStickX; }
    public float GetLeftStickY() { return LeftStickY; }
    public float GetRightStickX() { return RightStickX; }
    public float GetRightStickY() { return RightStickY; }
    public float GetDirectionKeyX() { return DirectionKeyX; }
    public float GetDirectionKeyY() { return DirectionKeyY; }
    public bool GetMenuButton() { return Is_OnMenu; }
}
