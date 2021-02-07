using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript: MonoBehaviour {

    public int playerHP = 100;
    Slider HPSlider;//HPバーを定義
    AudioSource audioSource;//音を流す場所を宣言
    public AudioClip damage;//ダメージを喰らった時に流れる音

    //public Text HPLabel;

    private void Start()
    {
        //HPSliderという名前のオブジェクトを探してくる
        HPSlider = GameObject.Find("HPSlider").GetComponent<Slider>();
        //音を流す場所をこのオブジェクトのAudioSourceに定義
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    // ゲームの1フレームごとに呼ばれるメソッド
    void Update()
    {
        //HPバーの値をplayerHPと同期
        HPSlider.value = playerHP;
    }

        //HPLabel.text = "PlayerHP:" + playerHP.ToString();
        //Debug.Log(playerHP);

    

	// ダメージを与えられた時に行いたい命令を書く
	void Damage(){
        playerHP = playerHP -30;
        //ダメージ音を再生
        audioSource.PlayOneShot(damage);
        if (playerHP<=0)
        {
            SceneManager.LoadScene("GameOver");
        }

	}
}

