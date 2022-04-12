using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1 : MonoBehaviour
{
    [SerializeField]
    private PortalController portal_con;
    public Shader Portal1Shader;
    public RenderTexture RenTex;
    public Material material;

    private void Start()
    {
        portal_con = GameObject.Find("player").GetComponent<PortalController>();
        SetShader(Portal1Shader, material, RenTex);
    }

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }

    void SetShader(Shader s, Material m, RenderTexture RT)
    {
        if(s != null)
        {
            m.SetTexture("_MainTex", RT);
        }
    }
}
