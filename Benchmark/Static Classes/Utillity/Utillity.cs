using System.Security.Cryptography;

namespace Benchmark;

public static partial class Utility {
    /// <summary>Looks recursively up to find the folder</summary>
    /// <param name="start"></param>
    /// <param name="find"></param>
    /// <returns></returns>
    public static String? FindFolder(String start, String find) {
        var dir = new DirectoryInfo(start);
        while (dir != null) {
            DirectoryInfo[] found = dir.GetDirectories(find, SearchOption.TopDirectoryOnly);
            if (found.Length > 0) {
                return found[0].FullName;
            }
            dir = dir.Parent;
        }

        return null;
    }

    public static String HexString(Int32 Length) {
        Byte[] data = new Byte[Length / 2];
        RandomNumberGenerator.Fill(data);

        return BitConverter.ToString(data).Replace("-", "");
    }
}
