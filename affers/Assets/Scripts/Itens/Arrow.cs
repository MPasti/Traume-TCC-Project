using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{

    public Text ArrowText;
    public int ArrowAmount;

    public static Arrow Instance;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        ArrowText.text = "x " + ArrowAmount.ToString();
    }

    public void SubItems(int subItemAmount)
    {
        ArrowAmount += subItemAmount;
        ArrowText.text = "x " + ArrowAmount.ToString();
    }
  

  
}
