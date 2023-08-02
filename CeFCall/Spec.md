devo comunicare con protocollo customDll (o custom ma SEMBRA che sia meglio customDLL) da access ad una stampante fiscale
X-KUBE F ETH/KUBE II F ETH

ho scopiazzato da qua
https://www.infolabsrl.it/news/collegamento-ai-registratori-cassa-custom/
dove trovi  il link per la dll. (ocio che sono DUE dll come descritto qua https://www.baccan.it/n445190-quando-il-reverse-engineering-e-l-unica-soluzione.htm
)
link dll 
http://www.infolabsrl.it/download/CeFdllInstallation_140.exe

Usage
=====

Comando exec
CeFCall.exe exec 192.168.1.199 9100 "7007 "

"7007 ": Pulisce display
7007xyz: scrive _xyz_
70081: Apri cassetto
3012125xyz: Carica la riga _xyz_ nel buffer
3013: Stampa il buffer

