using System;
using System.Collections.Generic;

public class ScoreEntityComparer : IComparer<ScoreEntity>
{
    public int Compare(ScoreEntity x, ScoreEntity y)
    {
        if (x == null || y == null)
        {
            throw new ArgumentNullException("Cannot compare null objects");
        }

        // Compare les scores
        if (x.score == y.score)
        {
            // Si les scores sont égaux, compare par nom
            return string.Compare(x.name, y.name, StringComparison.Ordinal);
        }
        else
        {
            // Trie par score décroissant
            return y.score.CompareTo(x.score);
        }
    }
}