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

