using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCode : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        //rb.velocity += (this.transform.forward * 20f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            Destroy(this.gameObject, 3f);
            disappear();
        }
        Debug.Log("OnTriggerEnter was called!");
    }

    void disappear()
    {
        this.transform.Rotate(Vector3.up, 1400 * Time.deltaTime);
    }
}
