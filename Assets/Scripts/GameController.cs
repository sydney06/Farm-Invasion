using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public lb_BirdController birdControl;

	public Camera camera1;

	//public AudioSource gameAudio;

	Camera currentCamera;
	bool cameraDirections = true;
	Ray ray;
	RaycastHit[] hits;

	void Start()
	{
		currentCamera = Camera.main;
		birdControl = GameObject.Find("_livingBirdsController").GetComponent<lb_BirdController>();
		SpawnSomeBirds();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			camera1.transform.localEulerAngles += new Vector3(0.0f, 90.0f, 0.0f) * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			camera1.transform.localEulerAngles -= new Vector3(0.0f, 90.0f, 0.0f) * Time.deltaTime;
		}
		if (Input.GetMouseButtonDown(0))
		{
			ray = currentCamera.ScreenPointToRay(Input.mousePosition);
			hits = Physics.RaycastAll(ray);
			foreach (RaycastHit hit in hits)
			{
				if (hit.collider.tag == "lb_bird")
				{
					hit.transform.SendMessage("KillBirdWithForce", ray.direction * 500);
					//deathSound.Play();
					Crops.points += 100;
					break;
				}
				if (Crops.points == 300 || Crops.points == 600 || Crops.points == 900 || Crops.points == 1200 || Crops.points == 1500)
                {
					birdControl.BroadcastMessage("Revive");
				}
			}
		}
	}

	IEnumerator SpawnSomeBirds()
	{
		yield return 2;
		birdControl.SendMessage("SpawnAmount", 20);
	}
}