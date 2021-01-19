using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;//これをやると見つけてくれる

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public int enemyCount = 0; //敵を倒した数
	public Text scoreLabel; //UIテキスト
    public GameObject clearPanel;//クリアした時に出るパネル
    public GameObject Player;//playerにfpsControllerがついている
    public GameObject Pistol;//
    AudioSource audioSource;
    public AudioClip clearSound;
    bool isCalledOnce = false;


	void Awake(){
		if (instance == null) {
			instance = this;
			//DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

    void Start()
    {
        clearPanel.SetActive(false);//最初非表示
        audioSource = GetComponent<AudioSource>();
        if (scoreLabel == null)
        {
            if (GameObject.Find("EnemyCount"))
            {
                // EnemyCountという名前のオブジェクトを探し変数に入れる
                scoreLabel = GameObject.Find("EnemyCount").GetComponent<Text>();
            }
        }
    }

    void Update()
    {
        if (scoreLabel)
        {
            // 倒した数をTextに表示する。
            scoreLabel.text = "倒した数:" + enemyCount.ToString();
        }
        else
        {
            if (GameObject.Find("EnemyCount"))
            {
                scoreLabel = GameObject.Find("EnemyCount").GetComponent<Text>();
            }
        }

        if(enemyCount >= 5)
        {
            if (!isCalledOnce)
            {
                isCalledOnce = true;
                Clear();
            }
            else
            {
                if ((Input.GetKeyDown(KeyCode.Space)))
                {
                    Player.GetComponent<FirstPersonController>().enabled = true;
                    Pistol.GetComponent<GunScript>().enabled = true;
                    clearPanel.SetActive(false);//クリア画面表示
                    SceneManager.LoadScene("APEX");
                    enemyCount = 0;
                }
            }
            
        }
    }

    void Clear()
    {
        clearPanel.SetActive(true);//クリア画面表示
        Player.GetComponent<FirstPersonController>().enabled = false;
        Pistol.GetComponent<GunScript>().enabled = false;
        audioSource.PlayOneShot(clearSound);
    }
}
