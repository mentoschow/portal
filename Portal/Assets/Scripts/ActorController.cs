using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    public GameObject PlayerModel;  //���ģ��
    private UserInput PlayerInput;  //�������
    private Rigidbody PlayerRigid;  //��Ҹ���

    private Vector3 moveVec;  //�ƶ�����
    public float moveVelocity;  //�ƶ��ٶ�
    private Vector3 jumpThrust;  //��Ծ����
    private bool onGround = true;  //�ж��Ƿ��ڵ���

    void Awake()
    {
        PlayerInput = GetComponent<UserInput>();
        PlayerRigid = GetComponent<Rigidbody>();
        moveVelocity = 5.0f;
    }

    void Update()
    {
        //�����ƶ�����
        if (onGround)
        {
            moveVec = PlayerInput.Forward * new Vector3(0, 0, 1) + PlayerInput.Right * new Vector3(1, 0, 0);
        }
    }

    //��������ƶ�
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
