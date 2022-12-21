using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;


public class Question : MonoBehaviour
{
    public Text Firstnum, Secondnum, Operators;

    public List<Button> Options = new List<Button>();

    Button trueButton;
    int n1, n2, opertr, result;
    List<int> numbers = new List<int>() { 0,0,0};

    bool isFire = false;


    public static bool IsFinish;

    public CharacterMovement character;

    public AudioSource theme;



    public void SetMusic(bool isPlaying)
    {
        theme.mute = !isPlaying;
    }

    private void Start()
    {
      
        trueButton = Options[0];
        Questions();
        
    }

 


    IEnumerator DelayCo(int time)
    {
        yield return new WaitForSeconds(time);
        isFire = false;
        Questions();
    }

    public void Answer(int i)
    {
        if (int.Parse(Options[i].GetComponentInChildren<Text>().text) != result)
        {
            character.CharacterHurt();
            return;
        }
        if (isFire) return;
        character.CharacterAttack();
        isFire = true;
        StartCoroutine(DelayCo(4));
        
    }



    public void Questions()
    {
        // for questions

        n1 = UnityEngine.Random.Range(5, 10);
        n2 = UnityEngine.Random.Range(3, 10);

        opertr = UnityEngine.Random.Range(1, 5);


        switch (opertr)
        {
            case 1:
                Operators.text = "+";
                result = n1 + n2;
                break;
            case 2:
                if (n1 > n2)
                {
                    Operators.text = "-";
                    result = n1 - n2;

                }
                else
                {
                    int temp = n1;
                    n1 = n2;
                    n2 = temp;
                    Operators.text = "-";
                    result = n1 - n2;
                }
                break;
            case 3:
                Operators.text = "x";
                result = n1 * n2;
                break;
            case 4:
                if (n1 % n2 == 0 && n1 >= n2)
                {
                    Operators.text = "/";
                    result = n1 / n2;

                }
                else
                {
                    Operators.text = "x";
                    result = n1 * n2;
                }
                break;
        }

        Firstnum.text = n1 + "";
        Secondnum.text = n2 + "";

        //for answers

        for (int i = 0; i < 3; i++)
        {
            bool isFinish = false;
            while (!isFinish)
            {
                int tempNumber = Random.Range(0, 100);
                if (!numbers.Contains(tempNumber))
                {
                    if (tempNumber == result)
                        return;
                    numbers[i]= tempNumber;
                    isFinish = true;

                }
            }
            Options[i].GetComponentInChildren<Text>().text = numbers[i].ToString();
        }

        int num = Random.Range(0, 3);
        Debug.Log(num);
        numbers[num] = result;
        Options[num].GetComponentInChildren<Text>().text = numbers[num].ToString();
        trueButton = Options[num];

    }


}
