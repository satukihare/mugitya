using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseControl : MonoBehaviour {
    //パッド
    public GamePad game_pad = null;
    //pause画面
    public GameObject pouse_ui = null;

    //pauseのフラグ
    private bool pause_mode_flg = false;

    public cursorMove cursor = null;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        //pauseButtonが押されたか
        pauseButtonCheck();

        //pause中にpauseメニューの動作判定
        if (pause_mode_flg)
            pauseActionCheck();

        //pauseなら停止させる
        if (pause_mode_flg) {
            Time.timeScale = 0.0f;
            pouse_ui.SetActive(true);
        }
        else if (!pause_mode_flg) {
            Time.timeScale = 1.0f;
            pouse_ui.SetActive(false);
        }
    }

    //pauseの判定
    private void pauseButtonCheck() {

        //ポーズボタン判定が押されたたら止まる
        if (game_pad.GetMenuButton() || Input.GetKeyDown(KeyCode.Escape)) {
            pause_mode_flg = pause_mode_flg ? false : true;
        }
    }

    private void pauseActionCheck() {

        //決定Buttonが押されたら
        if (Input.GetKeyDown(KeyCode.Return) || game_pad.GetCircle()) {
            //cursorの位置
            int cursor_pos_num = cursor.getCursorPosision();

            if (0 == cursor_pos_num) {
                pause_mode_flg = false;
            }
            if (1 == cursor_pos_num) {
                Time.timeScale = 1f;
                FadeManager.FadeOut(0);
                pause_mode_flg = false;
            }
        }
    }
}