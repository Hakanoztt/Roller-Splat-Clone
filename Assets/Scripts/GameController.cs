using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    Ball ball;

    GameObject[] grounds;

    public int groundNumbers;
    void Start() {
        ball = Ball.instance;
        grounds = GameObject.FindGameObjectsWithTag("Ground");
    }
    private void Update() {
        groundNumbers = grounds.Length;

        if (ball.paintedGround==groundNumbers) {
            LevelUpdate();
        }
    }

    public void LevelUpdate() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
