using System;

namespace RefactoringTechniques.Refactorings
{
    // KÖTÜ TASARIM
    public class ExtractMethodBad
    {
        public void DoSomeThing()
        {
            // diğer kod blokları...

            // kullanıcı bilgilerini ekrana bas
            Console.WriteLine("Kullanıcı adı: ali_veli");
            Console.WriteLine("E-posta: ali_veli@mail.com");
        }
    }

    // İYİ TASARIM
    public class ExtractMethodGood
    {
        public void DoSomeThing()
        {
            // diğer kod blokları...

            WriteUserInformationToConsole();
        }

        // kullanıcı bilgilerini ekrana bas
        private static void WriteUserInformationToConsole()
        {
            Console.WriteLine("Kullanıcı adı: ali_veli");
            Console.WriteLine("E-posta: ali_veli@mail.com");
        }
    }
}
