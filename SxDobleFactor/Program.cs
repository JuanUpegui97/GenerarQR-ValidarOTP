using System;
using SxDobleFactor.Methods;

namespace SxDobleFactor
{
    public class Program
    {
        public static string vOpcion = "";
        public static string vSecret = "";
        public static string vAccount = "";
        public static string vIssur = "";
        public static string vOtpCode = "";
        public static string vArchivo = "";

        static void Main(string[] args)
        {
            try
            {
                string test = "0";
                string testBD = "0";
                if (test == "1")
                {
                    if (testBD == "0")
                    {
                        //SQL
                        //Generar OTP
                        string[] arr1 = {
                              "/GENERAROTP",                                // 0
                              "/NKLUECPYQSEDWJDONBKYOKKFW",                 // 1
                              "/123",                                       // 2
                              "/Sx Advance",                                // 3
                              "/903283",                                    // 4
                             @"/C:\sxg5db\lst\foto2.jpg"                  // 5
                             };

                        args = arr1;

                    }
                    else
                    {
                        //ORACLE
                        string[] arr2 = {
                              "/VALIDAROTP",                                // 0
                              "/NKLUECPYQSEDWJDONBKYOKKFW",                 // 1
                              "/123",                                       // 2
                              "/995511",                                    // 3
                              "/363818",                                    // 4
                             @"/C:\sxg5db\Lst\isvalid.txt"                  // 5
                             };
                        args = arr2;
                    }
                }

                #region parametros
                // 0. Opcion            
                vOpcion = (args[0].Substring(1, args[0].Length - 1));
                
                // 1. secret
                vSecret = (args[1].Substring(1, args[1].Length - 1));

                // 2. account
                vAccount = (args[2].Substring(1, args[2].Length - 1));

                // 3. issur
                vIssur = (args[3].Substring(1, args[3].Length - 1));

                // 4. otpCode
                vOtpCode = (args[4].Substring(1, args[4].Length - 1));

                // 5. archivo
                vArchivo = (args[5].Substring(1, args[5].Length - 1));

                #endregion parametros
            }
            catch (Exception ex)
            {   

            }

            // Bu scando HC
            switch (vOpcion)
            {
                case "GENERAROTP":
                    DobleFactor.GenerarOTP(Program.vSecret, Program.vAccount, Program.vIssur, Program.vArchivo);
                    break;

                case "VALIDAROTP":
                    DobleFactor.ValidarOTP(Program.vSecret, Program.vOtpCode, Program.vArchivo);
                    break;
            }
        }
    }
}
