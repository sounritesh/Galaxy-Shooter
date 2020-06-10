using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;
    [SerializeField]
    private float speed = 5.0f;

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
        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
        }

    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

        //contraining player to the allotted screen
        //-----------------------------------------
        //Constraints for y direction
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        //constraints for x direction
        //wrapping implemented
        if (transform.position.x > 9.49f)
        {
            transform.position = new Vector3(-9.45f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.45f)
        {
            transform.position = new Vector3(9.49f, transform.position.y, 0);
        }
    }
}