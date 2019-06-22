using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public Vector3 direction;
	public float speed = 100f;
	public float lifetime = 1f;


    void Update()
    {
		transform.position += direction * speed * Time.deltaTime;
		lifetime -= Time.deltaTime;
		if (lifetime <= 0)
			Destroy (gameObject);
    }
}
