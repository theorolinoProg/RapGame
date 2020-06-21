using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public int force;
    public int distance;
    public int dommage;
    public int size;
    public int speed;
    public Rigidbody bullet;
    public GameObject owner;

    void Update()
    {
        transform.Translate(0, 0, 0.11f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != owner && collision.gameObject.tag != "Bullet")
            Destroy(this.gameObject);
        if (collision.gameObject.tag == "Player" && collision.gameObject != owner)
        {
            collision.gameObject.GetComponent<Player>().GetHit();
        }
    }
}
