using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public float moveSpeed = 5.0f;
    public GameObject frown;
    public GameObject smile;
    private List<GameObject> shape;
    private GameObject coloredShape;
    public List<GameObject> targetShape;
    private bool isCompleted;

    public AudioSource soundsEffect;
    public GameObject Congrats;

    void Awake()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        shape = new List<GameObject>();
        isCompleted = false;
    }

    void Update()
    {

    }


    void FixedUpdate()
    {
        if(!isCompleted)
        {
            Move();
        }
        
        
    }

    /// <summary>
    /// Player move method
    /// </summary>
    private void Move()
    {
        //Get value from input manager
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float vereticallMove = Input.GetAxisRaw("Vertical");
        //playerRigidBody.velocity = new Vector2(horizontalmove * moveSpeed, playerRigidBody.velocity.y);
        Vector2 position = transform.position;
        position.x += horizontalMove * moveSpeed * Time.deltaTime;
        position.y += vereticallMove * moveSpeed * Time.deltaTime;
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shape")
        {
            soundsEffect.Play();
            frown.SetActive(false);
            smile.SetActive(true);
            coloredShape = other.GetComponent<Shape>().activeShape;
            shape.Insert(0, Instantiate(coloredShape, gameObject.transform));
            shape[0].transform.parent = gameObject.transform.Find("Shapes").transform;
            shape[0].SetActive(true);
            shape[0].transform.localScale = new Vector3(1, 1, 1);
            shape[0].transform.name = coloredShape.name;

            for(int i = 0; i < shape.Count; i++)
            {
                shape[i].transform.localPosition = new Vector3(shape[i].transform.localPosition.x, shape[i].transform.localPosition.y, i);
            }

            if (shape.Count == targetShape.Count)
            {
                for (int i = 0; i < targetShape.Count; i ++)
                {
                    if (shape[i].transform.name != targetShape[i].transform.name)
                    {
                        break;
                    }
                    else if(shape[i].transform.name == targetShape[i].transform.name && i == (targetShape.Count-1))
                    {
                        
                        isCompleted = true;
                        Congrats.SetActive(true);
                        GameManager.Instance.Congrats();
   
                        Debug.Log("Congrats!");
                    }
                }
            }
            
            

            switch (other.transform.name)
            {
                case "Circle":
                    Debug.Log("Ciclre!");
                    break;
                case "Star":
                    Debug.Log("Star!");
                    break;
                case "Triangle":
                    Debug.Log("Triangle!");
                    break;
                case "Square":
                    Debug.Log("Square!");
                    break;
            }

        }
    }
}
