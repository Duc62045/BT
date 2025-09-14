using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StudentApp
{
    public enum CourseName
    {
        Java = 1,
        DotNet = 2,   // .Net
        CCPP = 3      // C/C++
    }

    public class Student
    {
        public string Name { get; set; } = "";
        public int Semester { get; set; }
        public CourseName Course { get; set; }

        public override string ToString()
        {
            return Name.PadRight(25) + " | Sem: " + Semester.ToString().PadRight(2) + " | Course: " + CourseToText(Course);
        }

        public static string CourseToText(CourseName c)
        {
            if (c == CourseName.Java) return "Java";
            if (c == CourseName.DotNet) return ".Net";
            if (c == CourseName.CCPP) return "C/C++";
            return "Unknown";
        }                   

        public static bool TryParseCourse(string s, out CourseName c)
        {
            s = (s ?? "").Trim().ToLowerInvariant();
            // Cho phép nhiều biến thể người dùng ghi trong file
            if (s is "java") { c = CourseName.Java; return true; }
            if (s is ".net" or "dotnet" or "net" or "c#/.net" or "csharp/.net") { c = CourseName.DotNet; return true; }
            if (s is "c/c++" or "c++" or "c" or "ccpp" or "c-cpp") { c = CourseName.CCPP; return true; }

            c = default;
            return false;
        }
    }

    public class ClassSubject
    {
        public List<Student> StudentList { get; private set; } = new();
        public string FileName { get; private set; }
        private readonly Dictionary<string, int> _report = new(StringComparer.InvariantCultureIgnoreCase);

        public ClassSubject(string fileName = "TextFile1.txt")
        {
            FileName = fileName;
        }

        public void ReadFile()
        {
            StudentList.Clear();

            if (!File.Exists(FileName))
                throw new FileNotFoundException($"Không tìm thấy tệp: {FileName}");

            using var fr = new StreamReader(FileName, Encoding.UTF8);
            int lineNo = 0;

            while (!fr.EndOfStream)
            {
                string? line = fr.ReadLine();
                lineNo++;
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(',');
                if (parts.Length < 3)
                    throw new FormatException($"Dòng {lineNo}: Không đúng định dạng 'Name,Course,Semester'.");

                string name = parts[0].Trim();
                string courseText = parts[1].Trim();
                string semText = parts[2].Trim();

                if (!Student.TryParseCourse(courseText, out var course))
                    throw new FormatException($"Dòng {lineNo}: Course không hợp lệ: '{courseText}'. (Chỉ Java / .Net / C/C++)");

                if (!int.TryParse(semText, out int sem) || sem < 1)
                    throw new FormatException($"Dòng {lineNo}: Semester phải là số nguyên >= 1.");

                StudentList.Add(new Student
                {
                    Name = name,
                    Semester = sem,
                    Course = course
                });
            }
        }

        public void SaveFile()
        {
            using var fw = new StreamWriter(FileName, false, Encoding.UTF8);
            foreach (var s in StudentList)
                fw.WriteLine($"{s.Name},{Student.CourseToText(s.Course)},{s.Semester}");
        }

        public List<Student> FindByName(string keyword)
        {
            keyword = (keyword ?? "").Trim();
            if (keyword.Length == 0) return new List<Student>();
            return StudentList
                .Where(s => s.Name.Contains(keyword, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }

        public bool UpdateAt(int index, string? newName, int? newSemester, CourseName? newCourse)
        {
            if (index < 0 || index >= StudentList.Count) return false;
            var s = StudentList[index];

            if (!string.IsNullOrWhiteSpace(newName)) s.Name = newName.Trim();
            if (newSemester.HasValue && newSemester.Value >= 1) s.Semester = newSemester.Value;
            if (newCourse.HasValue) s.Course = newCourse.Value;
            return true;
        }

        public bool DeleteAt(int index)
        {
            if (index < 0 || index >= StudentList.Count) return false;
            StudentList.RemoveAt(index);
            return true;
        }

        public void GenerateReport()
        {
            _report.Clear();
            foreach (var s in StudentList)
            {
                string key = $"{s.Name} | {Student.CourseToText(s.Course)}";
                _report[key] = _report.TryGetValue(key, out int c) ? c + 1 : 1;
            }
        }

        public void PrintReportTable()
        {
            Console.WriteLine("\nStudent Name                 | Course  | Total of Course");
            Console.WriteLine(new string('-', 60));

            foreach (var kv in _report.OrderBy(k => k.Key, StringComparer.InvariantCulture))
            {
                var parts = kv.Key.Split('|');
                string name = parts[0].Trim();
                string course = parts.Length > 1 ? parts[1].Trim() : "";
                Console.WriteLine($"{name,-28} | {course,-6} | {kv.Value,5}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var app = new ClassSubject("TextFile1.txt");

            while (true)
            {
                try
                {
                    ShowMenu();
                    Console.Write("Chọn chức năng: ");
                    string? op = Console.ReadLine()?.Trim();

                    switch (op)
                    {
                        case "1":
                            app.ReadFile();
                            Console.WriteLine("Đã đọc danh sách sinh viên từ file.");
                            break;

                        case "2":
                            Console.Write("Nhập tên cần tìm: ");
                            var kw = Console.ReadLine() ?? "";
                            var found = app.FindByName(kw);
                            if (found.Count == 0) Console.WriteLine("Không tìm thấy.");
                            else
                            {
                                Console.WriteLine("\nKết quả tìm kiếm:");
                                for (int i = 0; i < found.Count; i++)
                                    Console.WriteLine($"[{i}] {found[i]}");
                            }
                            break;

                        case "3": 
                            if (!EnsureLoaded(app)) break;
                            PrintAll(app);
                            Console.Write("Nhập index cần sửa: ");
                            if (!int.TryParse(Console.ReadLine(), out int idxU))
                            {
                                Console.WriteLine("Index không hợp lệ.");
                                break;
                            }

                            Console.Write("Tên mới (bỏ trống nếu giữ nguyên): ");
                            string? newName = Console.ReadLine();

                            Console.Write("Semester mới (>=1, bỏ trống nếu giữ nguyên): ");
                            string? semText = Console.ReadLine();
                            int? newSem = null;
                            if (!string.IsNullOrWhiteSpace(semText))
                            {
                                if (int.TryParse(semText, out int semVal) && semVal >= 1)
                                    newSem = semVal;
                                else
                                {
                                    Console.WriteLine("Semester không hợp lệ, bỏ qua thay đổi Semester.");
                                }
                            }

                            Console.Write("Course mới (Java/.Net/C/C++), bỏ trống nếu giữ nguyên: ");
                            string? courseText = Console.ReadLine();
                            CourseName? newCourse = null;
                            if (!string.IsNullOrWhiteSpace(courseText))
                            {
                                if (Student.TryParseCourse(courseText, out var c))
                                    newCourse = c;
                                else
                                    Console.WriteLine("Course không hợp lệ, bỏ qua thay đổi Course.");
                            }

                            if (app.UpdateAt(idxU, newName, newSem, newCourse))
                            {
                                app.SaveFile();
                                Console.WriteLine("Đã cập nhật & lưu file.");
                            }
                            else Console.WriteLine("Sửa thất bại (index không hợp lệ).");
                            break;

                        case "4": 
                            if (!EnsureLoaded(app)) break;
                            PrintAll(app);
                            Console.Write("Nhập index cần xoá: ");
                            if (!int.TryParse(Console.ReadLine(), out int idxD))
                            {
                                Console.WriteLine("Index không hợp lệ.");
                                break;
                            }
                            if (app.DeleteAt(idxD))
                            {
                                app.SaveFile();
                                Console.WriteLine("Đã xoá & lưu file.");
                            }
                            else Console.WriteLine("Xoá thất bại (index không hợp lệ).");
                            break;

                        case "5": 
                            if (!EnsureLoaded(app)) break;
                            app.GenerateReport();
                            app.PrintReportTable();
                            break;

                        case "6":
                            if (!EnsureLoaded(app)) break;
                            PrintAll(app);
                            break;

                        case "0":
                        case "q":
                        case "Q":
                            return;

                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("1) Đọc danh sách từ tệp");
            Console.WriteLine("2) Tìm kiếm theo tên");
            Console.WriteLine("3) Sửa thông tin theo index");
            Console.WriteLine("4) Xoá theo index");
            Console.WriteLine("5) Thống kê số lần đăng ký (Student Name | Course | Total of Course)");
            Console.WriteLine("6) Hiển thị toàn bộ danh sách");
            Console.WriteLine("0) Thoát");
        }

        static bool EnsureLoaded(ClassSubject app)
        {
            if (app.StudentList.Count == 0)
            {
                Console.WriteLine("Danh sách rỗng. Hãy chọn 1) để đọc từ file trước.");
                return false;
            }
            return true;
        }

        static void PrintAll(ClassSubject app)
        {
            Console.WriteLine("\nDanh sách sinh viên (theo index trong bộ nhớ):");
            for (int i = 0; i < app.StudentList.Count; i++)
                Console.WriteLine($"[{i}] {app.StudentList[i]}");
        }
    }
}
