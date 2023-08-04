# CeFCall (v3 RTM)

Simple Custom (TM) or XON/XOFF (Software Flow Control) Message Sender on ethernet.

## Prerequisiters

Still compatible on .Net Framework 3.5, downloadable from here:
<https://www.microsoft.com/en-US/download/details.aspx?id=22>
Soon migrating to .NET framework 4.8, download from:
<https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48>

## Usage

### XOFF/XON Connection

``CeFCall /x _COMMAND_ _SERVER_ _PORT_ _MESSAGES[...]_``

Sends a message to the given server using XON/XOFF.

Examples:

```bash
CeFCall.exe /x send 192.168.1.199 9100 a
```

```bash
CeFCall.exe /x send 192.168.1.199 9100 """ITEM1""2.5*R1"
```

#### Commands

* _send_
 Sends a list of XONXOFF commands.

### Custom (TM) connection

``CeFCall _COMMAND_ _SERVER_ _PORT_ _MESSAGES[...]_``

Sends a message to the given server using Custom (TM) protocol.

Examples:

```bash
CeFCall.exe exec 192.168.1.199 9100 70081
```
