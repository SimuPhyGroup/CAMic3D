using System;
using System.IO;

public static class DllFinder
{
    public static string FindDll(string rootDirectory, string dllName)
    {
        foreach (string directory in Directory.GetDirectories(rootDirectory))
        {
            foreach (string file in Directory.GetFiles(directory))
            {
                if (Path.GetFileName(file).Equals(dllName, StringComparison.OrdinalIgnoreCase))
                {
                    return Path.GetDirectoryName(file);
                }
            }

            string foundDirectory = FindDll(directory, dllName);
            if (!string.IsNullOrEmpty(foundDirectory))
            {
                return foundDirectory;
            }
        }
        return null;
    }
}
