using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Addition : MonoBehaviour
{
    private const int InitialSeed = 1;

    private const string Sign = " + ";

    private const int TimerToStart = 3;
    private const int QuestionAnswerTime = 10;
    public int minNumber1;
    public int maxNumber1;
    public int minNumber2;
    public int maxNumber2;

    public Text timerText;
    public Text questionText;
    public Text result1;
    public Text result2;
    public Text result3;

    public Text result4;
    //   public Button button;

    private IEnumerator _coroutine;

    private int _timeCount;

    //  Button.FindObjectOfType<Text>().text = "hi";
    //  Button.FindObjectOfType<Image>().color = new Color(0.1529412f, 0.4117647f, 0.1647059f,1.0f);


    private IEnumerator Start()
    {
        Random.InitState(InitialSeed);
        InvokeRepeating(nameof(CountDownStartTimer), 0, 1);
        yield return new WaitForSeconds(TimerToStart);
        _coroutine = PlayMethod(QuestionAnswerTime);
        StartCoroutine(_coroutine);
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        StopCoroutine(_coroutine);
    }


    private void CountDownStartTimer()
    {
        timerText.text = (TimerToStart - _timeCount).ToString();
        if (_timeCount == TimerToStart)
        {
            CancelInvoke(nameof(CountDownStartTimer));
            timerText.text = "";
        }

        _timeCount++;
    }

    private IEnumerator PlayMethod(float waitTime)
    {
        while (true)
        {
            GenerateRandomQuestion();
            yield return new WaitForSeconds(waitTime);
        }

        // ReSharper disable once IteratorNeverReturns
    }

    private void GenerateRandomQuestion()
    {
        var num1 = Random.Range(minNumber1, maxNumber1);
        var num2 = Random.Range(minNumber2, maxNumber2);
        var total = num1 + num2;
        questionText.text = num1 + Sign + num2 + " = ??";
        var switchText = Random.Range(1, 5);
        ParsingAdditionResult(switchText, total);
    }


    private void ParsingAdditionResult(int textNum, int answer)
    {
        switch (textNum)
        {
            case 1:
                result1.text = answer.ToString();
                result2.text = (answer + Random.Range(1, 4)).ToString();
                result3.text = (answer + Random.Range(5, 8)).ToString();
                result4.text = (answer + Random.Range(9, 12)).ToString();
                break;
            case 2:
                result1.text = (answer + Random.Range(1, 4)).ToString();
                result2.text = answer.ToString();
                result3.text = (answer + Random.Range(5, 8)).ToString();
                result4.text = (answer + Random.Range(9, 12)).ToString();
                break;

            case 3:
                result1.text = (answer + Random.Range(1, 4)).ToString();
                result2.text = (answer + Random.Range(5, 8)).ToString();
                result3.text = answer.ToString();
                result4.text = (answer + Random.Range(9, 12)).ToString();
                break;

            case 4:
                result1.text = (answer + Random.Range(1, 4)).ToString();
                result2.text = (answer + Random.Range(5, 8)).ToString();
                result3.text = (answer + Random.Range(9, 12)).ToString();
                result4.text = answer.ToString();
                break;

            default:
                Debug.Log(textNum);
                break;
        }
    }
}