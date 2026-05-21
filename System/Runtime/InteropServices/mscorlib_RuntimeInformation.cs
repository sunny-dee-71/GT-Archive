using System.Runtime.CompilerServices;
using Mono;

namespace System.Runtime.InteropServices;

/// <summary>Provides information about the .NET runtime installation.</summary>
public static class RuntimeInformation
{
	private static readonly Architecture _osArchitecture;

	private static readonly Architecture _processArchitecture;

	private static readonly OSPlatform _osPlatform;

	/// <summary>Returns a string that indicates the name of the .NET installation on which an app is running.</summary>
	/// <returns>The name of the .NET installation on which the app is running.</returns>
	public static string FrameworkDescription => "Mono " + Mono.Runtime.GetDisplayName();

	/// <summary>Gets a string that describes the operating system on which the app is running.</summary>
	/// <returns>The description of the operating system on which the app is running.</returns>
	public static string OSDescription => Environment.OSVersion.VersionString;

	/// <summary>Gets the platform architecture on which the current app is running.</summary>
	/// <returns>The platform architecture on which the current app is running.</returns>
	public static Architecture OSArchitecture => _osArchitecture;

	/// <summary>Gets the process architecture of the currently running app.</summary>
	/// <returns>The process architecture of the currently running app.</returns>
	public static Architecture ProcessArchitecture => _processArchitecture;

	static RuntimeInformation()
	{
		string runtimeArchitecture = GetRuntimeArchitecture();
		string oSName = GetOSName();
		switch (runtimeArchitecture)
		{
		case "arm":
			_osArchitecture = (Environment.Is64BitOperatingSystem ? Architecture.Arm64 : Architecture.Arm);
			_processArchitecture = Architecture.Arm;
			break;
		case "armv8":
			_osArchitecture = (Environment.Is64BitOperatingSystem ? Architecture.Arm64 : Architecture.Arm);
			_processArchitecture = Architecture.Arm64;
			break;
		case "x86":
			_osArchitecture = (Environment.Is64BitOperatingSystem ? Architecture.X64 : Architecture.X86);
			_processArchitecture = Architecture.X86;
			break;
		case "x86-64":
			_osArchitecture = (Environment.Is64BitOperatingSystem ? Architecture.X64 : Architecture.X86);
			_processArchitecture = Architecture.X64;
			break;
		default:
			_osArchitecture = (Environment.Is64BitOperatingSystem ? Architecture.X64 : Architecture.X86);
			_processArchitecture = (Environment.Is64BitProcess ? Architecture.X64 : Architecture.X86);
			break;
		}
		switch (oSName)
		{
		case "linux":
			_osPlatform = OSPlatform.Linux;
			break;
		case "osx":
			_osPlatform = OSPlatform.OSX;
			break;
		case "windows":
			_osPlatform = OSPlatform.Windows;
			break;
		case "solaris":
			_osPlatform = OSPlatform.Create("SOLARIS");
			break;
		case "freebsd":
			_osPlatform = OSPlatform.Create("FREEBSD");
			break;
		case "netbsd":
			_osPlatform = OSPlatform.Create("NETBSD");
			break;
		case "openbsd":
			_osPlatform = OSPlatform.Create("OPENBSD");
			break;
		case "aix":
			_osPlatform = OSPlatform.Create("AIX");
			break;
		case "hpux":
			_osPlatform = OSPlatform.Create("HPUX");
			break;
		case "haiku":
			_osPlatform = OSPlatform.Create("HAIKU");
			break;
		case "wasm":
			_osPlatform = OSPlatform.Create("BROWSER");
			break;
		default:
			_osPlatform = OSPlatform.Create("UNKNOWN");
			break;
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string GetRuntimeArchitecture();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string GetOSName();

	/// <summary>Indicates whether the current application is running on the specified platform.</summary>
	/// <param name="osPlatform">A platform.</param>
	/// <returns>
	///   <see langword="true" /> if the current app is running on the specified platform; otherwise, <see langword="false" />.</returns>
	public static bool IsOSPlatform(OSPlatform osPlatform)
	{
		return _osPlatform == osPlatform;
	}
}
