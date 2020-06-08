using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start: called");
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update: called");
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}