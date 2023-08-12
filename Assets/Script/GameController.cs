using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Movement movement;
    Vector2 startPos;

    [SerializeField]
    public LayerMask GroundMask;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        movement = gameObject.GetComponent<Movement>();
    }
    private void Update()
    {
        if (TouchingWall())
        {
            ReSpawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Spike"))
        {
            ReSpawn();
        }
        
    }
    bool TouchingWall()
    {
        return Physics2D.OverlapBox((Vector2)transform.position + (Vector2.right * 0.52f), Vector2.up * 0.8f + Vector2.right * 0.05f, 0, GroundMask);
    }
    
    void ReSpawn()
    {
        transform.position = startPos;
        movement.State = 0;
        gameObject.tag = "Cube";
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    
}
