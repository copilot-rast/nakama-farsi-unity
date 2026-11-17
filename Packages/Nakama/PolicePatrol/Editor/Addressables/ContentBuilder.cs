using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using UnityEditor.AddressableAssets.Settings;

namespace PolicePatrol.Sdk.Editor
{
    public static class ContentBuilder
    {
        public static string Build()
        {
            var settings = AddressablesSetup.Settings;
            if (!settings.BuildRemoteCatalog)
            {
                throw new InvalidOperationException("Press \"Set up\" first: remote content is not configured.");
            }

            var folder = settings.RemoteCatalogBuildPath.GetValue(settings);
            if (Directory.Exists(folder))
            {
                Directory.Delete(folder, true);
            }

            AddressableAssetSettings.BuildPlayerContent(out var result);
            if (!string.IsNullOrEmpty(result.Error))
            {
                throw new InvalidOperationException("Addressables build failed: " + result.Error);
            }

            if (!Directory.Exists(folder) || !Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories).Any())
            {
                throw new InvalidOperationException("The build wrote nothing to " + folder + ". Put some content in a Remote group first.");
            }

            return folder;
        }

        public static List<ContentFile> Describe(string folder)
        {
            var root = Root(folder);
            var platform = Path.GetFileName(root);
            var files = new List<ContentFile>();
            using (var sha = SHA256.Create())
            {
                foreach (var file in Directory.EnumerateFiles(root, "*", SearchOption.AllDirectories).OrderBy(path => path, StringComparer.Ordinal))
                {
                    var relative = file.Substring(root.Length + 1).Replace('\\', '/');
                    using (var stream = File.OpenRead(file))
                    {
                        var hash = sha.ComputeHash(stream);
                        files.Add(new ContentFile(platform + "/" + relative, BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant(), stream.Length));
                    }
                }
            }

            return files;
        }

        public static string Zip(string folder, ICollection<string> only)
        {
            var root = Root(folder);
            var platform = Path.GetFileName(root);
            var zipPath = Path.Combine(Path.GetTempPath(), "policepatrol-content-" + platform + ".zip");
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }

            using (var archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                foreach (var file in Directory.EnumerateFiles(root, "*", SearchOption.AllDirectories))
                {
                    var entry = platform + "/" + file.Substring(root.Length + 1).Replace('\\', '/');
                    if (only == null || only.Contains(entry))
                    {
                        archive.CreateEntryFromFile(file, entry, CompressionLevel.Optimal);
                    }
                }
            }

            return zipPath;
        }

        private static string Root(string folder) =>
            Path.GetFullPath(folder).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
    }
}
