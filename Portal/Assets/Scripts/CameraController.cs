using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject Player;
    private GameObject CameraXHandle;
    private UserInput PlayerInput;
    private AddObject CreateObject;

    public float CamXVelocity;
    public float CamYVeloctiy;
    private float tempEulerX;

    private GameObject portal1;
    private GameObject portal2;
    public int portal_count = 0;

    void Awake()
    {
        CameraXHandle = transform.parent.gameObject;
        Player = CameraXHandle.transform.parent.gameObject;
        PlayerInput = Player.GetComponent<UserInput>();
        tempEulerX = CameraXHandle.transform.eulerAngles.x;
        CreateObject = CameraXHandle.GetComponent<AddObject>();
    }

    void Update()
    {
        //计算镜头旋转
        Player.transform.Rotate(Vector3.up, PlayerInput.CamRight * CamXVelocity * Time.deltaTime);
        tempEulerX -= PlayerInput.CamForward * CamYVeloctiy * Time.deltaTime;
        tempEulerX = Mathf.Clamp(tempEulerX, -45, 45);
        CameraXHandle.transform.localEulerAngles = new Vector3(tempEulerX, 0, 0);

        //射线检测
        if (Input.GetMouseButtonDown(0))
        {           
            SingleRay();
        }
    }

    void SingleRay()
    {
        //创建射线
        Ray shootRay = new Ray(CameraXHandle.transform.position, CameraXHandle.transform.forward);
        //获取检测到的物体信息
        RaycastHit hitObj;
        //检测是否打到墙壁       
        if (Physics.Raycast(shootRay, out hitObj, Mathf.Infinity, LayerMask.GetMask("Wall")))
        {
            if (portal_count == 0)
            {
                portal1 = CreateObject.NewObject1(hitObj.point, hitObj.normal);
                portal_count++;
            }
            else if (portal_count == 1)
            {
                portal2 = CreateObject.NewObject2(hitObj.point, hitObj.normal);
                portal_count++;
            }
            else if (portal_count == 2)
            {
                GameObject.DestroyImmediate(portal1);
                GameObject.DestroyImmediate(portal2);
                portal_count = 0;
            }
        }
    }
}
