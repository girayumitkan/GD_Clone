using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMode : MonoBehaviour
{
    Movement movement;
    GameObject Cube;
    GameObject Ship;
    void OnTriggerEnter2D(Collider2D collision)
    {
        movement = collision.gameObject.GetComponent<Movement>();
        if (collision.gameObject.CompareTag("Cube") && !collision.gameObject.CompareTag("Finish"))
        {          
            movement.ChangeThroughPortal(1, 1);
            collision.gameObject.transform.GetChild(0).rotation = Quaternion.Euler(new Vector3(0,0,0));
            collision.gameObject.tag = "Ship";
            collision.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            

        }
        else if (collision.gameObject.CompareTag("Ship"))
        {         
            movement.ChangeThroughPortal(1, 0);
            collision.gameObject.tag = "Cube";
            collision.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {         
            Debug.Log("Bitti");
            SceneManager.LoadScene("final");
        }
    }
    }

