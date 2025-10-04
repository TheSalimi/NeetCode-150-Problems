/*
Given an array of strings strs, group the anagrams together. An anagram is a word or phrase formed by rearranging the letters of a different word or phrase, using all the original letters exactly once.

Return the result as a list of lists, where each inner list contains strings that are anagrams of each other. The order of the output does not matter.
*/

public static IList<IList<string>> GroupAnagrams(string[] strs)
{
    Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
    for (int i = 0; i < strs.Length; i++)
    {
        int[] temp = new int[26];

        for (int j = 0; j < strs[i].Length; j++)
        {
            temp[strs[i][j] - 97] += 1;
        }

        string key = string.Join(",", temp);

        if (dict.ContainsKey(key))
            dict[key].Add(strs[i]);
        else
        {
            dict.Add(key, new List<string>());
            dict[key].Add(strs[i]);
        }
    }

    return dict.Values.Select(x => (IList<string>)x).ToList();
}

