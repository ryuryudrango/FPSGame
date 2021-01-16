using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript: MonoBehaviour {

    public int playerHP = 100;
    //public Text HPLabel;
    Slider HPSlider;
    AudioSource audioSource;
    public AudioClip damage;

    private void Start()
    {
        HPSlider = GameObject.Find("HPslider").GetComponent<Slider>();
        HPSlider.value = playerHP;
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    // ゲームの1フレームごとに呼ばれるメソッド
    void Update () {
        HPSlider.value = playerHP;
        //HPLabel.text = "PlayerHP:" + playerHP.ToString();
        //Debug.Log(playerHP);

    }

	// ダメージを与えられた時に行いたい命令を書く
	void Damage(){
        playerHP = playerHP -30;
        audioSource.PlayOneShot(damage);
        if (playerHP<=0)
        {
            SceneManager.LoadScene("GameOver");
        }

	}
}

