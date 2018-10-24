using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] GameObject deathFx;
	[SerializeField] Transform fxParent;
	[SerializeField] int scorePerHit = 12;

	ScoreBoard scoreBoard;

	void Start()
    {
		AddCollider();
		UpdateReferences();
	}

	void Update()
    {
		
	}

    void OnParticleCollision(GameObject other)
    {
		scoreBoard.ScoreHit(scorePerHit);
		GameObject fx = Instantiate (deathFx, transform.position, Quaternion.identity);
		fx.transform.parent = fxParent;
		Destroy(gameObject);
    }

	void UpdateReferences()
	{
		scoreBoard = FindObjectOfType<ScoreBoard>();
	}

	void AddCollider()
	{
		BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = false;
	}
}
