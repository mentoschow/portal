using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    //键盘输入
    private string keyUp = "w";
    private string keyDown = "s";
    private string keyLeft = "a";
    private string keyRight = "d";
    private string keyJump = "space";

    //移动量
    public float Forward;  //向前移动
    public float Right;  //向右移动

    //使用SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime)需要的参数
    private float targetForward;
    private float targetRight;
    private float velocityForward;
    private float velocityRight;
    private float smoothTime = 0.1f;

    //跳跃
    public bool jump;
    public float time;

    //输入开关
    public bool inputEnabled = true;

    void Update()
    {
        //计算移动量
        targetForward = (Input.GetKey(keyUp) ? 1.0f : 0) - (Input.GetKey(keyDown) ? 1.0f : 0);
        targetRight = (Input.GetKey(keyRight) ? 1.0f : 0) - (Input.GetKey(keyLeft) ? 1.0f : 0);
        Forward = Mathf.SmoothDamp(Forward, targetForward, ref velocityForward, smoothTime);
        Right = Mathf.SmoothDamp(Right, targetRight, ref velocityRight, smoothTime);

        //clamp
        if (Forward > 0.99)
        {
            Forward = 1.0f;
        }
        else if(Forward < -0.99)
        {
            Forward = -1.0f;
        }
        else if(Forward > 0 && Forward < 0.01 || Forward < 0 && Forward > -0.01)
        {
            Forward = 0.0f;
        }
        if (Right > 0.99)
        {
            Right = 1.0f;
        }
        else if (Right < -0.99)
        {
            Right = -1.0f;
        }
        else if (Right > 0 && Right < 0.01 || Right < 0 && Right > -0.01)
        {
            Right = 0.0f;
        }

        //计算跳跃
        if (Input.GetKeyDown(keyJump))
        {
            jump = true;
        }
        if(Input.GetKeyUp(keyJump))
        {
            jump = false;
        }

        //关闭输入
        if (inputEnabled == false)
        {
            Forward = 0.0f;
            Right = 0.0f;
        }
    }
}
