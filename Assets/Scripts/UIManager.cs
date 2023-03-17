using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public Slider levelSlider;
    public float sliderSpeed;
    public GameController gameController;
    Ball ball;
    private void Start() {
        ball = Ball.instance;
        levelSlider.minValue = 0;

    }
    void Update() {
        levelSlider.value = Mathf.Lerp(levelSlider.value, ball.paintedGround, sliderSpeed*Time.deltaTime);
        levelSlider.maxValue = gameController.groundNumbers;
    }
}
