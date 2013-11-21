using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AniDb.Api.Tests
{
    public static class Helpers
    {
        public static string AppRoot = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
        public const string ResourcesDir = "Resources";
        public const string ResponsesDir = "Responses";
        public const string SerializedDir = "Serialized";

        public static string ResponseFile(string fileName) {
            return Path.Combine(AppRoot, ResourcesDir, ResponsesDir, fileName);
        }

        public static string SerializedObjectFile(string fileName) {
            return Path.Combine(AppRoot, ResourcesDir, SerializedDir, fileName);
        }

        public static string[] AllValidAnimeResponsesFiles() {
            return Directory.GetFileSystemEntries(Path.Combine(AppRoot, ResourcesDir, ResponsesDir))
                .Where(f => f.StartsWith("anime") && !f.Contains("99999"))
                .ToArray();
        }

        public static string[] AllSerializedObjectFiles() {
            return Directory.GetFileSystemEntries(Path.Combine(AppRoot, ResourcesDir, SerializedDir))
                .ToArray();
        }
    }
}