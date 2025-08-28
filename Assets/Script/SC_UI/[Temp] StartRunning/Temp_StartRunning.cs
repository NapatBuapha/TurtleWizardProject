using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Temp_StartRunning : MonoBehaviour
{
    public UnityEvent startRunning;
    void Start()
    {
        startRunning.AddListener(GameObject.Find("Player").GetComponent<PlayerStateManager>().StartRunning);
        startRunning.AddListener(GameObject.Find("Player").GetComponent<PlayerHP>().StartRunning);
        startRunning.AddListener(GameObject.Find("SpeedManager").GetComponent<SpeedManager>().StartRunning);
    }
    
        public void StartRunning()
    {
        startRunning.Invoke();
    }

}
