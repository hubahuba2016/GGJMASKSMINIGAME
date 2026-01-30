[System.Serializable]
public class Question
{
    public string text;
    public System.Func<MaskData, bool> condition;
}
