using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    //0 for TripleShot, 1 for SpeedBoost, 2 for Shield
    [SerializeField]
    private int powerupID;

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
                //calling functions to enable power ups
                if(powerupID == 0)
                {
                    //enable TripleShot
                    player.TurnTripleShotOn();
                }
                else if(powerupID == 1)
                {
                    //enable SpeedBoost
                    player.TurnSpeedBoostOn();
                }
                else if(powerupID == 2)
                {
                    //enable Shield
                }
            }
            Destroy(this.gameObject);
        }
    }
}
