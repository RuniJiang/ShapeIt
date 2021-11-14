using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    AudioSource start;
    public GameObject Info;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
        start = GameObject.Find("StartCredit").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        start.Play();
        Info.SetActive(true);
    }

    public void Close()
    {
        Info.SetActive(false);
    }
}
