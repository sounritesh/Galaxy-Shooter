using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Collided with {other.name}");
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            //performing a null check
            if (player != null)
            {
                //calling function to enable power up for 5 seconds
                player.TurnTripleShotOn();
            }
            Destroy(this.gameObject);
        }
    }
}
