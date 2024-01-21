using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesScroller : MonoBehaviour
{


    public float tempo = 180;
    public bool hasStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        hasStarted = true;
        tempo = tempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(tempo * Time.deltaTime, 0f, 0f);
    }
}
