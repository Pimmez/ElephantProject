using UnityEngine;
using System.Collections;

public class TargetFollower: MonoBehaviour {

	[SerializeField] private GameObject target;

	//private Vector3 offset;

    [SerializeField] float xOffset;
    [SerializeField] float yOffset;
    [SerializeField] float zOffset;

    void Start()
	{
		//offset = target.position - transform.position;
	}

    public void Cheetah()
    {
        //this.transform.position = target.position - offset;
        xOffset = 1;
        yOffset = 1;
        zOffset = 1;

    }

    public void Elephant()
    {
        //this.transform.position = target.position - offset;
        xOffset = 1;
        yOffset = 1;
        zOffset = 1;
    }

    void LateUpdate()
    {
        Elephant();
        //Cheetah();

        this.transform.position = new Vector3(target.transform.position.x + xOffset,
                                              target.transform.position.y + yOffset,
                                              target.transform.position.z + zOffset);
    }
}