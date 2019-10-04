using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPosition : MonoBehaviour
{
	public int repartitionSize;
	float x, z;
	float y = 0.5f;
	Vector3 pos;
	
    void Start()
    {
        x = Random.Range(-repartitionSize, repartitionSize);
		z = Random.Range(-repartitionSize, repartitionSize);
		pos = new Vector3(x, y, z);
		transform.position = pos;
    }

    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("House") || other.gameObject.CompareTag("Tree"))
		{
			x = Random.Range(-repartitionSize, repartitionSize);
			z = Random.Range(-repartitionSize, repartitionSize);
			pos = new Vector3(x, y, z);
			transform.position = pos;
		}
	}

    public void RandomDisabled()
    {
        if (Random.Range(0, 100) < 35)
            this.gameObject.SetActive(false);
    }
}
