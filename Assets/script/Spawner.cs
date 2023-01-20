using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }

    public GameObject RedPlane;
	public GameObject OrangePlane;

	public Vector3 turretPosition;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else {
			Instance = this;
		}
	}

	public void SetTurrentPosition(Vector3 p_turretPosition) {
		turretPosition = p_turretPosition;
	}

	public void spawnPlane(GameObject plane) {
		GameObject planeSpawnPoint = new GameObject();
		float randomHeight = Random.Range(0.5f, 1.5f);
		float randomDepth = Random.Range(0.5f, 1.5f);
		Vector3 planeSpawnPosition = new Vector3(0.0f, this.turretPosition.y + randomHeight, this.turretPosition.z + randomDepth);

		planeSpawnPoint.transform.position = planeSpawnPosition;
		Instantiate(plane, planeSpawnPoint.transform);
	}

	public void spawnRedPlane() {
		spawnPlane(RedPlane);
	}

	public void spawnOrangePlane() {
		spawnPlane(OrangePlane);
	}

	public void spawnRedPlaneAfterTime(float time) {
		Invoke("spawnRedPlane", time);
	}

	public void spawnOrangePlaneAfterTime(float time)
	{
		Invoke("spawnOrangePlane", time);
	}
}
