using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckDragNDropAnswer : MonoBehaviour
{

    public Slider[] dragNdropReducedSliders;
    public GameObject[] dragNdDropComponentsToActivate;

    public AudioSource rightAnswerAudio;
    public AudioSource wrongAnswerAudio;


    private string correctAnswer;
    private string enteredAnswer;

    public void ClickToCheckAnswer()
    {
        Debug.Log("Button Clicked!");

        correctAnswer = FractionSelect.answerToBeChecked;
        enteredAnswer = FractionIdentificator.enteredAnswer;

        Debug.Log("Correct answer is: " + correctAnswer);
        Debug.Log("Entered answer is: " + enteredAnswer);

        if (correctAnswer == enteredAnswer)
        {
            rightAnswerAudio.Play();

            Debug.Log("Answer is Correct!");

            foreach (GameObject i in dragNdDropComponentsToActivate)
                i.SetActive(false);

            foreach (Slider i in dragNdropReducedSliders)
                i.gameObject.SetActive(false);

            DataBaseManager.writeSuccess(UserClass.player.givenFraction, UserClass.player.enteredFraction, UserClass.player.enteredRFraction, enteredAnswer, 1);
        }

        else
        {
            wrongAnswerAudio.Play();
            Debug.Log("Answer is not correct!");
            DataBaseManager.writeSuccess(UserClass.player.givenFraction, UserClass.player.enteredFraction, UserClass.player.enteredRFraction, enteredAnswer, 0);
        }
    }
}
