using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float h;
    private float v;

    private float speed;
    private float jumpspeed = 10f;

    private CharacterController cc;
    private Vector3 dir;

    //以下Raycast関連変数
    int layerMask;
    bool isSliding;

    RaycastHit slideHit;//当たったオブジェクトの情報を格納
    float maxDistsnce = 100;

    float slideSpeed = 0.5f;//滑り落ちるスピード 1だと早い
    private Rigidbody rb;
    Vector3 slideVector;
    // UnityStandardAssets.Characters.FirstPerson.FirstPersonController FirstPersonController;//こうやったら呼び出せる？
    float timeRunning = 0.0f;
    private AudioSource audioSource;
    private Vector3 position;
    private Vector3 velocity;


    // Use this for initialization
    void Start()
    {
        h = 0;
        v = 0;
        speed = 20;
        dir = Vector3.zero;
        cc = gameObject.GetComponent<CharacterController>();
        //Physics.gravity = new Vector3(0, 20.81f, 0);

        layerMask = 1 << LayerMask.NameToLayer("Ground");
        rb = GetComponent<Rigidbody>();
        slideVector = new Vector3(0, slideSpeed, 0);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");//水平方向の速度を取得
        v = Input.GetAxis("Vertical");

        //Debug.Log(h);
        if (Physics.Raycast(transform.position, Vector3.down, out slideHit,maxDistsnce,layerMask))
        {
            //Debug.Log("Ray出てます！！！");
            //衝突した際の面の角度とが滑らせたい角度以上かどうかを調べます。
            if (Vector3.Angle(slideHit.normal, Vector3.up) > cc.slopeLimit)
            {
                //Debug.Log("slopeLimitを超えました" + cc.slopeLimit);
                isSliding = true;
            }
            else
            {
                //Debug.Log("slopeLimit以下になりました" + cc.slopeLimit);
                isSliding = false;
            }
        }

        //dir = transform.TransformDirection(dir);    //ジャンプ軌道

        //dir *= speed;

        
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (cc.isGrounded)
        //    {
        //        dir.y = jumpspeed;
        //        audioSource.PlayOneShot(jumpSound);
        //        cc.Move(dir * Time.deltaTime);
        //    }
        //    else
        //    {
        //        audioSource.PlayOneShot(cannotJump);
        //    }
        //}

        if (isSliding)
        {//滑るフラグが立ってたら
            //timeRunning += Time.deltaTime;

            //Debug.Log("滑る処理です");
            //FirstPersonController.m_CharacterController.isGrounded = false;
            
            Vector3 hitNormal = slideHit.normal;
            dir.x += hitNormal.x *slideSpeed;
            dir.y -= hitNormal.y *slideSpeed;//y軸だけ引くことで滑り落ちるらしい https://gomafrontier.com/unity/2990
            dir.z += hitNormal.z * slideSpeed;

            //velocity = new Vector3(hitNormal.x, -1*(Quaternion.FromToRotation(Vector3.up, slideHit.normal) * transform.forward * slideSpeed).y, hitNormal.z);
            //position = transform.position - velocity * Time.deltaTime;
            //transform.position = position;

            //Debug.Log("速度は"+dir);
            cc.Move(dir *Time.deltaTime);//character controller で滑り落とす

            //slideVector = new Vector3(0, (Quaternion.FromToRotation(Vector3.down, slideHit.normal) * transform.forward * slideSpeed).y, 0);
            //rb.AddForce(slideVector);
        }
        else
        {
            dir = new Vector3(0, 0, 0);//resetする
        }

        //Debug.Log("角度は" + dir);

    }
}