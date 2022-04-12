using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    private UserInput PlayerInput;
    private GameObject main_cam;
    public Image Aim;
    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal1_cam;
    public GameObject portal2_cam;
    private Camera cam1;
    private Camera cam2;

    public int portal_count = 0;

    void Start()
    {
        PlayerInput = gameObject.GetComponent<UserInput>();
        main_cam = GameObject.Find("CameraXHandle");
        cam1 = portal1_cam.GetComponent<Camera>();
        cam2 = portal2_cam.GetComponent<Camera>();

        Aim.enabled = false;
        portal1.SetActive(false);
        portal2.SetActive(false);
    }

    void Update()
    {
        if (PlayerInput.aiming)
        {
            Aim.enabled = true;
        }
        else
        {
            Aim.enabled = false;
        }

        if (PlayerInput.aiming && PlayerInput.shooting)
        {
            SingleRay();
        }

        
    }

    void SingleRay()
    {
        //创建射线
        Ray shootRay = new Ray(main_cam.transform.position, main_cam.transform.forward);
        //获取检测到的物体信息
        RaycastHit hitObj;
        //检测是否打到墙壁       
        if (Physics.Raycast(shootRay, out hitObj, Mathf.Infinity, LayerMask.GetMask("Wall")))
        {
            if (portal_count == 0)
            {
                portal1.SetActive(true);
                portal1.transform.localPosition = Vector3.MoveTowards(portal1.transform.localPosition, hitObj.point, 100);
                portal1.transform.forward = -hitObj.normal;
                portal1.transform.Translate(new Vector3(0, 0, -0.01f));
                portal_count++;

                portal1_cam.transform.localPosition = Vector3.MoveTowards(portal1_cam.transform.localPosition, portal1.transform.localPosition, 100);
                portal1_cam.transform.forward = main_cam.transform.localPosition - portal1_cam.transform.localPosition;
                //portal1_cam.transform.RotateAround(portal1.transform.localPosition, Vector3.Cross(main_cam.transform.localPosition - portal2.transform.localPosition, portal2.transform.right), 180);
                //cam1.nearClipPlane = Vector3.Distance(portal1_cam.transform.localPosition, portal2.transform.localPosition);
            }
            else if (portal_count == 1)
            {
                portal2.SetActive(true);
                portal2.transform.localPosition = Vector3.MoveTowards(portal2.transform.localPosition, hitObj.point, 100);
                portal2.transform.forward = -hitObj.normal;
                portal2.transform.Translate(new Vector3(0, 0, -0.01f));
                portal_count++;

                portal2_cam.transform.localPosition = Vector3.MoveTowards(portal2_cam.transform.localPosition, portal2.transform.localPosition, 100);
                portal2_cam.transform.forward = main_cam.transform.localPosition - portal2_cam.transform.localPosition;
            }
            else if (portal_count == 2)
            {
                portal1.SetActive(false);
                portal2.SetActive(false);
                portal_count = 0;
            }
        }
    }
}
