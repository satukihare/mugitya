using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeGUIControl : MonoBehaviour {

    //プレイヤー
    public PlayerScript player;

    //葉っぱ
    public lifeLeaf leaf_1;
    public lifeLeaf leaf_2;
    public lifeLeaf leaf_3;
    public lifeLeaf leaf_4;
    public lifeLeaf leaf_5;

    // Start is called before the first frame update
    void Start() {

        leaf_1.enabled = true;
        leaf_2.enabled = true;
        leaf_3.enabled = true;
        leaf_4.enabled = true;
        leaf_5.enabled = true;
    }

    // Update is called once per frame
    void Update() {


        if (Input.GetKey(KeyCode.C))
            player.Life--;


        switch ((int)player.Life) {

            case 0:
                leaf_1.NoImage();
                break;
            case 1:
                leaf_2.NoImage();
                break;
            case 2:
                leaf_3.NoImage();
                break;
            case 3:
                leaf_4.NoImage();
                break;
            case 4:
                leaf_5.NoImage();
                this.gameObject.SetActive(false);
                break;
            case 5:
                break;
        }


    }
}
