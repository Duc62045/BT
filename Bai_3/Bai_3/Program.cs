using System;
using System.Collections.Generic;

class Program
{
    static string NormalizeSpaces(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return string.Empty;
        s = s.Trim();
        var result = "";
        bool inSpace = false;
        foreach (char c in s)
        {
            if (char.IsWhiteSpace(c))
            {
                if (!inSpace)
                {
                    result += ' ';
                    inSpace = true;
                }
            }
            else
            {
                result += c;
                inSpace = false;
            }
        }
        return result;
    }

    static string SentenceCase(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        s = NormalizeSpaces(s);

        char[] arr = s.ToCharArray();
        bool newSentence = true;
        for (int i = 0; i < arr.Length; i++)
        {
            if (newSentence && char.IsLetter(arr[i]))
            {
                arr[i] = char.ToUpper(arr[i]);
                newSentence = false;
            }
            if (arr[i] == '.' || arr[i] == '!' || arr[i] == '?')
                newSentence = true;
            else if (!char.IsWhiteSpace(arr[i]) && arr[i] != '.' && arr[i] != '!' && arr[i] != '?')
                newSentence = false;
        }
        return new string(arr);
    }

    static List<string> TokenizeWords(string s)
    {
        var words = new List<string>();
        if (string.IsNullOrWhiteSpace(s)) return words;
        int i = 0, n = s.Length;
        while (i < n)
        {
            while (i < n && !char.IsLetterOrDigit(s[i])) i++;
            int start = i;
            while (i < n && (char.IsLetterOrDigit(s[i]) || (s[i] == '\'' && i + 1 < n && char.IsLetter(s[i + 1]))))
                i++;
            if (start < i)
                words.Add(s.Substring(start, i - start));
        }
        return words;
    }

    static Dictionary<string, int> CountFreq(List<string> words)
    {
        var dict = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
        foreach (var w in words)
        {
            var k = w.ToLowerInvariant();
            dict[k] = dict.ContainsKey(k) ? dict[k] + 1 : 1;
        }
        return dict;
    }

    static string Pad(string s, int width)
    {
        s ??= "";
        return s.Length >= width ? s.Substring(0, width) : s + new string(' ', width - s.Length);
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Nhập đoạn văn bản (Enter dòng trống để kết thúc nhập):");

        var lines = new List<string>();
        while (true)
        {
            string? line = Console.ReadLine();
            if (string.IsNullOrEmpty(line)) break;
            lines.Add(line);
        }
        string input = string.Join(" ", lines);

        string normalized = NormalizeSpaces(input);
        string processed = SentenceCase(normalized);

        var words = TokenizeWords(processed);
        int total = words.Count;
        var freq = CountFreq(words);
        int distinct = freq.Count;

        Console.WriteLine();
        Console.WriteLine("---- Văn bản đã chuẩn hóa ----");
        Console.WriteLine(processed);

        Console.WriteLine();
        Console.WriteLine("---- Thống kê ----");
        Console.WriteLine($"Tổng số từ: {total}");
        Console.WriteLine($"Số từ khác nhau: {distinct}");

        Console.WriteLine();
        Console.WriteLine("---- Bảng tần suất (không phân biệt hoa/thường) ----");
        const int col1 = 24;
        Console.WriteLine($"{Pad("Từ", col1)} | Số lần");
        Console.WriteLine(new string('-', col1 + 10));

        // Không dùng LINQ, tự sắp xếp
        var freqList = new List<KeyValuePair<string, int>>(freq);
        freqList.Sort((a, b) =>
        {
            int cmp = b.Value.CompareTo(a.Value);
            if (cmp != 0) return cmp;
            return string.Compare(a.Key, b.Key, StringComparison.InvariantCulture);
        });

        foreach (var kv in freqList)
            Console.WriteLine($"{Pad(kv.Key, col1)} | {kv.Value,6}");

        Console.WriteLine();
        Console.WriteLine("Hoàn tất. Nhấn Enter để thoát.");
        Console.ReadLine();
    }
}
