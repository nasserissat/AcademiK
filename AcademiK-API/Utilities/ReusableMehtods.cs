using System;
namespace AcademiK_API.Utilities
{
	public class ReusableMehtods
	{
        // Guarda la imagen en la carpeta de recursos
        public static string SaveImage(byte[] imageBytes, string firstName, string lastName)
        {
            string sanitizedFirstName = SanitizeFileName(firstName);
            string sanitizedLastName = SanitizeFileName(lastName);

            string fileName = $"{sanitizedFirstName}_{sanitizedLastName}_{DateTime.Now:yyyyMMddHHmmss}.jpg";
            string filePath = Path.Combine("Resources", fileName);

            if (!Directory.Exists("Resources"))
            {
                Directory.CreateDirectory("Resources");
            }

            File.WriteAllBytes(filePath, imageBytes);

            return filePath;
        }
        // perfila los datos del nombre de la imagen
        private static string SanitizeFileName(string filename)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                filename = filename.Replace(c, '_');
            }
            return filename;
        }
    }
}

