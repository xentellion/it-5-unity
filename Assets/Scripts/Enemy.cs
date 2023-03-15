using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private PolygonCollider2D box;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var a = collision.gameObject.GetComponent<AudioSource>();
        a.PlayOneShot(a.clip);
        Destroy(collision.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
