using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public float HP;
	public float speed;
	public bool MoveRight;
	public float distance;
	public Transform detection;
	public GameObject BoinkEffect;

	
	void Update()
	{
		
		if (MoveRight)
		{
			transform.Translate(2 * Time.deltaTime * speed, 0, 0);
			transform.localScale = new Vector2(-1, 1);
		}
		else
		{
			transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
			transform.localScale = new Vector2(1, 1);
		}
	}
	void OnTriggerEnter2D(Collider2D trig)
	{
		if (trig.gameObject.CompareTag("turn"))
		{

			if (MoveRight)
			{
				MoveRight = false;
			}
			else
			{
				MoveRight = true;
			}
		}
	}
}