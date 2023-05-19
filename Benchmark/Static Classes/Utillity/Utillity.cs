namespace Benchmark;
///DOLATER <summary>add description for class: Utillity</summary>
public static partial class Utillity {

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
}
