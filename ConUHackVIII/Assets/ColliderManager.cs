using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{

    [SerializeField] string zombieTag;
    public bool canBeShot = false;
    public GameObject currentZombie;
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
        if(other != null && other.tag == zombieTag ) 
        {
            currentZombie = other.gameObject;
            canBeShot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == zombieTag) 
        {
            currentZombie = null;
            canBeShot = false;
        }
    }
}
