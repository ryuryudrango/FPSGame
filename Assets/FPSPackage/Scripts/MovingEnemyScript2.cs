using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyScript2 : MonoBehaviour
{
	UnityEngine.AI.NavMeshAgent agent; //NavMeshのエージェント
	GameObject player; //プレイヤー
	float distance;
	float maxDistance = 5;

	// Use this for initialization
	void Start()
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		distance = Mathf.Sqrt(Mathf.Pow((player.transform.position.x - this.transform.position.x), 2) + Mathf.Pow((player.transform.position.y - this.transform.position.y), 2));
		//Debug.Log(distance);
		if (distance < maxDistance)
        {
			// 目的地をプレイヤーに設定する。
			agent.SetDestination(player.transform.position);
		}
	}
}
