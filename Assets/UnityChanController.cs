using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

    //アニメーションするためのコンポーネントを入れる

    Animator animator;
    
    // 地面の位置
    private float groundLevel = -3.0f;

    //Unityちゃんを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    // ジャンプの速度の減衰
    private float dump = 0.8f;

    // ジャンプの速度
    float jumpVelocity = 20;

    // ゲームオーバになる位置
    private float deadLine = -9;


    // Use this for initialization
    void Start(){
        
        // アニメータのコンポーネントを取得する
        this.animator = GetComponent<Animator>();

        // Rigidbody2Dのコンポーネントを取得する
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 走るアニメーションを再生するために、Animatorのパラメータを調節する
        this.animator.SetFloat("Horizontal", 1);

        // 着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        // No sound when jumping
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        // 着地状態でクリックされた場合（追加）

        if (Input.GetMouseButtonDown(0) && isGround)
        {
            // 上方向の力をかける（追加）
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        // クリックをやめたら上方向への速度を減速する
        if (Input.GetMouseButton(0) == false){
            if (this.rigid2D.velocity.y > 0){
                this.rigid2D.velocity *= this.dump;
            }
        }

        // deadlin over---Gameover
        if (transform.position.x < this.deadLine){
            
            //UIController game over
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //Destroy Unity 
            Destroy(gameObject);
        }
    }
}

