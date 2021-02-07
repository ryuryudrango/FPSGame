using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public AudioClip healSound;
    

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
            AudioSource.PlayClipAtPoint(healSound, col.transform.position,10f);//オーディオを違う位置から流す方法
            Destroy(this.gameObject);//消える前に音を流さないと(コルーチンもありかも)
        }
    }


    //audioSource.PlayOneShot(healSound);を使う場合はaudiosourceの定義とコンポーネント追加がいる
    //AudioSource audioSource;

    //void Start()
    //{
    //    audioSource = gameObject.AddComponent<AudioSource>();

    //}

    //private IEnumerator DelayMethod()
    //{
    //    yield return new WaitForSeconds(1.0f);
    //    Destroy(this.gameObject);
    //}
}

