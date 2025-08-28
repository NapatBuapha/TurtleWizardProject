using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncreasedPopup : MonoBehaviour
{
    [SerializeField] int closedCount = 3;
    private void OnEnable()
    {
        Invoke("ClosePopUp", closedCount);
    }

    private void ClosePopUp()
    {
        gameObject.SetActive(false);
    }
    

    
    


}
