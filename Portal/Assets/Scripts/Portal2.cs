using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2 : MonoBehaviour
{
    private PortalController portal_con;

    private void Start()
    {
        portal_con = GameObject.Find("player").GetComponent<PortalController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "isPortal1")
        {
            portal_con.portal2.SetActive(false);
            portal_con.portal_count--;
        }
    }
}
