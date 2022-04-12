using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject Player;
    private GameObject CameraXHandle;
    private UserInput PlayerInput;

    public float CamXVelocity;
    public float CamYVeloctiy;
    private float tempEulerX;

    void Awake()
    {
        CameraXHandle = transform.parent.gameObject;
        Player = CameraXHandle.transform.parent.gameObject;
        PlayerInput = Player.GetComponent<UserInput>();
        tempEulerX = CameraXHandle.transform.eulerAngles.x;
    }

    void Update()
    {
        //计算镜头旋转
        Player.transform.Rotate(Vector3.up, PlayerInput.CamRight * CamXVelocity * Time.deltaTime);
        tempEulerX -= PlayerInput.CamForward * CamYVeloctiy * Time.deltaTime;
        tempEulerX = Mathf.Clamp(tempEulerX, -45, 45);
        CameraXHandle.transform.localEulerAngles = new Vector3(tempEulerX, 0, 0);
    }
}
