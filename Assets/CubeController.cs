using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

  
    // キューブの移動速度
    private float speed = -12;

    Rigidbody2D rigid2D;

    //消滅位置
    private float deadLine = -10;
    
    // Use this for initialization
	void Start () {

        // Rigidbody2Dのコンポーネントを取得する
        this.rigid2D = GetComponent<Rigidbody2D>();
    }
	// Update is called once per frame

	void Update () {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if(transform.position.x < this.deadLine){
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {

         bool isGound = (transform.position.y > -3.0) ? false : true;

        if (other.gameObject.tag == "Blocktag") { GetComponent<AudioSource>().Play(); }

        if (isGound == true) { GetComponent<AudioSource>().volume = 1; }
        
        else { GetComponent<AudioSource>().volume = 0; }
       
    }
}
