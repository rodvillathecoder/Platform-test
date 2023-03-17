using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 8;
    public float jumpSpeed = 5;
    private Rigidbody2D rigid;

    public LayerMask FloorMask;
    public LayerMask WallMask;

    public GameObject Point1, Point2, Point3, Point4;

    public int saltosTotales;
    private int saltoActuales;

    private bool isGrounded = false;
    private bool wallDetect;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapArea(Point1.transform.position, Point2.transform.position, FloorMask);
        wallDetect = Physics2D.OverlapArea(Point3.transform.position, Point4.transform.position, WallMask);

        if ( isGrounded == true)
        {
            saltoActuales = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigid.AddForce(Vector2.up * jumpSpeed);
            }
            rigid.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rigid.velocity.y);
        }
        if(isGrounded == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && (saltoActuales < saltosTotales))
            {
                rigid.AddForce(Vector2.up * jumpSpeed);
                saltoActuales++;
            }

            if (wallDetect == false)
            {

                rigid.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rigid.velocity.y);
            }
        }
       
    }
}
