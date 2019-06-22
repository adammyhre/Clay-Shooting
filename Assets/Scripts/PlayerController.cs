using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public GameObject targetPrefab;
	public TextMesh scoreText;

	private float targetInterval = 1f;
	private int targetsToShoot = 1;
	private bool isGameOver = false;
	private float restartTimer = 3f;

    void Start()
    {
		StartCoroutine (ShootingRoutine());
    }

     void Update()
    {
		if (!isGameOver) {
			scoreText.text = "Level: " + targetsToShoot;
		} else {
			scoreText.text = "Game Over!\nYour score: " + targetsToShoot;
			restartTimer -= Time.deltaTime;
			if (restartTimer <= 0 )
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

    }
	IEnumerator ShootingRoutine() {
		for (int i = 0; i < targetsToShoot; i++) {
			SpawnTarget ();
			yield return new WaitForSeconds (targetInterval);
		}

		yield return new WaitForSeconds (3f);

		if (!isGameOver) {
			targetsToShoot++;
			StartCoroutine (ShootingRoutine());
		}
	}

	void SpawnTarget() {
		GameObject targetObject = Instantiate (targetPrefab);
		float randomX = Random.Range (0f, 1f) > 0.5f ? -11 : 11;
		// Debug.Log (randomX);
		targetObject.transform.position = new Vector3(
			randomX, 
			2, 
			7);

		Target target = targetObject.GetComponent<Target>();
		target.onHitFloor = () => {
			isGameOver = true;
		};

	}

}
