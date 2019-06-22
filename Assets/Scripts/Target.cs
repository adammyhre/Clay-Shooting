using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
	public float minHorizontalForce = 400f;
	public float maxHorizontalForce = 450f;
	public float minVerticalForce = 400f;
	public float maxVerticalForce = 800f;

	public Action onHitFloor;

    void Start()
    {
		int throwDirection = 1;

		if (transform.position.x > 0) {
			throwDirection = -1;
		}

		GetComponent<Rigidbody>().AddForce(new Vector3(
			Random.Range(minHorizontalForce, maxHorizontalForce) * throwDirection,
			Random.Range(minVerticalForce, maxVerticalForce),
			0));
    }

    void Update()
    {
        
    }

	void OnTriggerEnter (Collider otherCollider){
		if (otherCollider.GetComponent<Bullet> () != null) {
			Destroy (this.gameObject);
			Destroy (otherCollider.gameObject);
		}
		if (otherCollider.transform.name == "Floor") {
			if (onHitFloor != null)
				onHitFloor ();
		}
	}
}
