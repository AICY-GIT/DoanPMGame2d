using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform FireFromPosi;
    public float RateOfFire = 0.3f;
    public float BulletSpeed;
    public GameObject Muzzle;


    private float TimeBtwFire;
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Gunrotate();
        TimeBtwFire-=Time.deltaTime;
        if (Input.GetMouseButton(0)&& TimeBtwFire <= 0)
        {
            Firebullet();
        }
    }

    private void Firebullet()
    {
        TimeBtwFire = RateOfFire;
        GameObject BulletTemp=Instantiate(bullet,FireFromPosi.position,Quaternion.identity);
        GameObject MuzzleTemp = Instantiate(Muzzle, FireFromPosi.position, Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg));
        Rigidbody2D rb= BulletTemp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right*BulletSpeed,ForceMode2D.Impulse);

    }

    void Gunrotate()
    {
        //input.mouse position = vi tri con chuot tren mang hinh 
        // chuyen doi vi tri cua chuot va chuyen ve vi tri world space 
        Vector3 mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir=mousePosition- transform.position;
        //tinh goc cua chuot vs ng choi
        angle = Mathf.Atan2(lookDir.y, lookDir.x);
        //Thay doi goc cua sung
        transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
        float weaponScaleFactor = 0.4f;
        if (transform.eulerAngles.z>90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector2(1, -1)* weaponScaleFactor;
        }
        else
        {
            transform.localScale = new Vector2(1, 1)* weaponScaleFactor;
        }

    }
    
}
