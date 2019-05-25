using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorMove : MonoBehaviour {
    public GamePad game_pad = null;

    public List<GameObject> img_obj = new List<GameObject>(2);

    //cursorの位置
    private int cursor_position_num = 0;

    //メニュー最大数
    private const int min_menu_num = 0;
    //メニュー最小数
    private const int max_menu_num = 1;

    //ゲームパッド移動フラグ
    private bool pad_move_flg = false;

    //cursor移動量
    public float cursor_move_num = 0.2f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        checkCursorMove();

        cursorMovePosition();
    }

    //Cursorの移動判定
    private void checkCursorMove() {

        float pad_move_x_num = game_pad.GetLeftStickX();
        float pad_move_y_num = game_pad.GetLeftStickY();

        pad_move_flg = pad_move_x_num == 0 && pad_move_y_num == 0 ? false : true;

        //↑うえ
        if (Input.GetKeyDown(KeyCode.W) || pad_move_y_num >= 1.0f && pad_move_flg == false) {
            cursor_position_num--;
            if (cursor_position_num < min_menu_num)
                cursor_position_num = min_menu_num;

            pad_move_flg = true;
        }

        //↓した
        if (Input.GetKeyDown(KeyCode.S) || pad_move_y_num <= -1.0f && pad_move_flg == false) {
            cursor_position_num++;
            if (cursor_position_num > max_menu_num)
                cursor_position_num = max_menu_num;
            pad_move_flg = true;
        }

    }

    //Cursorの移動
    private void cursorMovePosition() {
        //今いるところ
        Vector2 now_position = transform.position;
        //目的のUI
        Vector2 go_to_position = img_obj[cursor_position_num].transform.position;
        //移動量
        Vector2 movement = new Vector2(0.0f, 0.0f);

        //上にあったら下へ
        if (now_position.y > go_to_position.y) {
            movement.y -= cursor_move_num;
            if (movement.y + now_position.y < go_to_position.y) {
                movement.y = 0.0f;
                transform.position = new Vector2(now_position.x, go_to_position.y);
            }
            else
                transform.position = new Vector2(now_position.x, movement.y + transform.position.y);

            return;
        }

        //下にあったら上へ
        if (now_position.y < go_to_position.y) {
            movement.y += cursor_move_num;
            if (movement.y + now_position.y > go_to_position.y) {
                movement.y = 0.0f;
                transform.position = new Vector2(now_position.x, go_to_position.y);
            }
            else
                transform.position = new Vector2(now_position.x, movement.y + transform.position.y);
            return;
        }
    }

    //Cursorの位置を渡す
    public int getCursorPosision() {
        return cursor_position_num;
    }
}
