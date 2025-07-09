# if false

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using ArgumentException = System.ArgumentException;
using ArgumentNullException = System.ArgumentNullException;
using Uri = System.Uri;
using UriHostNameType = System.UriHostNameType;

Console.WriteLine(new Host("mail.google.com"));
Console.WriteLine(new Host("1.1.1.1"));
Console.WriteLine(new Host("2001:db8::1"));
Console.WriteLine(new Host("http://mail.google.com"));
Console.WriteLine(new Host("mail.google.com"));
Console.WriteLine(new Host("1.1.1.1"));
Console.WriteLine(new Host("mail.google.com:8080")); // Output: mail.google.com:8080
Console.WriteLine(new Host("1.1.1.1:8080")); // Output: 1.1.1.1:8080
Console.WriteLine(new Host("[fe80::1]:8080")); // Output: [fe80::1]:8080
Console.WriteLine(new Host("fe80::1")); // Output: fe80::1

public sealed record Hostname
{
    public string Host { get; }

    public Hostname(string value)
    {
        Host = ValidateHostname(value);
    }

    private static string ValidateHostname(string value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));

        var trimmed = value.Trim();

        if (trimmed.Length == 0)
            throw new ArgumentException("Hostname cannot be empty or whitespace", nameof(value));

        if (!IsValidHostname(trimmed))
            throw new("Invalid hostname: " + trimmed);

        return trimmed;
    }

    public override string ToString()
    {
        return Host;
    }

    private static bool IsValidHostname(string hostname)
    {
        if (IPAddress.TryParse(hostname, out var address))
            return true;

        return Uri.CheckHostName(hostname) == UriHostNameType.Dns;
    }
}

