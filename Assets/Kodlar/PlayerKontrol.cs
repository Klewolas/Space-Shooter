using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKontrol : MonoBehaviour
{
    Rigidbody fizik;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;
    public float karakterHiz;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float egim;
    float atesZamani = 0;
    public float saldiriHizi;
    public GameObject kursun;
    public Transform kursuncikmaYeri;
    new AudioSource audio;

    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time>atesZamani)
        {
            atesZamani = Time.time + saldiriHizi;
            Instantiate(kursun, kursuncikmaYeri.position, Quaternion.identity);
            audio.Play();
        }
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vec = new Vector3(horizontal,0,vertical);

        fizik.velocity = vec*karakterHiz;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), 0.0f, Mathf.Clamp(transform.position.z, minZ, maxZ));

        fizik.rotation = Quaternion.Euler(0, 0, fizik.velocity.x*-egim);
    }
}
