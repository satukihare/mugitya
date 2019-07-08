using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour {

    private AsyncOperation async;
    [SerializeField] gameMnger game_mnger;

    void Start() {
        LoadNextScene();
    }


    public void LoadNextScene() {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene() {
        async = SceneManager.LoadSceneAsync(gameMnger.getNextSceneNumber());

        while (!async.isDone) {
            float load_percentage = async.progress;
            yield return null;
        }
    }
}
