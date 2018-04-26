using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountCoins : MonoBehaviour {

    public int Coins () {
        int number = 0;

        foreach (Transform child in transform) {
            if (child.tag == "CoinCircle") {
                number++;
            }
        }
        return number;
    }
    
}
