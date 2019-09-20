using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPosition : MonoBehaviour
{
	
	public float x, z;
	float y = 0.5f;
	Vector3 pos;
	
    void Start()
    {
        x = Random.Range(-10, 10);
		z = Random.Range(-10, 10);
		pos = new Vector3(x, y, z);
		transform.position = pos;
    }

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Wall"))
		{
			x = Random.Range(-10, 10);
			z = Random.Range(-10, 10);
			pos = new Vector3(x, y, z);
			transform.position = pos;
		}
	}
}
