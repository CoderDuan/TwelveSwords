using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour {

    public int diceValue;

    public GameObject num1;
    public GameObject num2;
    public GameObject num3;
    public GameObject num4;
    public GameObject num5;
    public GameObject num6;

    public void setVisualDice()
    {
        StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            num1.SetActive(false);
            num2.SetActive(false);
            num3.SetActive(false);
            num4.SetActive(false);
            num5.SetActive(false);
            num6.SetActive(false);

            if (diceValue == 1) num1.SetActive(true);
            else if (diceValue == 2) num2.SetActive(true);
            else if (diceValue == 3) num3.SetActive(true);
            else if (diceValue == 4) num4.SetActive(true);
            else if (diceValue == 5) num5.SetActive(true);
            else if (diceValue == 6) num6.SetActive(true);
            else num1.SetActive(true);

            GameObject.Find("ControllerObj").GetComponent<Controller>().AsyncUpdateState();
        }, 0.2f));
    }
}
