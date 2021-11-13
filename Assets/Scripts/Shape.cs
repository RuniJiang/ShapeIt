using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public List<GameObject> shapeType;
    public GameObject activeShape;
    private int rng;

    private void Awake()
    {
        rng = Random.Range(0, 5);
        activeShape = shapeType[rng];
        shapeType[rng].SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            shapeType[rng].SetActive(false);
            rng = Random.Range(0, 5);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            rng = Random.Range(0, 5);
            activeShape = shapeType[rng];
            shapeType[rng].SetActive(true);
        }
    }
}
