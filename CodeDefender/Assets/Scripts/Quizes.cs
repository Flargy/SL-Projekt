using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quizes : MonoBehaviour
{

    [SerializeField] private GameObject textField1;
    [SerializeField] private GameObject textField2;
    [SerializeField] private GameObject textField3;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject questionImage;
    [SerializeField] private GameObject answerButton;
    [SerializeField] private GameObject exitButton;
    private string answer1;
    private string answer2;
    private string answer3;
    private string playerAnswer1;
    private string playerAnswer2;
    private string playerAnswer3;

    private Text text1;
    private Text text2;
    private Text text3;
    private InputField field1;
    private InputField field2;
    private InputField field3;
    private GameObject door;
    private bool openDoor;
    private GameObject teleporter;

    private void Start()
    {
        text1 = textField1.GetComponent<Text>();
        text2 = textField2.GetComponent<Text>();
        text3 = textField3.GetComponent<Text>();
    }


    public void ActivateQuiz(string correctAnswer1, string correctAnswer2, string correctAnswer3, Sprite questionImg, GameObject door, bool open, GameObject teleport)
    {
        player.GetComponent<PlayerController>().FreezePlayer();
        answer1 = correctAnswer1;
        answer2 = correctAnswer2;
        answer3 = correctAnswer3;
        questionImage.GetComponent<Image>().sprite = questionImg;
        this.door = door;
        openDoor = open;

        textField1.transform.parent.gameObject.SetActive(true);
        textField2.transform.parent.gameObject.SetActive(true);
        textField3.transform.parent.gameObject.SetActive(true);
        questionImage.SetActive(true);
        answerButton.SetActive(true);
        exitButton.SetActive(true);
        
        if(teleport != null)
        {
            teleporter = teleport;
        }

    }

    public void CheckAnswer()
    {
        playerAnswer1 = text1.text;
        playerAnswer2 = text2.text;
        playerAnswer3 = text3.text;

        if (playerAnswer1 == answer1 && playerAnswer2 == answer2 && playerAnswer3 == answer3)
        {
            Debug.Log("whoopdiefuckingdo you did the thing");
            if(openDoor == true)
            {
                door.SetActive(false);
                if(teleporter != null)
                {
                    teleporter.SetActive(true);
                }
            }
            else
            {
                door.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Well look at you go retard");
        }
    }

    public void ExitQuiz()
    {
        player.GetComponent<PlayerController>().freezePlayer = false;
        answer1 = null;
        answer2 = null;
        answer3 = null;
        playerAnswer1 = null;
        playerAnswer2 = null;
        playerAnswer3 = null;
        teleporter = null;
        door = null;
        questionImage.GetComponent<Image>().sprite = null;

        textField1.GetComponentInParent<InputField>().text = "";
        textField2.GetComponentInParent<InputField>().text = "";
        textField3.GetComponentInParent<InputField>().text = "";
        textField1.transform.parent.gameObject.SetActive(false);
        textField2.transform.parent.gameObject.SetActive(false);
        textField3.transform.parent.gameObject.SetActive(false);
        questionImage.SetActive(false);
        answerButton.SetActive(false);
        exitButton.SetActive(false);

    }
}
