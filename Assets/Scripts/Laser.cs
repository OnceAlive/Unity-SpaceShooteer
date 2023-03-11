using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        DestroyOnVisibility();
    }

    private void DestroyOnVisibility()
    {
        if (gameObject.transform.position.y > 18)
        {
            Destroy(gameObject);
        }
    }
}
