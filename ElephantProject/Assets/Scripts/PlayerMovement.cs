using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour{

    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public CharacterController controller;

    void Update()
    {
        transform.Rotate(0, InputManager.MainHorizontal() * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(-Vector3.forward);

        float curSpeed = speed * InputManager.MainVertical();
        controller.SimpleMove(forward * curSpeed);
    }
}