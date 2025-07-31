
public static int[] TopKFrequent(int[] nums, int k)
{
    Dictionary<int, int> dict = new Dictionary<int, int>();

    for (int i = 0; i < nums.Length; i++)
    {
        if (!dict.ContainsKey(nums[i]))
        {
            dict[nums[i]] = 0;
        }

        dict[nums[i]] += 1;
    }

    List<int>[] bucket = new List<int>[nums.Length+1];

    foreach (KeyValuePair<int,int> pair in dict) 
    {
        if (bucket[pair.Value] == null)
            bucket[pair.Value] = new List<int>();

        bucket[pair.Value].Add(pair.Key);
    }

    int idx = 0;
    int[]result = new int[k];

    for(int i = bucket.Length - 1; i >= 0; i--)
    {
        if (bucket[i]!=null)
        {
            for(int j = 0; j < bucket[i].Count; j++)
            {
                if(idx!=k)
                    result[idx++] = bucket[i][j];
            }
        }

        if (idx == k)
            break;
    }

    return result;
}