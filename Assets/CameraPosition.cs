using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {

    public GameObject player;

	void Update () {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, player.transform.position, 0.1f);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
	}
}
