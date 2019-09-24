using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizTrigger : MonoBehaviour
{
    [SerializeField] private GameObject quizHandeler;
    [SerializeField] private string answer1;
    [SerializeField] private string answer2;
    [SerializeField] private string answer3;
    [SerializeField] private Sprite picture;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            quizHandeler.GetComponent<Quizes>().ActivateQuiz(answer1, answer2, answer3, picture);
        }
    }

}
