using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    //テキスト
    private GameObject gameOverText;

    private GameObject runLengthText;

    //走った距離
    private float len = 0;

    //走る速度
    private float speed = 0.03f;

    //Gamoever判定
    private bool isGameOver = false;
    

	// Use this for initialization
	void Start () {
        //Select object from scene view
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
	}
	
	// Update is called once per frame

	void Update () {

        if (this.isGameOver == false){
            //距離更新
            this.len += this.speed;
            //距離表示 tostring is function to convert len. F2 is float 2 digit 
            this.runLengthText.GetComponent<Text>().text = "Distance: " + len.ToString("F2") + "m";
            }
            //ゲームオーバになった場合
            if (this.isGameOver == true){
                if (Input.GetMouseButtonDown(0)){
                    SceneManager.LoadScene("GameScene");
            }
        }
	}

    public void GameOver(){
        // Gameover text
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        this.isGameOver = true;
    }
}
