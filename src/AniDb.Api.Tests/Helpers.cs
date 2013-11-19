using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AniDb.Api.Tests
{
    public static class Helpers
    {
        public static string AppRoot = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
        public static string ResourcesDir = "Resources";
        public static string ResponsesDir = "Responses";

        public static string ResponseFile(string fileName) {
            return Path.Combine(AppRoot, ResourcesDir, ResponsesDir, fileName);
        }

        public static string[] AllValidResponsesFiles() {
            return Directory.GetFileSystemEntries(Path.Combine(AppRoot, ResourcesDir, ResponsesDir))
                .Where(f => !f.Contains("99999"))
                .ToArray();
        }
    }
}