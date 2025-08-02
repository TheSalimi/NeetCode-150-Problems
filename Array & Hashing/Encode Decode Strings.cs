/*
Problem Statement:
Design an algorithm to encode a list of strings into a single string.
The encoded string should be able to be sent over the network and later 
decoded back into the original list of strings.  
*/

public class Codec
{
    // Encodes a list of strings to a single string.
    public string Encode(IList<string> strs)
    {
        string encrypted = "";
        foreach (string str in strs) { 
            encrypted += $"{str.Length}:{str}";
        }
        return encrypted;
    }

    // Decodes a single string to a list of strings.
    public IList<string> Decode(string s)
    {
        List<string> words = new List<string> ();
        
        int i = 0;

        while(i < s.Length)
        {
            int j = i;

            while (s[j] != ':') j++;

            int length = int.Parse(s.Substring(i, j - i));

            string word = s.Substring(j + 1, length);

            words.Add (word);

            i = j + 1 + length;
        }

        return words;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        var codec = new Codec();

        var originalList = new List<string> { "lint", "code", "love", "you" };

        var encoded = codec.Encode(originalList);
        Console.WriteLine("Encoded: " + encoded);

        var decoded = codec.Decode(encoded);
        Console.WriteLine("Decoded:");
        foreach (var str in decoded)
        {
            Console.WriteLine(str);
        }
    }
}
