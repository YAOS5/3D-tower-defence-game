using UnityEngine;
using UnityEngine.UI;

public class MoneyUIScript : MonoBehaviour {

    public Text moneyText;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        moneyText.text = "$" + PlayerStatsScript.money.ToString();
    }
}
