using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsScript : MonoBehaviour {
    public static int money;
    public int startMoney = 400;

    private void Start() {
        money = startMoney;
    }

}
