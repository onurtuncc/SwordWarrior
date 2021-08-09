using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldText : MonoBehaviour
{
    [SerializeField] public Text text;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 textPose= Camera.main.WorldToScreenPoint(this.transform.position);
        text.transform.position = textPose;
    }
}
