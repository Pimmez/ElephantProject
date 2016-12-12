using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] float xValue;
	[SerializeField] float yValue;
	[SerializeField] float zValue;

	void Start()
	{

	}

	// Update is called once per frame
	void Update () {
		this.transform.Rotate(
			xValue * speed * Time.deltaTime, 
			yValue * speed * Time.deltaTime, 
			zValue * speed * Time.deltaTime
		);
	}
}
