using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Player : MonoBehaviour
{
    public string name;
    public int life = 3;
    public int bullets = 3;
    public double delayTime = 10.0f;
    private float counter = 0;
    public int speed = 1;
    public AudioClip[] sounds;

    public GameObject[] Meshs;

    public void shootMyBullet(GameObject bullet)
    {
        if (counter > delayTime)
        {
            Vector3 p = new Vector3(transform.position.x + transform.forward.x, 1.7f, transform.position.z + transform.forward.z);
            GameObject Boule = Instantiate(bullet, p, transform.rotation);
            Boule.GetComponent<Bullets>().owner = this.gameObject;
            Boule.GetComponent<Rigidbody>().velocity = transform.forward * Time.deltaTime * speed;
            counter = 0;
        }
    }

    private void Update()
    {
        counter += Time.deltaTime;
        if (life == 0)
        {
            Dead();
        }
    }

    public void GetHit()
    {
        life -= 1;
    }

    void Dead()
    {

    }

    void rechargeBullets()
    {

    }
}
