namespace RefactoringTechniques.Refactorings
{
    // KÖTÜ TASARIM
    public class InlineMethodBad
    {
        public int GetMultiplier(int number)
        {
            return IfNumberPositive(number) ? 1 : -1;
        }

        // bu metoda gerek yok
        private static bool IfNumberPositive(int number)
        {
            return number >= 0;
        }
    }

    // İYİ TASARIM
    public class InlineMethodGood
    {
        public int GetMultiplier(int number)
        {
            return number >= 0 ? 1 : -1;
        }
    }
}
