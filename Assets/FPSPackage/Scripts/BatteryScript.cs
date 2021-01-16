using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour
{
    public PlayerScript playerScript;
    AudioSource audioSource;
    public AudioClip healSound;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        // もしPlayerにさわったら
        if (col.gameObject.tag == "Player")
        {
            if(playerScript.playerHP <= 90)
            {
                playerScript.playerHP += 10;
            }
            else if(playerScript.playerHP >90 && playerScript.playerHP < 100)
            {
                playerScript.playerHP = 100;
            }
            else
            {
                return;
            }
            AudioSource.PlayClipAtPoint(healSound, new Vector3(1, 0, 0));//オーディオを違う位置から流す方法
            //audioSource.PlayOneShot(healSound);
            Destroy(this.gameObject);//消える前に音を流さないと
            //this.gameObject.SetActive(false);
            //StartCoroutine("DelayMethod");
        }
        // 自分は消える
    }

    //private IEnumerator DelayMethod()
    //{
    //    yield return new WaitForSeconds(1.0f);
    //    Destroy(this.gameObject);
    //}
}

