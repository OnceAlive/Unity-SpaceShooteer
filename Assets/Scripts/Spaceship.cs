using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float moveSpeed;
    public GameObject laserObject;
    public GameObject cannonLeft;
    public GameObject cannonRight;
    
    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        Vector3 movement = Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(transform.position.x, -30, 30);
        transform.position = position;
    }

    private void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(laserObject, cannonRight.transform.position, laserObject.transform.rotation);
            Instantiate(laserObject, cannonLeft.transform.position, laserObject.transform.rotation);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemie")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.gameOver = true;
    }
}
