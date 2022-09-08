using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.4f;
    [SerializeField]
    Animator animatorController;
    [SerializeField]
    Transform transformSpace;
    [SerializeField]
    Player playerComponent;

    CameraController cameraPositionController;
    
    void Start()
    {
        animatorController = GetComponent<Animator>();
        cameraPositionController = Camera.main.GetComponent<CameraController>();
    }

    void Update()
    {
        UpdateCameraPosition();
        MoveRelativeToCameraRotation();
    }

    private void MoveRelativeToCameraRotation()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        if (x == 0 && z == 0)
            return;

        var movementDirection = new Vector3(x, 0f, z);
        var globalSpaceMovementDirection = transformSpace.TransformVector(movementDirection);
        playerComponent.MoveOn(globalSpaceMovementDirection);
    }

    private void UpdateCameraPosition()
    {
        if(Input.mouseScrollDelta.y != 0)
            cameraPositionController.MoveCameraUp(Input.mouseScrollDelta.y);
        if (Input.GetKey(KeyCode.Q))
            cameraPositionController.RotateAround(-0.1f);
        else if (Input.GetKey(KeyCode.E))
            cameraPositionController.RotateAround(0.1f);
    }
}
