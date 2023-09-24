using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMove : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        //animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    public void lookfor()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
