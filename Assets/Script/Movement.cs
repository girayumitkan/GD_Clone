using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    #region Fields
    public Vector2 corner;
    public Vector2 oppositeCorner;
    const float SpeedValue = 10.4f;
    Rigidbody2D rb2d;
    int gravity = 1;
    public int state = 0;
    

    [SerializeField]
    public Transform GroundCheckTransform;
    public float GroundCheckRadius;
    public LayerMask GroundMask;
    public Transform Sprite;


    #endregion

    #region Properties

    //public int setGravity
    //{
    //    set { gravity = value; }
    //}
    public int State
    {
        set { state = value; }
    }
    #endregion
    

    // Start is called before the first frame update
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        corner = new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f);
        oppositeCorner = new Vector2(transform.position.x + 0.5f, transform.position.y + 0.5f);
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Finish")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            SceneManager.LoadScene("Finish");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // move the player every frame
        transform.position += Vector3.right * SpeedValue * Time.deltaTime;

        if (state == 0)
        {
            Cube();
        }
        else if (state == 1)
        {
            Ship();
        }

    }
    void Cube()
    {
        rb2d.gravityScale = 12.41067f;
        if (isOnGround())
        {
            //Rotate the player when the player is on ground
            Vector3 Rotation = Sprite.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z / 90) * 90;
            Sprite.rotation = Quaternion.Euler(Rotation);

            if (Input.GetMouseButton(0))
            {
                Jump();

            }
            //print("ground");
        }
        
        else
        {     
                // Rotate the player when jump
                Sprite.Rotate(Vector3.back, 452.41f * Time.deltaTime * gravity);
            
            //print("not ground");
        }
    }
    void Ship()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb2d.velocity.y * 2);
        if (Input.GetMouseButton(0))
        {
            rb2d.gravityScale = -4.3f;
        }
        else
        {
            rb2d.gravityScale = 4.3f;
        }
    }
    public void Jump()
    {
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(Vector2.up * 24f * gravity, ForceMode2D.Impulse);
    }

    bool isOnGround()
    {
        return Physics2D.OverlapBox(GroundCheckTransform.position , Vector2.right * 1f + Vector2.up * GroundCheckRadius,0, GroundMask);
    }
    

    public void ChangeThroughPortal(int gravity, int state)
    {
        this.gravity = gravity;
        this.state = state;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    
}
