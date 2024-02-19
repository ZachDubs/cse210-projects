using System;
using System.Runtime.CompilerServices;


public class Scripture
{
    private string _reference;
    private string _scriptureText;
    private string _exitText = "Press enter to continue or type 'quit' to finish: ";

    public Scripture(string scriptureReference, string scriptureText)
    {
        _reference = scriptureReference;
        _scriptureText = scriptureText;

        List<string> wordList = scriptureText.Split(' ').ToList(); 
    }

    public string GetOutput()
    {
        Console.Clear();
        string text = $"{_reference} {_scriptureText}\n\n{_exitText}";
        Console.Write(text);
        Console.ReadLine();
        Console.Clear();
        return text;
    }

}

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public string GetSingleReference()
    {

        string singleReferenceText = $"{_book} {_chapter}:{_verse}";
        return singleReferenceText;
    }

    public string GetMultipleReference()
    {
        string multipleReferenceText = $"{_book} {_chapter}:{_verse}-{_endVerse}";
        return multipleReferenceText;
    }
}

public class Words
{
    private List<string> _wordsToShow;
    private List<string> _wordsToHide;
}