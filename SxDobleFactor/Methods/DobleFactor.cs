using OtpNet;
using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SxDobleFactor.Methods
{
    public class DobleFactor
    {

        public static void GenerarOTP(string secret, string account, string issur, string archivo)
        {
            try
            {
                var otpauthUrl = $"otpauth://totp/{issur}:{account}?secret={secret}&issuer={issur}&digits=6";
                using (var qrGenerator = new QRCodeGenerator())
                {
                    var qrCodeData = qrGenerator.CreateQrCode(otpauthUrl, QRCodeGenerator.ECCLevel.Q);
                    using (var qrCode = new QRCode(qrCodeData))
                    {
                        using (var qrCodeImage = qrCode.GetGraphic(20))
                        {
                            MostrarQrPopup(qrCodeImage);
                        }
                    }
                }
            }
            catch (Exception Err)
            {

            }
        }

        public static void ValidarOTP(string secret, string otpCode, string archivo)        {
            try
            {
                // Convertir la clave secreta de base32 a bytes
                var secretKeyBytes = Base32Encoding.ToBytes(secret);
                // Crear un objeto TOTP basado en la clave secreta
                var totp = new Totp(secretKeyBytes);
                var ventanaDeVerificacion = new VerificationWindow(10, 10);
                // Validar el OTP
                bool isValid = totp.VerifyTotp(otpCode, out long timeStepMatched, ventanaDeVerificacion);
                if (isValid)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Environment.Exit(1);

                }
            }
            catch (Exception Err)
            {
                File.WriteAllText(archivo, Err.ToString());
            }
        }

        public static void MostrarQrPopup(Bitmap qrCodeImage)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            QrPopup popup = new QrPopup(qrCodeImage);
            popup.ShowDialog();
        }
    }
}
