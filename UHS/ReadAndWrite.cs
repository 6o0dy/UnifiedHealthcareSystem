using System.Text.Json;

namespace UnifiedHealthcareSystem
{
    //هذا الكلاس خاص بقراءة وكتابة ملفات جيسون
    class Read_Write
    {
        /* كل الملفات بتتخزن جنب ملف التشغيل نفسه (BaseDirectory) بدل ما تعتمد علي مكان فتح البرنامج */
        public static string ResolvePath(string FileName)
        {
            return Path.Combine(AppContext.BaseDirectory, Path.GetFileName(FileName));
        }

        /* بيحول الكائن الي نص جيسون ويكتبه في ملف مؤقت الاول ثم يستبدل الملف الاصلي
         * عشان لو البرنامج اتقفل في نص الكتابة الملف القديم ما يتلفش */
        public static void WriteInFile(string FileName, object Data)
        {
            string path = ResolvePath(FileName);
            string updatedJson = JsonSerializer.Serialize(Data, new JsonSerializerOptions { WriteIndented = true });

            string tempPath = path + ".tmp";
            File.WriteAllText(tempPath, updatedJson);
            File.Move(tempPath, path, true);
        }

        /* بترجع محتوي الملف لو موجود، ولو مش موجود بترجع null */
        public static string? ReadFromFile(string FileName)
        {
            string path = ResolvePath(FileName);
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            return null;
        }
    }
}
