using System.Reflection;

namespace CleanArchitecture.Prover.Web.Extensions;

internal static class AssemblyExtension
{
    public static string GetCurrentSemVer(this Assembly assembly)
    {
        var version = Assembly.GetExecutingAssembly().GetName().Version;
        return $"{version?.Major}.{version?.Minor}.{version?.Build}";
    }
}