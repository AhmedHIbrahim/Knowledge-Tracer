using UnityEngine;
using UnityEngine.UI;

public class QuestionAnswerManager : MonoBehaviour
{

    public GameObject AnswerIcons;
    public Transform playerTransform;

    AudioSource audioSource;
    public AudioClip successClip;
    public AudioClip failureClip;

    public TextAsset questions;
    public Text questionBody;
    public Text answerABody;
    public Text answerBBody;
    public Text answerCBody;
    public Text scoreBody;

    int currentIndex;
    int lastIndex = 0;
    public int zSpawn = -15;
    public int spawnLength = 30;

    int score = 0;

    [System.Serializable]
    public class Question
    {
        public string Q;
        public string A;
        public string B;
        public string C;
        public string correct_answer;
    }

    [System.Serializable]
    public class QuestionList
    {
        public Question[] questions;
    }


    public QuestionList questionList = new QuestionList();

    void Start()
    {

        audioSource = gameObject.GetComponent<AudioSource>();

        currentIndex = Random.Range(0, questionList.questions.Length);

        questionList = JsonUtility.FromJson<QuestionList>(questions.text);
        questionBody.text = questionList.questions[currentIndex].Q.ToString();
        answerABody.text = questionList.questions[currentIndex].A.ToString();
        answerBBody.text = questionList.questions[currentIndex].B.ToString();
        answerCBody.text = questionList.questions[currentIndex].C.ToString();
        SpawnAnswerIcons();

    }

    void Update()
    {
        if (lastIndex == currentIndex)
        {
            currentIndex = Random.Range(0, questionList.questions.Length);

            questionBody.text = questionList.questions[currentIndex].Q.ToString();
            answerABody.text = questionList.questions[currentIndex].A.ToString();
            answerBBody.text = questionList.questions[currentIndex].B.ToString();
            answerCBody.text = questionList.questions[currentIndex].C.ToString();
        }

        if (playerTransform.position.z - 5 > zSpawn - spawnLength)
        {
            SpawnAnswerIcons();
        }

    }

    void ValidateAnswer(string tag)
    {
        if (questionList.questions[currentIndex].correct_answer == tag)
        {
            audioSource.PlayOneShot(successClip);

            score++;
            scoreBody.text = "" + (score * 100);
            lastIndex = currentIndex;
        }
        else if (score != 0)
        {
            audioSource.PlayOneShot(failureClip);
            score--;
            scoreBody.text = "" + (score * 100);
        }
        else
        {
            audioSource.PlayOneShot(failureClip);
        }
    }
    public void SpawnAnswerIcons()
    {

        GameObject obstacle = Instantiate(AnswerIcons, transform.forward * zSpawn, transform.rotation);
        zSpawn += spawnLength;

    }

    public int GetScore()
    {
        return score * 100;
    }

}
