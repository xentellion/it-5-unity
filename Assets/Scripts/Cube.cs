using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Cube : MonoBehaviour
{
    [HideInInspector] public Transform tf;
    private Rigidbody2D rb;
    private BoxCollider2D box;

    [SerializeField] [Range(0, 20)] private float speed = 10f;
    [SerializeField][Range(0, 20)] private float jump = 10f;
    [Space(5)]
    [Header("Trash")]
    [SerializeField] private float speed1 = 10f;
    [SerializeField] private LayerMask ground;

    public AudioSource audio;

    private void Awake()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        var input = Input.GetAxis("Horizontal");

        rb.AddForce(new Vector2(speed * input, 0), ForceMode2D.Force);

        Debug.Log(GroundCheck());
        if (Input.GetButton("Jump") && GroundCheck())
        {
            Jump();
        }
        //rb.velocity = new Vector2(10f * input * Time.deltaTime, 0);

        //tf.Translate(new Vector2(10f * input * Time.deltaTime, 0f));
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapBox(transform.position - new Vector3(0, 0.1f), box.bounds.size, 0, ground);
    }

    private void OnDestroy()
    {
        Debug.Log("dfghjm");
        
    }
}
