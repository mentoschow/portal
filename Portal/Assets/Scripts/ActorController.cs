using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    public GameObject PlayerModel;  //玩家模型
    private UserInput PlayerInput;  //玩家输入
    private Rigidbody PlayerRigid;  //玩家刚体

    private Vector3 moveVec;  //移动向量
    public float moveVelocity;  //移动速度
    private Vector3 jumpThrust;  //跳跃冲量
    private bool onGround = true;  //判断是否在地面

    void Awake()
    {
        PlayerInput = GetComponent<UserInput>();
        PlayerRigid = GetComponent<Rigidbody>();
        moveVelocity = 5.0f;
    }

    void Update()
    {
        //计算移动向量
        if (onGround)
        {
            moveVec = PlayerInput.Forward * new Vector3(0, 0, 1) + PlayerInput.Right * new Vector3(1, 0, 0);
        }
    }

    //控制玩家移动
    void FixedUpdate()
    {
        PlayerRigid.position += moveVec * moveVelocity * Time.fixedDeltaTime;

        if (PlayerInput.jump)
        {
            if (onGround)
            {
                jumpThrust = new Vector3(0, 5.0f, 0);
                PlayerRigid.velocity += jumpThrust;
            }
            jumpThrust = Vector3.zero;
        }       

        if (PlayerRigid.velocity.y == 0)
        {
            onGround = true;
            PlayerInput.inputEnabled = true;
        }
        else
        {
            onGround = false;
            PlayerInput.inputEnabled = false;
        }
    }
}
