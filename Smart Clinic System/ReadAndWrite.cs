using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UnifiedHealthcareSystem
{
    //هذا الكلاس خاص بإنشاء حساب جديد للدكاترة وتخزينه في ملف جيسون
    class Read_Write
    {
        /* هذا الميثود يقوم بكتابة البيانات في ملف جيسون من خلال تحويل الكائن الي نص جيسون باستخدام JsonSerializer ثم كتابة النص في الملف باستخدام File.WriteAllText */
        public static void WriteInFile(string FileName, object Data)
        {
            string updatedJson = JsonSerializer.Serialize(Data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FileName, updatedJson);
        }

        /* هذا الميثود يقوم بقراءة البيانات من ملف جيسون من خلال التحقق من وجود الملف باستخدام File.Exists
         * ثم قراءة النص من الملف باستخدام File.ReadAllText */
        public static string ReadFromFile(string FileName)
        {
            if (File.Exists(FileName))
            {
                string data = File.ReadAllText(FileName);
                return data;
            }
            return null;
        }
    }
}