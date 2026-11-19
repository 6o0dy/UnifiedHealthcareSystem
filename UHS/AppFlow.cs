namespace UnifiedHealthcareSystem
{
    // مسؤول عن قرار إغلاق البرنامج: بيقفل لما الفورم اللي بيتقفل يكون آخر فورم ظاهر
    // (فورم الافتتاح Form1 بتفضل مخفية فمش بتتحسب)
    internal static class AppFlow
    {
        public static bool IsLastVisibleForm(Form current)
        {
            return !Application.OpenForms.OfType<Form>().Any(f => f != current && f.Visible);
        }
    }
}