/// <summary>
/// Handles Host/Ip with a Port if present, created from string
/// </summary>
/// <example>
/// valid: example.com, 1.1.1.1, [2001:db8::1]:123, 1.1.1.1:111
/// invalid: https://example.com
/// </example>
public sealed record Host
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum HostnameType
    {
        IPv4,
        IPv4WithPort,
        IPv6,
        IPv6WithPort,
        Hostname,
        HostnameWithPort,
        Invalid,
    }

    public string HostPart { get; }
    public int? Port { get; }

    /// <exception cref="ArgumentException"></exception>
    public Host(string value)
    {
        var type = DetermineHostType(value);
        (HostPart, Port) = ParseHost(value, type);
    }

    public override string ToString()
    {
        return Port.HasValue ? $"{HostPart}:{Port}" : HostPart;
    }

    public static HostnameType DetermineHostType(string value)
    {
        if (string.IsNullOrEmpty(value))
            return HostnameType.Invalid;

        if (
            value.Count(c => c == '[') > 1
            || value.Count(c => c == ']') > 1
            || value.Count(c => c == '[') != value.Count(c => c == ']')
            || value.IndexOf(']') < value.IndexOf('[')
            || value.Contains("..")
            || value.StartsWith(':')
            || value.EndsWith(':')
            || value.Any(c => !".:[]-".Contains(c) && !char.IsLetterOrDigit(c))
        )
            return HostnameType.Invalid;

        // Check for IPv6 with port: [IPv6]:port
        if (value.StartsWith('['))
        {
            var closingBracketIndex = value.IndexOf(']');
            if (closingBracketIndex == -1)
                return HostnameType.Invalid;

            if (closingBracketIndex < value.Length - 1 && value[closingBracketIndex + 1] == ':')
            {
                var portPart = value[(closingBracketIndex + 2)..];
                if (!IsValidPort(portPart))
                    return HostnameType.Invalid;
                var ipv6Part = value.Substring(1, closingBracketIndex - 1);

                return IsIPv6(ipv6Part) ? HostnameType.IPv6WithPort : HostnameType.Invalid;
            }

            if (closingBracketIndex == value.Length - 1)
            {
                var ipv6Part = value.Substring(1, closingBracketIndex - 1);
                return IsIPv6(ipv6Part) ? HostnameType.IPv6 : HostnameType.Invalid;
            }

            return HostnameType.Invalid;
        }

        // Check for port presence or Ipv6
        var lastColonIndex = value.LastIndexOf(':');
        if (lastColonIndex > 0)
        {
            var hostPart = value[..lastColonIndex];
            var portPart = value[(lastColonIndex + 1)..];

            if (!IsValidPort(portPart))
                return HostnameType.Invalid;
            if (IsIPv4(hostPart))
                return HostnameType.IPv4WithPort;
            if (IsValidHostname(hostPart))
                return HostnameType.HostnameWithPort;

            return IsIPv6(value) ? HostnameType.IPv6 : HostnameType.Invalid;
        }

        if (IsIPv4(value))
            return HostnameType.IPv4;
        if (IsIPv6(value))
            return HostnameType.IPv6;
        if (IsValidHostname(value))
            return HostnameType.Hostname;
        return HostnameType.Invalid;
    }

    public static bool IsValidPort(string portPart)
    {
        if (string.IsNullOrEmpty(portPart))
            return false;

        if (!int.TryParse(portPart, out var port))
            return false;

        return port is >= 0 and <= 65535;
    }

    public static bool IsIPv4(string hostPart)
    {
        return IPAddress.TryParse(hostPart, out var ip)
            && ip.AddressFamily == AddressFamily.InterNetwork;
    }

    public static bool IsIPv6(string hostPart)
    {
        return IPAddress.TryParse(hostPart, out var ip)
            && ip.AddressFamily == AddressFamily.InterNetworkV6;
    }

    public static bool IsValidHostname(string hostPart)
    {
        return Uri.CheckHostName(hostPart) == UriHostNameType.Dns;
    }

    public static bool TryParseHost(string hostName, out Host? host)
    {
        host = null;

        try
        {
            host = new(hostName);
        }
        catch (ArgumentException e)
        {
            return false;
        }

        return true;
    }

    private static (string Host, int? Port) ParseHost(string value, HostnameType type)
    {
        return type switch
        {
            HostnameType.IPv4 => ParseIPv4(value),
            HostnameType.IPv4WithPort => ParseIPv4WithPort(value),
            HostnameType.IPv6 => ParseIPv6(value),
            HostnameType.IPv6WithPort => ParseIPv6WithPort(value),
            HostnameType.Hostname => ParseHost(value),
            HostnameType.HostnameWithPort => ParseHostnameWithPort(value),
            HostnameType.Invalid => throw new ArgumentException($"Invalid host {value}"),
            _ => throw new UnreachableException(),
        };
    }

    private static (string Host, int? Port) ParseIPv4(string value)
    {
        if (!IsIPv4(value))
            throw new UnreachableException($"Host parser error {nameof(ParseIPv4)} with {value}");

        return (value, null);
    }

    private static (string Host, int? Port) ParseIPv4WithPort(string value)
    {
        var lastColonIndex = value.LastIndexOf(':');
        var host = value[..lastColonIndex];
        var port = int.Parse(value[(lastColonIndex + 1)..]);

        if (!IsValidHostname(host) || !IsValidPort(port.ToString()))
            throw new UnreachableException(
                $"Host parser error {nameof(ParseIPv4WithPort)} with {value}"
            );

        return (host, port);
    }

    private static (string Host, int? Port) ParseIPv6(string value)
    {
        if (!IsIPv6(value))
            throw new UnreachableException($"Host parser error {nameof(ParseIPv6)} with {value}");

        return (value, null);
    }

    private static (string Host, int? Port) ParseIPv6WithPort(string value)
    {
        var closingBracketIndex = value.IndexOf(']');
        var ipv6 = value.Substring(1, closingBracketIndex - 1);
        var portString = value[(closingBracketIndex + 2)..];
        var port = int.Parse(portString);

        if (!IsIPv6(ipv6) || !IsValidPort(port.ToString()))
            throw new UnreachableException(
                $"Host parser error {nameof(ParseIPv6WithPort)} with {value}"
            );

        return (ipv6, port);
    }

    private static (string Host, int? Port) ParseHost(string value)
    {
        if (!IsValidHostname(value))
            throw new UnreachableException($"Host parser error {nameof(ParseHost)} with {value}");

        return (value, null);
    }

    private static (string Host, int? Port) ParseHostnameWithPort(string value)
    {
        var lastColonIndex = value.LastIndexOf(':');
        var host = value[..lastColonIndex];
        var port = int.Parse(value[(lastColonIndex + 1)..]);

        if (!IsValidHostname(host) || !IsValidPort(port.ToString()))
            throw new UnreachableException(
                $"Host parser error {nameof(ParseHostnameWithPort)} with {value}"
            );

        return (host, port);
    }
}

# endif