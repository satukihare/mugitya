﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFireWall : MonoBehaviour {
    public Camera camera = null;
    public GameObject fire_obj = null;

    //壁の個数
    public float wall_nums = 300;
    //壁が出現する高さ
    public float wall_height = 3.0f;

    private List<GameObject> fire_obj_list = new List<GameObject>();

    // Start is called before the first frame update
    void Start() {
        for (int count = 0; count < wall_nums; count++) {

            //Instantiate( 生成するオブジェクト,  場所, 回転 );  回転はそのままなら↓
            //Instantiate((GameObject)Resources.Load("fireWallObj"), new Vector3(0 + count / 10, 0, 0), Quaternion.identity);
            GameObject temp = Instantiate((GameObject)Resources.Load("fireWallObj"), new Vector3(count + camera.transform.position.x - (wall_nums / 2), wall_height, camera.transform.position.z + 8.0f), Quaternion.identity);
            fire_obj_list.Add(temp);
        }
    }

    // Update is called once per frame
    void Update() {
        //fire_obj.transform.position = new Vector3(camera.transform.position.x, 0.1f, camera.transform.position.z);

        //Vector3 temp = fire_obj.transform.position;
        //fire_obj.transform.position = new Vector3(temp.x, temp.y, temp.z+0.02f);

        //スペースを押したら
        if (Input.GetKeyDown(KeyCode.Space)) {
            //Instantiate( 生成するオブジェクト,  場所, 回転 );  回転はそのままなら↓
            Instantiate((GameObject)Resources.Load("fireWallObj"), new Vector3(1.0f, 2.0f, 0.0f), Quaternion.identity);
        }
    }
}