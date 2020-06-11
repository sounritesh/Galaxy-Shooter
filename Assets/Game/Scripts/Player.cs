using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private float fireRate = 0.25f;
    private float canFire = 0.0f;

    public bool canTripleShot = false;

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

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //ensuring cooldown time
        if (Time.time > canFire)
        {  
            //shooting 3 lasers when Triple Shot power up is active
            if (canTripleShot)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }
            //shooting a single laser
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            }
            canFire = Time.time + fireRate;
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * _speed * verticalInput);

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

    public void TurnTripleShotOn()
    {
        //enable triple shot power up
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        //wait for 5 seconds before turning power up off
        yield return new WaitForSeconds(5);
        canTripleShot = false;
    }
}