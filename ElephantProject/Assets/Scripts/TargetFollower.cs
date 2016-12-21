using UnityEngine;
using System.Collections;

public class TargetFollower: MonoBehaviour {

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float delay = 0.8f;

    [SerializeField]
    private float height, trackDistance;

    void FixedUpdate()
    {
        Track(target);

    }

    void Track(GameObject trackTarget)
    {
        Vector3 moveCam = trackTarget.transform.position - trackTarget.transform.forward * trackDistance + Vector3.up * height;

        transform.LookAt(trackTarget.transform);
        transform.position = transform.position * delay + moveCam * (1f - delay);

    }

}