using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectMoney : MonoBehaviour
{
    public Text coinText;
    private int coinAmount;
    private void Start()
    {
        coinText.text = coinAmount.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            coinAmount += 1;
            coinText.text = coinAmount.ToString();
        }
    }
    public void multiplyCoinAmount(int multiplier)

    {
        coinAmount = coinAmount * multiplier;
        coinText.text = coinAmount.ToString();
    }
}
