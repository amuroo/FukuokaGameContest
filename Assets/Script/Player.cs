using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Vector3 StartPos;
    private Vector3 EndPos;
    float elapsedTime; // 経過した時間
    public float duration = 0.2f; //移動に要する時間

    public int life;

    void MoveStart(Vector3 Move)
    {
        StartPos = transform.position;
        EndPos = StartPos + Move;
        elapsedTime = 0;
    }

    void Move()
    {
        elapsedTime += Time.deltaTime;
        float rate = elapsedTime / duration;
        //rateを0~1の範囲に収める
        rate = Mathf.Clamp(rate, 0f, 1f);
        //Lerp：StartPosを0,EndPosを1としたときに、rate(0~１)の位置を返してくれる
        transform.position = Vector3.Lerp(StartPos, EndPos, rate);

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveStart(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveStart(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveStart(Vector3.up);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveStart(Vector3.down);
        }

        if (transform.position != EndPos)
        {
            Move();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.tag == "Enemy")
        {
            life--;
        }
    }
}
