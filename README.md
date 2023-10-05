# CeFCall (v3.1)

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

### Custom Connection

``CeFCall /c _COMMAND_ _SERVER_ _PORT_ _MESSAGES[...]_``

Sends a message to the given server using XON/XOFF.

Examples:

```bash
CeFCall.exe /c exec 192.168.1.199 9100 70081
```

```bash
CeFCall.exe /c exec 192.168.1.199 9100 80010101230201230
```

#### Commands

* _call_
 Sends a list of commands, forwarding the return value.
 Use '^' as an alias for double quotes.

* _exec_
 Sends a list of commands, returns "0" plus the return code.
 Use '^' as an alias for double quotes.

### XOFF/XON Connection

``CeFCall /x _COMMAND_ _SERVER_ _PORT_ _MESSAGES[...]_``

Sends a message to the given server using XON/XOFF.

Examples:

```bash
CeFCall.exe /x send 192.168.1.199 9100 a
```

```bash
CeFCall.exe /x send 192.168.1.199 9100 ^ITEM1^2.5*R1
```

#### Commands

* _send_ / _exec_
 Sends a list of commands, pausing whenever an XOFF is received until an XON resumes.
 Use '^' as an alias for double quotes.

### Custom Dll connection

``CeFCall _COMMAND_ _SERVER_ _PORT_ _MESSAGES[...]_``

Sends a message to the given server using Custom (TM) protocol.

Examples:

```bash
CeFCall.exe exec 192.168.1.199 9100 70081
```
