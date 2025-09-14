using System;

namespace BaseConverterApp
{
    public static class BaseConverter
    {
        public static string Convert(string input, int inputBase, int outputBase)
        {
            int decimalValue = System.Convert.ToInt32(input, inputBase);
            return outputBase switch
            {
                2 => System.Convert.ToString(decimalValue, 2),
                10 => decimalValue.ToString(),
                16 => System.Convert.ToString(decimalValue, 16).ToUpper(),
                _ => throw new ArgumentException("Hệ cơ số không được hỗ trợ.")
            };
        }
    }

    class Program
    {
        static int SelectBase(string prompt)
        {
            Console.WriteLine($"{prompt} (1 = NHỊ PHÂN, 2 = THẬP PHÂN, 3 = THẬP LỤC PHÂN):");
            return Console.ReadLine() switch
            {
                "1" => 2,
                "2" => 10,
                "3" => 16,
                _ => throw new Exception("Lựa chọn không hợp lệ!")
            };
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                try
                {
                    Console.WriteLine("\nChọn hệ cơ số INPUT hoặc nhập 'q' để thoát:");
                    var input = Console.ReadLine();
                    if (input?.ToLower() == "q") break;

                    int inputBase = input switch
                    {
                        "1" => 2,
                        "2" => 10,
                        "3" => 16,
                        _ => throw new Exception("Lựa chọn không hợp lệ!")
                    };

                    int outputBase = SelectBase("Chọn hệ cơ số OUTPUT");

                    Console.WriteLine("Nhập giá trị cần chuyển đổi:");
                    string? value = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(value)) continue;

                    string result = BaseConverter.Convert(value, inputBase, outputBase);
                    Console.WriteLine($"=> Kết quả: {value} (hệ {inputBase}) = {result} (hệ {outputBase})");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
