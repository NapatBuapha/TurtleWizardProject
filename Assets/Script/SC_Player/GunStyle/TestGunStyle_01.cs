using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class TestGunStyle_01 :  MonoBehaviour,IGunStyle
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletVelocity = 10;
    public void shooting()
    {
        Rigidbody2D bulletRB = Instantiate(bullet, transform.position, quaternion.identity).gameObject.GetComponent<Rigidbody2D>();
        bulletRB.velocity = new Vector2(bulletVelocity, bulletRB.velocity.y);
    }

}
