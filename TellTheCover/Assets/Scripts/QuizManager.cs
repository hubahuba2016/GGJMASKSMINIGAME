using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    public TMP_Text questionText;
    public TMP_Text resultText;

    List<MaskData> masks = new List<MaskData>();
    List<Question> questions = new List<Question>();

    string correctAnswer;

    void Start()
    {
        CreateMasks();
        CreateQuestions();
        GenerateQuestion();
    }

    void CreateMasks()
    {
        masks.Add(new MaskData {
            maskName = "Blue",
            eyes = 1,
            eyeColor = "white",
            horns = 0,
            bald = true,
            fangs = true,
            noses = 0,
            mouths = 0
        });

        masks.Add(new MaskData {
            maskName = "Green",
            eyes = 2,
            eyeColor = "white",
            horns = 2,
            bald = false,
            fangs = false,
            noses = 1,
            mouths = 3
        });

        masks.Add(new MaskData {
            maskName = "Red",
            eyes = 3,
            eyeColor = "yellow",
            horns = 3,
            bald = false,
            fangs = false,
            noses = 0,
            mouths = 0
        });
    }

    void CreateQuestions()
    {
        questions.Add(new Question {
            text = "Which mask has 3 horns?",
            condition = m => m.horns == 3
        });

        questions.Add(new Question {
            text = "Which mask has white fangs?",
            condition = m => m.fangs
        });

        questions.Add(new Question {
            text = "Which mask has 3 mouths?",
            condition = m => m.mouths == 3
        });

        questions.Add(new Question {
            text = "Which mask has yellow eyes?",
            condition = m => m.eyeColor == "yellow"
        });

        // Trick question
        questions.Add(new Question {
            text = "Which mask has 4 eyes?",
            condition = m => m.eyes == 4
        });
    }

   void GenerateQuestion()
    {

        Question q;
        List<MaskData> matches;

        do
        {
            q = questions[Random.Range(0, questions.Count)];
            matches = masks.FindAll(m => q.condition(m));
        }
        while (matches.Count > 1);

        questionText.text = q.text;

        if (matches.Count == 0)
            correctAnswer = "Nothing";
        else
            correctAnswer = matches[0].maskName;
    }

    public void Answer(string answer)
    {
        if (answer == correctAnswer)
            resultText.text = "Correct!";
        else
            resultText.text = "Wrong!";

        Invoke(nameof(GenerateQuestion), 1.2f);
    }
}
