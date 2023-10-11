# CeFCall (v3.2)

Simple Custom, Custom Dll or XON/XOFF (Software Flow Control) Message Sender on ethernet.

## Prerequisites

### Custom Dlls

To use Custom Dll, have the two Dlls (x64 version) in the same directory:

1. CeFdll.dll

2. CeNComLayer.dll

### Development environment

Executables are based on .Net Framework 3.5, downloadable from here:
<https://www.microsoft.com/en-US/download/details.aspx?id=22> .

Unit Tests based on .NET framework 4.8, download from:
<https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48> .

## Usage

### Custom (TM) Connection

``CeFCall /c _COMMAND_ _SERVER_ _PORT_ _MESSAGES[...]_``

Sends a message to the given server using Custom protocol.

Examples:

```bash
CeFCall.exe /c exec 192.168.1.199 9100 70081
```

```bash
CeFCall.exe /c exec 192.168.1.199 9100 80010101230201230
```

#### Custom Commands

* _call_
 Sends a list of commands, forwarding the return value.
 Use '^' as an alias for double quotes.

* _exec_
 Sends a list of commands, returns error code and _inner_ return code.
 For example, querying the printer status with `1109`, on a priner without anomalies you will get `['0', '110900000']`: an echo of the command followed by the anomaly flags that characterized the response of this command.
 Use '^' as an alias for double quotes.
