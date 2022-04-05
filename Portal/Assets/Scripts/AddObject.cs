using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObject : MonoBehaviour
{
    public GameObject prefab1;  //需要创建的复制体
    public GameObject prefab2;
    
    public GameObject NewObject1(Vector3 position, Vector3 normal)
    {
        GameObject newObject = GameObject.Instantiate(prefab1);
        newObject.transform.position = position;
        newObject.transform.forward = -normal;
        newObject.transform.Translate(new Vector3(0, 0, -0.01f));
        return newObject;
    }

    public GameObject NewObject2(Vector3 position, Vector3 normal)
    {
        GameObject newObject = GameObject.Instantiate(prefab2);
        newObject.transform.position = position;
        newObject.transform.forward = -normal;
        newObject.transform.Translate(new Vector3(0, 0, -0.01f));
        return newObject;
    }
}
