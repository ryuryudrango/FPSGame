using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmoScript : MonoBehaviour
{
    public GunScript gunScript;
    AudioSource audioSource;
    public AudioClip supplement;

    void OnTriggerEnter(Collider col)
    {
        // もしPlayerにさわったら
        if (col.gameObject.tag == "Player")
        {
            gunScript.remaining += 10;
            AudioSource.PlayClipAtPoint(supplement, this.transform.position,10.0f);//オーディオを違う位置から流す方法
            Destroy(this.gameObject);
        }
        // 自分は消える
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
