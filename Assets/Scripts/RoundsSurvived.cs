using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    // Start is called before the first frame update
    public Text roundsText;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    // Copied for prettier animation of text
    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(.7f);

        while (round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(.05f);
        }

    }

}
