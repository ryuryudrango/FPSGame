using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmoScript : MonoBehaviour
{
    public GunScript gunScript;//PistolについてるGunscriptを参照
    public AudioClip supplement;//弾薬を補充した時に流れる音
    //AudioSource audioSource;

    void OnTriggerEnter(Collider col)
    {
        // もしPlayerにさわったら
        if (col.gameObject.tag == "Player")
        {
            //Gunscriptのramaining(残弾数)を10増やす
            gunScript.remaining += 10;
            //オーディオを違う位置から流す(AudioSource不要)
            AudioSource.PlayClipAtPoint(supplement, this.transform.position,10.0f);
            // 自分は消える
            Destroy(this.gameObject);
        }
    }


    /*
    void OnCollisionEnter(Collision collision)
    {
        // もしPlayerにさわったら
        if (collision.gameObject.tag == "Player")
        {
            gunScript.remaining += 10;
        }
        // 自分は消える
        Destroy(this.gameObject);
    }
    */
}
