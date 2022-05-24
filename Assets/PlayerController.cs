using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    public bool isAble;
    public GameObject prefab;
    private Vector3 newScale;

    void Start()
    {
        isAble = false;
        newScale = new Vector3(0.2f,0.3f,0.2f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += new Vector3(0, 0, speed);
            transform.Translate(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.position -= new Vector3(0, 0,   speed);
            transform.Translate(0,0, -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += new Vector3(0, rotationSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles -= new Vector3(0, rotationSpeed, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject clon;
            clon = Instantiate(prefab);
            clon.transform.position = transform.position - new Vector3(0, 0, -1);
            clon.transform.localScale = newScale *= 1.1f;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "EnablerCube")
        {
            isAble = true;
        }else if (col.gameObject.name == "DisablerCube")
        {
            isAble = false;
        }     
    }
}
