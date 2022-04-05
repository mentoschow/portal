using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour
{
    [SerializeField]
    private CameraController cam;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "isPortal1")
        {
            GameObject.Destroy(this.gameObject);
            cam.portal_count--;
        }
    }
}
