using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEntity
{
    public string name;
    public int score;

    public ScoreEntity(string name, int score)
    {
        this.name = name;
        this.score = score;
    }

    // De la forme name;score
    public ScoreEntity(string nameAndScore, string separator)
    {
        string[] nameScoreSplit = nameAndScore.Split(separator);
        this.name = nameScoreSplit[0];
        this.score = int.Parse(nameScoreSplit[1]);
    }

    public override string ToString()
    {
        return name + " : " + score;
    }

    public string getCSVFormat(string separator)
    {
        return name + separator + score;
    }

    // 0 : equal, 1 this > other, -1 this < other
    public int compare(ScoreEntity other)
    {
        if(score == other.score)
        {
            return 0;
        }
        else if(score < other.score)
        {
            return -1;
        }

        return 1;
    }
}
