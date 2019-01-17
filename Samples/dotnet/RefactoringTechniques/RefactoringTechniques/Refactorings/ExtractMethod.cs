using System;

namespace RefactoringTechniques.Refactorings
{
    // BAD
    public class A
    {
        public void DoSomeThing()
        {
            // some code blocks...

            // write user information to console
            Console.WriteLine("Kullanıcı adı: ali_veli");
            Console.WriteLine("E-posta: ali_veli@mail.com");
        }
    }

    // GOOD
    public class B
    {
        public void DoSomeThing()
        {
            // some code blocks...

            WriteUserInformationToConsole();
        }

        private static void WriteUserInformationToConsole()
        {
            Console.WriteLine("Kullanıcı adı: ali_veli");
            Console.WriteLine("E-posta: ali_veli@mail.com");
        }
    }
}
