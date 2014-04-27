﻿using UnityEngine;
using System.Collections;

public class wp_Bubble : MonoBehaviour {

    public float impulseForce;
    public float spriteChangeInterval;

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;

	// Use this for initialization
	void Start () {

        float randomForceOffset = Random.Range(0.5f, 1.5f);

        rigidbody2D.AddForce(
            GameObject.Find("Player").transform.right * impulseForce * randomForceOffset);

        StartCoroutine(SpriteChange());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpriteChange()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;

        yield return new WaitForSeconds(spriteChangeInterval * 2);

        gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;

        yield return new WaitForSeconds(spriteChangeInterval);

        gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;

        yield return new WaitForSeconds(spriteChangeInterval);

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 11) // if object is an enemy
        {
            Debug.Log("Hitting " + other.gameObject.name + " with 10 damage.");
            other.gameObject.GetComponent<GenericEnemy>().TakeDamage(10);

            Destroy(gameObject);
        }
    }
}
