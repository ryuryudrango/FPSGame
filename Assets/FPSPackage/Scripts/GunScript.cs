using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections.Generic;

public class GunScript : MonoBehaviour {
    //public AudioClip gunSound;
    public GameObject explosion;
    public GameObject sparks;
    AudioSource audioSource;
    RaycastHit hit;

    const int magazineSize = 10;//銃に最大何発入るか
    public int remaining = 20;//予備弾薬
    int currentMagazine = magazineSize;//最初は満タンに入れてます

    //テキスト関連
    public Text bulletText;//現弾薬数(銃に入ってる弾薬数)
    public Text remainingText;//予備弾薬数(所持してる弾薬数)

    public AudioClip gun;
    public AudioClip reload;
    public AudioClip cannotReload;

    // ゲームが始まった時に1回呼ばれるメソッド
    void Start () {
        bulletText.text = "現弾薬数:" + currentMagazine.ToString();
        remainingText.text = "予備弾薬数:" + remaining.ToString();

        audioSource = gameObject.AddComponent<AudioSource>();
       
	}

	// ゲームの1フレームごとに呼ばれるメソッド
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            if (currentMagazine > 0)//弾薬が銃に入っていたら
            {
                audioSource.PlayOneShot(gun); //gunを鳴らす
                Shot();
                Instantiate(explosion, transform.position, Quaternion.identity);
            }
            else
            {
                audioSource.PlayOneShot(cannotReload);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))//Rキーが押されたらリロード
        {
            if (remaining >= magazineSize)//フルでリロードできる時
            {
                remaining = currentMagazine + remaining - magazineSize;//残り弾薬数
                currentMagazine = magazineSize;//リロード完了
            }
            else if (remaining > 0 && remaining < magazineSize)//フルではできない時
            {
                if (currentMagazine + remaining >= 10)
                {
                    remaining = currentMagazine + remaining - magazineSize;//残り弾薬数
                    currentMagazine = magazineSize;//リロード完了
                }
                else
                {
                    currentMagazine = currentMagazine + remaining;
                    remaining = 0;
                }
            }
            else
            {
                audioSource.PlayOneShot(cannotReload);
                return;
            }
            audioSource.PlayOneShot(reload); //reloadを鳴らす
            /*
            if(currentMagazine + remaining <= 0)
            {
                RemaingText.text = "弾切れです";
            }
            */
        }
        bulletText.text = currentMagazine.ToString();
        remainingText.text = remaining.ToString();

    }

	// 銃をうつ時に行いたいことをこの中に書く
	void Shot(){
        currentMagazine--;
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = Camera.main.ScreenPointToRay(center);
        float distance = 100;
        if (Physics.Raycast(ray,out hit,distance))
        {
            Instantiate(sparks, hit.point, Quaternion.identity);
            if (hit.collider.tag=="Enemy")
            {
                hit.collider.SendMessage("Damage");
            }
        }

	}
}
