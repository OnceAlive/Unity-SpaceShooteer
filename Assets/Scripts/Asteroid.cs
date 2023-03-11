using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(180, 180, 0) * Time.deltaTime);
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (!DestroyOnVisibility())
        {
            GameManager.instance.score += 1;
        }
    }

    private bool DestroyOnVisibility()
    {
        if (gameObject.transform.position.y < -18)
        {
            Destroy(gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }
}
