using System.Diagnostics;
using System.IO;

namespace GroupDocs.Redaction.Examples.CSharp
{
    internal static class Utils
    {
        public static string PrepareOutputDirectory(string sourcePath, bool copy = true)
        {
            var stackTrace = new StackTrace();
            var callerMethod = stackTrace.GetFrame(1)?.GetMethod();
            var callerClassName = callerMethod?.DeclaringType?.Name;
            var outputPath = Constants.OutputPath;

            string exampleOutputFolder = Path.Combine(outputPath, callerClassName);
            if (!Directory.Exists(exampleOutputFolder))
            {
                Directory.CreateDirectory(exampleOutputFolder);
            }

            string sourseOutputFile = Path.Combine(exampleOutputFolder, Path.GetFileName(sourcePath));
            sourseOutputFile = Path.GetFullPath(sourseOutputFile);

            if (copy)
            {
                File.Copy(sourcePath, sourseOutputFile, true);
            }

            return sourseOutputFile;
        }
        
        public static string GetOutputFile(string sourcePath)
        {
            var path = Path.GetDirectoryName(sourcePath);
            var fileName = Path.GetFileNameWithoutExtension(sourcePath);
            var fileExtension = Path.GetExtension(sourcePath);

            string result = Path.Combine(path, $"{fileName}_Redacted{fileExtension}");

            return result;
        }

        public static string GetOutputFileByExtension(string sourcePath, string extension)
        {
            var path = Path.GetDirectoryName(sourcePath);
            var fileName = Path.GetFileNameWithoutExtension(sourcePath);

            string result = Path.Combine(path, $"{fileName}_Redacted{extension}");

            return result;
        }

        public static string GetOutputFileByName(string sourcePath, string name)
        {
            var path = Path.GetDirectoryName(sourcePath);

            string result = Path.Combine(path, name);

            return result;
        }

    }
}
