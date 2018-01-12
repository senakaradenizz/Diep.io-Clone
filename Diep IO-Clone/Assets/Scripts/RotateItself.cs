using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItself : MonoBehaviour {

    [Range(1,100)]
    public float speed;

	void Start () {
        speed = Random.Range(1f, 100f);

        if (Random.Range(0f, 1f) < 0.5f)
            speed = -speed; //Clockwise or Counter clockwise.
	}
	
	void Update () {
        RotateIt();
	}

    void RotateIt ()
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
