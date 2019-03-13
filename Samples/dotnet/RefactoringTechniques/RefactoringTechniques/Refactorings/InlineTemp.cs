namespace RefactoringTechniques.Refactorings
{
    // KÖTÜ TASARIM
    public class InlineTempBad
    {
       public int CalculateVolume(int l, int w, int h)
       {
           var volume = l * w * h;

           return volume;
       }
    }

    // İYİ TASARIM
    public class InlineTempGood
    {
        public int CalculateVolume(int l, int w, int h)
        {
            return l * w * h;
        }
    }
}
