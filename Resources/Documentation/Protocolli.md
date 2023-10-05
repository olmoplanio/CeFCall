**Part Number : 77100000004500     Rev**

![](cef2e6c5-b46b-44be-b392-3359776d8743.001.png)

**CUSTOM S.p.A.**

World Headquarters

**Via Berettine, 2/B - 43010 Fontevivo, Parma ITALY Tel. +39 0521 680111 - Fax +39 0521 610701 <info@custom.biz> - <www.custom.biz>**

*All rights reserved*

**<www.custom.biz>**

Tutti i diritti riservati. È vietata la riproduzione totale o parziale del presente manuale in qualsiasi forma, sia essa cartacea o informatica. La CUSTOM ENGINEERING S.p.A. e le risorse impiegate nella realizzazione del manuale, non si assumono nessuna responsabilità derivante dall’utilizzo dello stesso, garantendo che le informazioni contenute nel manuale sono state accuratamente verifi cate.

Ogni suggerimento riguardo ad eventuali errori riscontrati o a possibili miglioramenti sarà particolarmente ap- prezzato. I prodotti sono soggetti ad un continuo controllo e miglioramento, pertanto la CUSTOM ENGINEERING S.p.A. si riserva di modifi care le informazioni contenute nel manuale senza preavviso.

*Questa manuale si riferisce alle seguenti versioni di prodotti fi scali: 1° generazione KUBE-F  1.56*

*THEA-F  1.44*

*MAX  1.42*

*2° generazione BIG  1.08 XTHEA-F  1.02*

*XKUBE-F  1.18 VKP80II-XF  1.16*

Copyright © 2008 CUSTOM ENGINEERING S.p.A. – Italy

CUSTOM ENGINEERING S.p.A.

Str. Berettine 2 - 43010 Fontevivo (PARMA) - Italy

Tel. : +39 0521-680111  -  Fax : +39 0521-610701 http: <www.custom.it>

Assistenza Tecnica Clienti

*Prodotti POS & Retail:*   <supporto.pos@custom.it>

**SOMMARIO**

PROTOCOLLO CUSTOM![ref1]

PROTOCOLLO DI COMUNICAZIONE ............................................................................................................8 Precisazioni in merito ai prodotti fi scali .......................................................................................................9 Precisazioni in merito al protocollo ..............................................................................................................9 Precisazione sull’utilizzo della CUSTOM DLL .............................................................................................9 Precisazioni sulla gestione del fi ne-carta ....................................................................................................9 Precisazioni sul contenuto dei messaggi (glossario) ...................................................................................9

GRUPPI DI COMANDI ...................................................................................................................................10 1 COMANDI RICHIESTA DATI .......................................................................................................................13

*1001  Data/ora..................................................................................................................................................................................13 1002  Righe intestazione ..................................................................................................................................................................13 1003  Totali scontrino .......................................................................................................................................................................14 1004  Totali giornalieri ......................................................................................................................................................................14 1005  Dati di chiusura giornaliera per n° d’ordine ............................................................................................................................15 1006  Dati di chiusura giornaliera per data .......................................................................................................................................15 1007  Dati ripristini fi scali..................................................................................................................................................................16 1008  Numero matricola fi scale ........................................................................................................................................................16 1009  Stato stampante .....................................................................................................................................................................17 1010  Stato stampante .....................................................................................................................................................................17 1011  Stato scontrini.........................................................................................................................................................................18 1012  Step scontrino fi scale .............................................................................................................................................................18 1013  Modello e release stampante .................................................................................................................................................18 1015  Codice d’errore .......................................................................................................................................................................19 1104  Dati ultima chiusura fi scale e numero DGFE .........................................................................................................................19 1109  Stato stampante .....................................................................................................................................................................20 1209  Stato stampante .....................................................................................................................................................................20 1270  Abilita / disabilita taglierina .....................................................................................................................................................20*

2 OPERAZIONI FISCALI ................................................................................................................................21

*2001  Programmazione data/ora ......................................................................................................................................................21 2002  Esecuzione chiusura giornaliera ............................................................................................................................................21 2003  Esecuzione lettura giornaliera ................................................................................................................................................22 2005  Fiscalizzazione .......................................................................................................................................................................22 2006  Verifi ca periodica ....................................................................................................................................................................23 2102  Azzeramento reparti ...............................................................................................................................................................24 2103  Lettura reparti .........................................................................................................................................................................24 2201  Incremento contatori di classe 2 .............................................................................................................................................24*

3 GENERAZIONE DI DOCUMENTI FISCALI ................................................................................................25

*3001  Operazione fi scale..................................................................................................................................................................25 3002  Riga aggiuntiva (ulteriore descrizione operazione) ................................................................................................................26 3003  Stampa subtotale ...................................................................................................................................................................27 3004  Pagamento con corrispettivo pagato ......................................................................................................................................27 3005  Pagamento con corrispettivo non pagato ...............................................................................................................................28 3006  Pagamento con EFT POS ......................................................................................................................................................28 3008  Riga aggiuntiva pagamenti .....................................................................................................................................................29 3009  Stampa rimanenza .................................................................................................................................................................29 3010  Righe fi sse..............................................................................................................................................................................30 3011  Chiusura scontrino .................................................................................................................................................................30 3012  Righe di cortesia .....................................................................................................................................................................31 3013  Espulsione scontrino con taglio parziale ................................................................................................................................32 3014  Espulsione scontrino con taglio parziale e avanzamento carta ..............................................................................................32 3015  Espulsione scontrino con taglio totale ....................................................................................................................................32 3016  Stampa bufferizzata ...............................................................................................................................................................33 3017  Stampa immagine grafi ca.......................................................................................................................................................33 3020  Forzatura stampa non bufferizzata .........................................................................................................................................34*

*3021  Stampa barcode interno a scontrino ......................................................................................................................................34 3022  Defi nizione lunghezza stampa bufferizzata ............................................................................................................................35 3101  Operazione fi scale su reparto selezionato .............................................................................................................................35 3116  Comando di attivazione buzzer ..............................................................................................................................................36*

4 GENERAZIONE DI DOCUMENTI NON FISCALI .......................................................................................37

*4001  Apertura documento non fi scale.............................................................................................................................................37 4002  Stampa intestazione ...............................................................................................................................................................37 4003  Stampa riga non fi scale ..........................................................................................................................................................37 4004  Chiusura documento non fi scale ............................................................................................................................................38 4005  Stampa ragione sociale ..........................................................................................................................................................38*

5 STAMPA DEL CONTENUTO DELLA MEMORIA FISCALE .........................................................................39

*5001  Stampa chiusure giornaliere per n° d’ordine ..........................................................................................................................39 5002  Stampa chiusure giornaliere per data ....................................................................................................................................39 5003  Stampa somma chiusure giornaliere per data ........................................................................................................................40 5004  Stampa integrale contenuto memoria fi scale .........................................................................................................................40 5005  Comando di interruzione stampa ...........................................................................................................................................41*

6 IMPOSTAZIONI FORMATI STAMPA ...........................................................................................................42

6\.1 Programmazione ragione sociale ........................................................................................................42

*6301  Numero max righe da stampare per ragione sociale .............................................................................................................42 6302  Programmazione ragione sociale ...........................................................................................................................................42*

7 VARIE ..........................................................................................................................................................43

*7001  Avanzamento carta ................................................................................................................................................................43 7005  Inizio modalità apprendimento ...............................................................................................................................................43 7006  Fine modalità apprendimento .................................................................................................................................................43 7007  Visualizzazione su display ......................................................................................................................................................44 7008  Apertura cassetto ...................................................................................................................................................................44 7009  Programmazione reparti .........................................................................................................................................................44*

8 GESTIONE DEL GIORNALE ELETTRONICO ............................................................................................46

*8001  Stampa giornale elettronico da data a data ............................................................................................................................46 8002  Stampa giornale elettronico per data e n° di scontrino...........................................................................................................46 8003  Stampa giornale elettronico da n. chiusura a n. chiusura ......................................................................................................47 8004  Richiesta riga di giornale elettronico ......................................................................................................................................47 8005  Stampa integrale giornale elettronico .....................................................................................................................................47 8006  Richiesta dati giornale elettronico ..........................................................................................................................................48 8007  Inizializzazione di un nuovo giornale elettronico ....................................................................................................................48*

9 ESEMPI .......................................................................................................................................................50

1. Scontrino di vendita .............................................................................................................................50
1. Annullo scontrino .................................................................................................................................51

PROTOCOLLO XON/XOFF![](cef2e6c5-b46b-44be-b392-3359776d8743.003.png)

1 SCOPO ED APPLICABILITÀ.......................................................................................................................54 2 FUNZIONALITÀ ...........................................................................................................................................55

3 STRUTTURA DEI DATI ...............................................................................................................................57

1. Defi nizioni – Regole ........................................................................................................................57
1. Separatori di campo ........................................................................................................................58
1. Terminatori di comando ...................................................................................................................59

- *Subtotale ................................................................................................................................................................................62*
- *Stampa codice numerico non sommante ...............................................................................................................................62*
- *Stampa messaggio alfanumerico ...........................................................................................................................................62 1%  Visualizza la descrizione sulla prima riga del customer display .............................................................................................63 2%  Visualizza la descrizione sulla seconda riga del customer display ........................................................................................63 a  Apertura cassetto ...................................................................................................................................................................63 j  Apertura scontrino non fi scale ................................................................................................................................................64 k  Annullo scontrino ....................................................................................................................................................................64*

*1w  Dump memoria fi scale totale ..................................................................................................................................................65*

*2w  Dump memoria fi scale per data .............................................................................................................................................65*

*3w  Dump memoria fi scale per numero ........................................................................................................................................65*

*4w  Dump giornale totale ..............................................................................................................................................................65*

*5w  Dump giornale per data ..........................................................................................................................................................66*

*6w  Dump giornale per numero .....................................................................................................................................................66*

*7w  Termina dump.........................................................................................................................................................................66*

*D  Imposta data/ora ....................................................................................................................................................................66*

*39F Stampa Codice Fiscale / Partita IVA cliente ...........................................................................................................................67*

*40F Stampa messaggio di cortesia a fi ne scontrino ......................................................................................................................67*

*J  Chiusura scontrino non fi scale ...............................................................................................................................................68*

*K  Clear .......................................................................................................................................................................................68*

*0M  Modifi catore storno .................................................................................................................................................................68*

*1M  Modifi catore sconto % su transazione articolo .......................................................................................................................69*

*2M  Modifi catore sconto % su subtotale ........................................................................................................................................69*

*3M  Modifi catore sconto a valore su transazione articolo .............................................................................................................69*

*4M  Modifi catore sconto a valore su subtotale ..............................................................................................................................70*

*5M  Modifi catore maggiorazione % su transazione articolo ..........................................................................................................70*

*6M  Modifi catore maggiorazione % su subtotale ...........................................................................................................................70*

*7M  Modifi catore maggiorazione a valore su transazione articolo ................................................................................................71*

*8M  Modifi catore maggiorazione a valore su subtotale .................................................................................................................71*

*9M  Modifi catore reso ....................................................................................................................................................................71*

*10M  Cauzione ................................................................................................................................................................................72*

*12M  Chiusura a credito ..................................................................................................................................................................73*

*O  Selezione operatore ...............................................................................................................................................................73*

*P  Vendita a PLU ........................................................................................................................................................................74*

*R  Vendita a REPARTO ..............................................................................................................................................................75*

*1T  Pagamento (tender) con contante ..........................................................................................................................................76*

*2T  Pagamento (tender) con assegno ..........................................................................................................................................77*

*3T  Pagamento (tender) con carta elettronica ..............................................................................................................................77*

*4T  Pagamento (tender) con credito .............................................................................................................................................78*

*5T  Pagamento (tender) con buono pasto ....................................................................................................................................79*

*6T  Pagamento (tender) con sospensione ...................................................................................................................................79*

*7T  Pagamento (tender) con pagamento generico .......................................................................................................................79*

*21T Pagamento (tender) con buono pasto e calcolo del resto (solo per modelli FP) .....................................................................................80 22T Pagamento (tender) con buono pasto e calcolo del resto (solo per modelli ECR) ......................................................................................81 Y  Restituisce il controllo della transazione alla tastiera .............................................................................................................81*

*1Z  Stampa BARCODE EAN13 ....................................................................................................................................................82*

*2Z  Stampa BARCODE EAN8 ......................................................................................................................................................83*

*3Z  Stampa BARCODE CODE39 .................................................................................................................................................84*

4 COME EFFETTUARE LE PRIME PROVE DI COLLEGAMENTO ..............................................................85

4\.1  Parametri di collegamento ..............................................................................................................85

5***![ref2]

7***![ref3]

PROTOCOLLO CUSTOM![ref4]

***KUBE-F THEA-F MAX***

***BIG     XTHEA-F XKUBE-F VKP80II-F***

*PROTOCOLLO CUSTOM*

**PROTOCOLLO DI COMUNICAZIONE**

Il colloquio avviene impostando i seguenti parametri per la trasmissione seriale RS232:

- Baud Rate: 19200 bps **NOTE![](cef2e6c5-b46b-44be-b392-3359776d8743.007.png)**
- Parità: ODD Il segnale RTS deve essere tenuto alto.
- Data lenght: 7 bit dati Nei prodotti di nuova generazione XG la velocità di
- 1 bit stop comunicazione può arrivare fi no a 57.600 bps.

Il formato di trasmissione del comando è riportato nel seguente schema:

|**STX**|**CNT**|**IDENT**|**MESSAGGIO**|**CKS**|**ETX**|
| - | - | - | - | - | - |

Dove il signifi cato dei campi è:

|**NOME CAMPO**|**DESCRIZIONE**|**LUNGHEZZA *(in bytes)***|**VALORE**|
| - | - | :-: | - |
|**STX**|Inizio frame|1 byte|02h|
|**CNT**|Contatore frame|2 bytes|00###99|
|**IDENT**|Identifi catore|1 byte|carattere ASCII|
|**MESSAGGIO**|Stringa (header1+header2+dati)|||
|**CKS**|Checksum|2 bytes|00###99|
|**ETX**|Fine frame|1 byte|03h|

**L**a notazione 02h identifi ca il valore esadecimale 02.

In caso di ricezione corretta si deve rispondere con il singolo carattere di  **ACK ![](cef2e6c5-b46b-44be-b392-3359776d8743.008.png)**In caso di ricezione non corretta si deve rispondere con il singolo carattere di  **NACK![](cef2e6c5-b46b-44be-b392-3359776d8743.009.png)**

|**ACK**|acknowledge|1 byte|06h|
| - | - | - | - |
|**NACK**|not acknowledge|1 byte|15h|

dove :

Il campo **MESSAGGIO** é così composto:

**LUNGHEZZA![](cef2e6c5-b46b-44be-b392-3359776d8743.010.png)**

**DESCRIZIONE VALORE**

***(in bytes)***

HEADER1 Corrisponde al gruppo 1 byte 1÷9 HEADER2 Corrisponde alla funzione 3 bytes 000÷999 DATI Dati del comando

**NOTA![](cef2e6c5-b46b-44be-b392-3359776d8743.011.png)**

- Il contatore di frame si incrementa ad ogni stringa inviata ( anche se la precedente non é andata a buon fi ne ); non si incrementa invece nel caso di reinvio della stessa stringa (retry).
- La risposta ACK (acknowledge) ad ogni frame viene data solo in caso di ricezione corretta.
- Il campo CKS (checksum) è la somma modulo 100 dei campi CNT+IDENT+MESSAGGIO.
- Il campo IDENT è fi sso a “0” (zero come carattere ASCII).

9***![ref3]
*PROTOCOLLO CUSTOM*

**Precisazioni in merito ai prodotti fiscali**

I prodotti fi scali sono suddivisi per generazioni:

1° generazione:  KUBE-F, THEA-F, MAX

2° generazione:  BIG, XTHEA-F, XKUBE-F, VKP80II-XF

**Precisazioni in merito al protocollo**

Dando per scontato il corretto collegamento del sistema alla Stampante e la corretta gestione delle porte seriali, esistono le seguenti casistiche:

1. Il contatore di frame è una valore compreso tra 0÷99 e deve essere incrementato di 1 ad ogni comando.
1. La risposta di NACK (not acknowledge) indica che la stringa inviata ha la checksum errata, oppure che è stato inviato un comando con contatore di frame uguale al precedente.
1. Il contatore di frame posto a 00 e’ sempre accettato e non genera una risposta NACK (not acknowledge) azzerando il valore atteso dalla stampante. Si consiglia di servirsene per inviare il primo comando.
1. Sia ad ACK che a NACK l’HOST deve rispondere ACK , nel primo caso il comando è da ritenersi interpre- tato correttamente, nel secondo no.

**NOTA:** Se un comando descritto nel presente manuale non dovesse essere supportato dal prodotto fi scale verifi care la versione fi rmware a bordo del prodotto fi scale.![](cef2e6c5-b46b-44be-b392-3359776d8743.012.png)

**Precisazione sull’utilizzo della CUSTOM DLL**

La sintassi dei comandi descritti in questo manuale è valida anche per l’utilizzo della DLL sviluppata per il protocollo CUSTOM e chiamata ‘CeFDLL.DLL’. Nel caso di utilizzo della DLL non sono da considerare tutte le osservazioni iniziali sulla struttura del basso livello ma occorre fare riferimento solo al manuale d’uso della DLL stessa che accompagna il suo pacchetto di installazione.

**Precisazioni sulla gestione del fine-carta**

La Stampante provvede in maniera automatica alle ristampe dei soli scontrini fi scali che risultano essere in corso al momento del fi ne carta, nel momento dell’introduzione del nuovo rotolo carta.

**Precisazioni sul contenuto dei messaggi (glossario)**

RIGA:  Può occupare l’intera larghezza della carta

DESCR:  È seguita da un importo stampato nella posizione più a destra allineata col totale LUN:  Lunghezza (num. bytes) del campo che segue

PITCH:  Il valore del campo pitch è defi nito nel seguente modo :

1. Standard
1. Bold ad es. per il settaggio delle righe di intestazione
1. 42 caratteri stampabili nella linea per le stampe non fi scali
1. Doppia Altezza
1. Doppia Larghezza
1. Corsivo
1. Normale/doppia altezza/42 caratteri
1. Grassetto/42 caratteri
1. Grassetto/doppia altezza/42 caratteri

**NOTA:** I valori di PITCH corrispondenti a 4, 5, 6 sono presenti nei prodotti fi scali di 1° genera- zione (dalle release fi rmware 1.34 e successive) e nei prodotti fi scali di 2° generazione (tutte le release).![](cef2e6c5-b46b-44be-b392-3359776d8743.013.png)

***9![ref2]***

*PROTOCOLLO CUSTOM*

**GRUPPI DI COMANDI**

I comandi accettati dalla STAMPANTE Fiscale vengono suddivisi nei seguenti 8 gruppi:

1. Richiesta dati 5.  Stampa del contenuto della memoria fi scale
1. Operazioni fi scali 6.  Impostazioni formato stampa
1. Generazione di documenti fi scali 7.  Varie
1. Generazione di documenti non fi scali 8.  Gestione del giornale Elettronico

Ogni comando eseguito correttamente genera una risposta del tipo: <ECHO COMANDO><DATI COMANDO>

Se un comando causa un anomalia di funzionamento genera una risposta del tipo:

<ECHO COMANDO>ERR*nn*  dove *nn* rappresenta un numero 0 ÷ 99 che segnala uno stato

***Nota:***  Lo stato di anomalia di funzionamento non necessita di azzeramento.

La tabella riepilogativa delle anomalie di funzionamento è riportata sul manuale “GUIDA SEGNALA- ZIONI DI STATO”.

FUNZIONE![](cef2e6c5-b46b-44be-b392-3359776d8743.014.png)

*1 COMANDI RICHIESTA DATI*

|**1001**|Data/ora|
| - | - |
|**1002**|Righe intestazione|
|**1003**|Totali scontrino|
|**1004**|Totali giornalieri|
|**1005**|Dati di chiusura giornaliera per n° d’ordine|
|**1006**|Dati di chiusura giornaliera per data|
|**1007**|Dati ripristini fi scali|
|**1008**|Numero matricola fi scale|
|**1009**|Stato stampante|
|**1010**|Stato stampante|
|**1011**|Stato scontrini|
|**1012**|Step scontrino fi scale|
|**1013**|Modello e release stampante|
|**1015**|Codice d’errore|
|**1104**|Dati ultima chiusura fi scale e numero DGFE|
|**1109**|Stato stampante|
|**1209**|Stato stampante|
|**1270**|Abilita / disabilita taglierina|
|||
FUNZIONE![ref5]

*2 OPERAZIONI FISCALI*

|**2001**|Programmazione data/ora|
| - | - |
|**2002**|Esecuzione chiusura giornaliera|
|**2003**|Esecuzione lettura giornaliera|
|**2005**|Fiscalizzazione|
|**2006**|Verifi ca periodica|
|**2102**|Azzeramento reparti|
|**2103**|Lettura reparti|
|**2201**|Incremento contatori di classe 2|
|*3 GENERAZIONE DI DOCUMENTI FISCALI*||
|**3001**|Operazione fi scale|
|**3002**|Riga aggiuntiva (ulteriore descrizione operazione)|
|**3003**|Stampa subtotale|
|**3004**|Pagamento con corrispettivo pagato|
|**3005**|Pagamento con corrispettivo non pagato|
|**3006**|Pagamento con EFT POS|
|**3008**|Riga aggiuntiva pagamenti|
|**3009**|Stampa rimanenza|
|**3010**|Righe fi sse|
|**3011**|Chiusura scontrino|
|**3012**|Righe di cortesia|
|**3013**|Espulsione scontrino con taglio parziale|
|**3014**|Espulsione scontrino con taglio parziale e avanzamento carta|
|**3015**|Espulsione scontrino con taglio totale|
|**3016**|Stampa bufferizzata|
|**3017**|Stampa immagine grafi ca|
|**3020**|Forzatura stampa non bufferizzata|
|**3021**|Stampa barcode interno a scontrino|
|**3022**|Defi nizione lunghezza stampa bufferizzata|
|**3101**|Operazione fi scale su reparto selezionato|
|**3116**|Comando di attivazione buzzer|
|*4 GENERAZIONE DI DOCUMENTI NON FISCALI*||
|**4001** Apertura documento non fi scale||
|**4002** Stampa intestazione||
|||

``***13***![ref6]***
*PROTOCOLLO CUSTOM*

FUNZIONE

|**4003** Stampa riga non fi scale||
| - | :- |
|**4004** Chiusura documento non fi scale||
|**4005** Stampa ragione sociale||
|*5 STAMPA DEL CONTENUTO DELLA MEMORIA FISCALE*||
|**5001** Stampa chiusure giornaliere per n° d’ordine||
|**5002** Stampa chiusure giornaliere per data||
|**5003** Stampa somma chiusure giornaliere per data||
|**5004** Stampa integrale contenuto memoria fi scale||
|**5005** Comando di interruzione stampa||
|*6 IMPOSTAZIONI FORMATI STAMPA*||
|**6301**|Numero max righe da stampare per ragione sociale|
|**6302**|Programmazione ragione sociale|
|*7 VARIE*||
|**7001**|Avanzamento carta|
|**7005**|Inizio modalità apprendimento|
|**7006**|Fine modalità apprendimento|
|**7007**|Visualizzazione su display|
|**7008**|Apertura cassetto|
|**7009**|Programmazione reparti|
|*8 GESTIONE DEL GIORNALE ELETTRONICO*||
|**8001**|Stampa giornale elettronico da data a data|
|**8002**|Stampa giornale elettronico per data e n° di scontrino|
|**8003**|Stampa giornale elettronico da n. chiusura a n. chiusura|
|**8004**|Richiesta riga di giornale elettronico|
|**8005**|Stampa integrale giornale elettronico|
|**8006**|Richiesta dati giornale elettronico|
|**8007**|Inizializzazione di un nuovo giornale elettronico|
|||

15 ***![ref7]***
*PROTOCOLLO CUSTOM*

**1 COMANDI RICHIESTA DATI**

**1001 Data/ora![ref8]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**001**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>001</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4-5</td><td colspan="1">GG </td><td colspan="1">2 bytes</td><td colspan="1">GG = Giorno  [01÷31]</td></tr>
<tr><td colspan="1">6-7</td><td colspan="1">MM </td><td colspan="1">2 bytes</td><td colspan="1">MM = Mese  [01÷12]</td></tr>
<tr><td colspan="1">8-9</td><td colspan="1">AA </td><td colspan="1">2 bytes</td><td colspan="1">AA = Anno  [00÷99]</td></tr>
<tr><td colspan="1">10-11</td><td colspan="1">HH </td><td colspan="1">2 bytes</td><td colspan="1">HH = Ora  [00÷24]</td></tr>
<tr><td colspan="1">12-13</td><td colspan="1">Mm</td><td colspan="1">2 bytes</td><td colspan="1">mm = Minuti  [00÷59]</td></tr>
</table>

**1002 Righe intestazione![ref9]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**002**|3 bytes|HEADER2: indica la funzione|
|4|N.RIGA|1 byte|N. RIGA: Numero riga dell’intestazione [1÷6]|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>002</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4</td><td colspan="1">N. RIGA</td><td colspan="1">1 byte</td><td colspan="1">N. RIGA = Numero riga [1÷6]</td></tr>
<tr><td colspan="1">5</td><td colspan="1">PITCH</td><td colspan="1">1 byte</td><td colspan="1"><p>PITCH [1÷6] =  1 (normale)</p><p>2 (grassetto)</p><p>3 (42 caratteri)</p><p>4 (doppia altezza)</p><p>5 (doppia larghezza) 6 (corsivo)</p></td></tr>
<tr><td colspan="1">6-7</td><td colspan="1">LUN</td><td colspan="1">2 bytes</td><td colspan="1">Lunghezza della riga [00÷32]</td></tr>
<tr><td colspan="1">8-39</td><td colspan="1">RIGA</td><td colspan="1">0-32 bytes</td><td colspan="1">Testo della riga [alfanumerico]</td></tr>
</table>

***Nota:***  I valori di PITCH corrispondenti a 4, 5 e 6 sono presenti nei prodotti fi scali di 1° generazione (dalle

release fi rmware 1.34 e successive) e nei prodotti fi scali di 2° generazione (tutte le release).

**1003 Totali scontrino ![ref10]**Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**003**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>003</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4-12</td><td colspan="1">TPMA</td><td colspan="1">9 bytes</td><td colspan="1">TPMA = tot. parziale maggiorazioni [0÷999999999]</td></tr>
<tr><td colspan="1">13-21</td><td colspan="1">TPS</td><td colspan="1">9 bytes</td><td colspan="1">TPS = tot. parziale sconti [0÷999999999]</td></tr>
<tr><td colspan="1">22-30</td><td colspan="1">TPRET</td><td colspan="1">9 bytes</td><td colspan="1">TPRET = tot. parziale rettifi che</td></tr>
<tr><td colspan="1">31-39</td><td colspan="1">TPRE</td><td colspan="1">9 bytes</td><td colspan="1">TPRE = tot. parz. Resi [0÷999999999]</td></tr>
<tr><td colspan="1">40</td><td colspan="1">SEGNOS</td><td colspan="1">1 byte</td><td colspan="1">SEGNOS = segno del subtotale [+,-]</td></tr>
<tr><td colspan="1">41-49</td><td colspan="1">SUBT</td><td colspan="1">9 bytes</td><td colspan="1">SUBT = subtotale [0÷999999999]</td></tr>
<tr><td colspan="1">50</td><td colspan="1">SEGNOR</td><td colspan="1">1 byte</td><td colspan="1">SEGNOR = segno rimanenza (se “-” è Resto) [+,-]</td></tr>
<tr><td colspan="1">51-59</td><td colspan="1">RIM</td><td colspan="1">9 bytes</td><td colspan="1">RIM = rimanenza da pagare o resto [0÷999999999]</td></tr>
<tr><td colspan="1">60-63</td><td colspan="1">N° FRAMES</td><td colspan="1">4 bytes</td><td colspan="1">N°FRAMES = n° frames inviate scontrino fi scale [0÷9999]</td></tr>
<tr><td colspan="1">64</td><td colspan="1">SCONTR</td><td colspan="1">1 byte</td><td colspan="1">SCONTR = scontrino fi scale in corso [0/1]</td></tr>
</table>

**1004 Totali giornalieri![ref11]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**004**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>004</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4-7</td><td colspan="1">NSF</td><td colspan="1">4 bytes</td><td colspan="1">NSF = n° scontrini fi scali [0÷9999]</td></tr>
<tr><td colspan="1">8-16</td><td colspan="1">TSF</td><td colspan="1">9 bytes</td><td colspan="1">TSF = tot. scontrini fi scali [0÷999999999]</td></tr>
<tr><td colspan="1">17-20</td><td colspan="1">NFA</td><td colspan="1">4 bytes</td><td colspan="1">NFA = N/A [0÷9999]</td></tr>
<tr><td colspan="1">21-29</td><td colspan="1">TFA</td><td colspan="1">9 bytes</td><td colspan="1">TFA = N/A [0÷999999999]</td></tr>
<tr><td colspan="1">30-33</td><td colspan="1">NRIC</td><td colspan="1">4 bytes</td><td colspan="1">NRIC = N/A [0÷9999]</td></tr>
<tr><td colspan="1">34-42</td><td colspan="1">TRIC</td><td colspan="1">9 bytes</td><td colspan="1">TRIC = N/A [0÷999999999]</td></tr>
<tr><td colspan="1">43-46</td><td colspan="1">NSLM</td><td colspan="1">4 bytes</td><td colspan="1">NSLM = n° scontrini letture memoria fi scale [0÷9999]</td></tr>
<tr><td colspan="1">47-55</td><td colspan="1">TMA</td><td colspan="1">9 bytes</td><td colspan="1">TMA = tot. maggiorazioni [0÷999999999]</td></tr>
<tr><td colspan="1">56-64</td><td colspan="1">TSC</td><td colspan="1">9 bytes</td><td colspan="1">TSC = tot. sconti [0÷999999999]</td></tr>
<tr><td colspan="1">65-73</td><td colspan="1">TRET</td><td colspan="1">9 bytes</td><td colspan="1">TRET = tot. rettifi che [0÷999999999]</td></tr>
<tr><td colspan="1">74-82</td><td colspan="1">TRE</td><td colspan="1">9 bytes</td><td colspan="1">TRE = tot. Resi [0÷999999999]</td></tr>
<tr><td colspan="1">83-91</td><td colspan="1">TCNP</td><td colspan="1">9 bytes</td><td colspan="1">TCNP = tot. corrispettivi non pagati [0÷999999999]</td></tr>
</table>

**1005 Dati di chiusura giornaliera per n° d’ordine![ref12]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**005**|3 bytes|HEADER2: indica la funzione|
|4-7|N° ORD|4 bytes|Numero chiusura fi scale|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>005</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4-7</td><td colspan="1">N° ORD</td><td colspan="1">4 bytes</td><td colspan="1"><p>N° ORD = n° chiusura fi scale [1÷9999]</p><p>Se il n° chiusura fi scale richiesto non è valido, la STAM- PANTE FISCALE risponde errore.</p></td></tr>
<tr><td colspan="1">8-16</td><td colspan="1">T.GIO</td><td colspan="1">9 bytes</td><td colspan="1">T.GIO = Tot. Giorno [0÷999999999]</td></tr>
<tr><td colspan="1">17-20</td><td colspan="1">N. TE</td><td colspan="1">4 bytes</td><td colspan="1">N. TE = N/A [0÷9999]</td></tr>
<tr><td colspan="1">21-29</td><td colspan="1">T.E.</td><td colspan="1">9 bytes</td><td colspan="1">T.E. = N/A [0÷999999999]</td></tr>
<tr><td colspan="1">30-31</td><td colspan="1">GG</td><td colspan="1">2 bytes</td><td colspan="1">GG = Giorno  [01÷31]</td></tr>
<tr><td colspan="1">32-33</td><td colspan="1">MM</td><td colspan="1">2 bytes</td><td colspan="1">MM = Mese  [01÷12]</td></tr>
<tr><td colspan="1">34-35</td><td colspan="1">AA</td><td colspan="1">2 bytes</td><td colspan="1">AA = Anno  [00÷99]</td></tr>
</table>

**1006 Dati di chiusura giornaliera per data![ref9]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**006**|3 bytes|HEADER2: indica la funzione|
|4-5|GG|2 bytes|GG = Giorno  [01÷31]|
|6-7|MM|2 bytes|MM = Mese  [01÷12]|
|8-9|AA|2 bytes|AA = Anno  [00÷99]|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>005</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4-7</td><td colspan="1">N° ORD</td><td colspan="1">4 bytes</td><td colspan="1"><p>N° ORD = n° ordine [1÷9999]</p><p>Se il n° d’ordine richiesto non è valido, la STAMPANTE FISCALE risponde errore.</p></td></tr>
<tr><td colspan="1">8-16</td><td colspan="1">T.GIO</td><td colspan="1">9 bytes</td><td colspan="1">T.GIO = Tot. Giorno [0÷999999999]</td></tr>
<tr><td colspan="1">17-20</td><td colspan="1">N. TE</td><td colspan="1">4 bytes</td><td colspan="1">N. TE = N/A [0÷9999]</td></tr>
<tr><td colspan="1">21-29</td><td colspan="1">T.E.</td><td colspan="1">9 bytes</td><td colspan="1">T.E. = N/A [0÷999999999]</td></tr>
<tr><td colspan="1">30-31</td><td colspan="1">GG</td><td colspan="1">2 bytes</td><td colspan="1">GG = Giorno  [01÷31]</td></tr>
<tr><td colspan="1">32-33</td><td colspan="1">MM</td><td colspan="1">2 bytes</td><td colspan="1">MM = Mese  [01÷12]</td></tr>
<tr><td colspan="1">34-35</td><td colspan="1">AA</td><td colspan="1">2 bytes</td><td colspan="1">AA = Anno  [00÷99]</td></tr>
</table>

***Nota:*** Se la data richiesta non è valida, la STAMPANTE FISCALE risponde errore.

**1007 Dati ripristini fiscali ![ref10]**Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**007**|3 bytes|HEADER2: indica la funzione|
|4-7|N° ORD|4 bytes|Numero del ripristino|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>007</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4-5</td><td colspan="1">GG</td><td colspan="1">2 bytes</td><td colspan="1">GG = Giorno  [01÷31]</td></tr>
<tr><td colspan="1">6-7</td><td colspan="1">MM</td><td colspan="1">2 bytes</td><td colspan="1">MM = Mese  [01÷12]</td></tr>
<tr><td colspan="1">8-9</td><td colspan="1">AA</td><td colspan="1">2 bytes</td><td colspan="1">AA = Anno  [00÷99]</td></tr>
<tr><td colspan="1">10-11</td><td colspan="1">HH</td><td colspan="1">2 bytes</td><td colspan="1">HH = Ora  [00÷24]</td></tr>
<tr><td colspan="1">12-13</td><td colspan="1">mm</td><td colspan="1">2 bytes</td><td colspan="1">mm = Minuti  [00÷59]</td></tr>
<tr><td colspan="1">14-17</td><td colspan="1">N. RIP</td><td colspan="1">4 bytes</td><td colspan="1">N. RIP = n° ripristini in MF [0÷9999]</td></tr>
</table>

**1008 Numero matricola fiscale![ref13]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**008**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>008</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4-5</td><td colspan="1">ID</td><td colspan="1">2 bytes</td><td colspan="1">ID = n° approvazione e cod. costruttore [alfanumerico]</td></tr>
<tr><td colspan="1">6-13</td><td colspan="1">N. MATR.</td><td colspan="1">8 ytes</td><td colspan="1"><p>N. MATR = Numero matricola [000000÷999999]</p><p>Se la matricola non è ancora programmata, la STAMPANTE FISCALE risponde errore</p></td></tr>
</table>

**1009 Stato stampante![ref12]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**009**|3 bytes|HEADER2: indica la funzione|

Risposta:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|Nei primi 4 bytes, viene ripetuto il comando inviato|
|1-3|**009**|3 bytes||
|4-5|COD\_ERR- STAM|2 bytes|<p>COD\_ERRSTAM = codice di errore</p><p>00 = Coperchio chiuso - Carta presente 10 = Coperchio aperto - Carta presente 01 = Coperchio chiuso - Carta mancante 11 = Coperchio aperto - Carta mancante</p>|

**1010 Stato stampante![ref14]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1 :indica il gruppo di comandi|
|1-3|**010**|3 bytes|HEADER2 : indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>010</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4</td><td colspan="1">S1</td><td colspan="1">1 byte</td><td colspan="1">S1 = no_mf [0/1]</td></tr>
<tr><td colspan="1">5</td><td colspan="1">S2</td><td colspan="1">1 byte</td><td colspan="1">S2 = err_prog_mf [0/1]</td></tr>
<tr><td colspan="1">6</td><td colspan="1">S3</td><td colspan="1">1 byte</td><td colspan="1">S3 = date_to_set [0/1]</td></tr>
<tr><td colspan="1">7</td><td colspan="1">S4</td><td colspan="1">1 byte</td><td colspan="1">S4 = mf_ko [0/1]</td></tr>
<tr><td colspan="1">8</td><td colspan="1">S5</td><td colspan="1">1 byte</td><td colspan="1">S5 = f_ripristino (1: ripristino da fare) [0/1]</td></tr>
<tr><td colspan="1">9</td><td colspan="1">S6</td><td colspan="1">1 byte</td><td colspan="1">S6 = ponticello ( 1: ponticello on) [0/1]</td></tr>
<tr><td colspan="1">10</td><td colspan="1">S7</td><td colspan="1">1 byte</td><td colspan="1">S7 = matr. programmata (1: matr. Progr.) [0/1]</td></tr>
<tr><td colspan="1">11</td><td colspan="1">S8</td><td colspan="1">1 byte</td><td colspan="1">S8 = chiusura fi scale (1 chiusura fatta) [0/1]</td></tr>
<tr><td colspan="1">12</td><td colspan="1">S9</td><td colspan="1">1 byte</td><td colspan="1">S9 = stampa in corso [0/1]</td></tr>
<tr><td colspan="1">13</td><td colspan="1">S10</td><td colspan="1">1 byte</td><td colspan="1">S10 = errore stampante [0/1]</td></tr>
<tr><td colspan="1">14</td><td colspan="1">S11</td><td colspan="1">1 byte</td><td colspan="1">S11 = apprendimento in corso [0/1]</td></tr>
</table>

***Nota:***  Se il fl ag “S3” diventa 1 è stato appena effettuato un HW init e potrebbe essere necessario settare la

data.

**1011 Stato scontrini ![ref10]**Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**011**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>011</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4</td><td colspan="1">S1</td><td colspan="1">1 byte</td><td colspan="1">S1 = scontrino fi scale in corso [0/1]</td></tr>
<tr><td colspan="1">5</td><td colspan="1">S2</td><td colspan="1">1 byte</td><td colspan="1">S2 = scontrino non fi scale in corso [0/1]</td></tr>
</table>

**1012 Step scontrino fiscale![](cef2e6c5-b46b-44be-b392-3359776d8743.025.png)**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**012**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>012</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4</td><td colspan="1">STEP</td><td colspan="1">1 byte</td><td colspan="1"><p>STEP = step scontrino fi scale [0÷7] dove: 0  Scontrino off</p><p>1  Corpo scontrino (transazioni)</p><p>2  Pagamenti in corso</p><p>3  Stampa resto</p><p>4  Stampa righe fi sse (opzionali)</p><p>5  Chiusura eseguita</p><p>6  Stampa messaggi cortesia (opzionali) 7  Espulsione eseguita</p></td></tr>
</table>

**1013 Modello e release stampante![ref10]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**013**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>013</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4-30</td><td colspan="1">Rel.Stamp.</td><td colspan="1">32 byte</td><td colspan="1">Rel.Stamp.= indica il modello e la release della stampante. (Riga descrittiva che equivale alla stampa della release che si ottiene con il comando 2004 da tastiera).</td></tr>
</table>

**1015 Codice d’errore![](cef2e6c5-b46b-44be-b392-3359776d8743.026.png)**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**015**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>015</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4-6</td><td colspan="1">ERR</td><td colspan="1">3 bytes</td><td colspan="1">ERR = scritta ‘ERR’</td></tr>
<tr><td colspan="1">7-9</td><td colspan="1">nnn</td><td colspan="1">3 bytes</td><td colspan="1">nnn = Ultimo codice d’errore prodotto superiore a 99</td></tr>
<tr><td colspan="1">10-29</td><td colspan="1">DESCR</td><td colspan="1">Fino a 10 bytes</td><td colspan="1">DESCR = descrizione dell’ultimo codice d’errore prodotto con codice superiore a 99</td></tr>
</table>

***Nota:***  La tabella riepilogativa delle anomalie di funzionamento è riportata sul manuale “GUIDA SEGNALA-

ZIONI DI STATO”.

**1104 Dati ultima chiusura fiscale e numero DGFE![ref12]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**104**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>104</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4-7</td><td colspan="1">N. CHIUS.</td><td colspan="1">4 byte</td><td colspan="1">N. CHIUS. = Numero di chiusura fi scale corrente</td></tr>
<tr><td colspan="1">8-11</td><td colspan="1">N. DGFE</td><td colspan="1">4 byte</td><td colspan="1">N. DGFE = Numero di DGFE corrente</td></tr>
</table>

**Nota:** Tale comando è presente dalla release fi rmware 1.46 e successive, della stampante KUBE-F

**1109 Stato stampante ![ref10]**Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**109**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>109</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4</td><td colspan="1">S1</td><td colspan="1">1 byte</td><td colspan="1">S1 = Coperchio aperto</b> [0/1]</td></tr>
<tr><td colspan="1">5</td><td colspan="1">S2</td><td colspan="1">1 byte</td><td colspan="1">S2 = Fine carta</b> [0/1]</td></tr>
<tr><td colspan="1">6</td><td colspan="1">S3</td><td colspan="1">1 byte</td><td colspan="1">S3 = Quasi fi ne carta</b> [0/1]</td></tr>
<tr><td colspan="1">7</td><td colspan="1">S4</td><td colspan="1">1 byte</td><td colspan="1">S4 = DGFE esaurito</b> [0/1]</td></tr>
<tr><td colspan="1">8</td><td colspan="1">S5</td><td colspan="1">1 byte</td><td colspan="1"><p>S5 = DGFE prossimo all’esaurimento</b> [0/1]</p><p>(Si attiva quando sono possibili ancora 10 chiusure)</p></td></tr>
</table>

**1209 Stato stampante![ref15]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**1**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**209**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>1</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>109</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4</td><td colspan="1">S1</td><td colspan="1">1 byte</td><td colspan="1">S1 = Coperchio aperto</b> [0/1]</td></tr>
<tr><td colspan="1">5</td><td colspan="1">S2</td><td colspan="1">1 byte</td><td colspan="1">S2 = Fine carta</b> [0/1]</td></tr>
<tr><td colspan="1">6</td><td colspan="1">S3</td><td colspan="1">1 byte</td><td colspan="1">S3 = Quasi fi ne carta</b> [0/1]</td></tr>
<tr><td colspan="1">7</td><td colspan="1">S4</td><td colspan="1">1 byte</td><td colspan="1">S4 = DGFE esaurito</b> [0/1]</td></tr>
<tr><td colspan="1">8</td><td colspan="1">S5</td><td colspan="1">1 byte</td><td colspan="1"><p>S5 = DGFE prossimo all’esaurimento</b> [0/1]</p><p>(Si attiva quando sono possibili ancora 10 chiusure)</p></td></tr>
<tr><td colspan="1">9</td><td colspan="1">S6</td><td colspan="1">1 byte</td><td colspan="1">S6 = Condizione Taglierina [0/1] (1= Condizione di errore)</td></tr>
</table>

**1270 Abilita / disabilita taglierina![ref16]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|1|1 byte|HEADER1 :indica il gruppo di comandi|
|1-3|270|3 bytes|HEADER2 : indica la funzione|
|4|S1|1 byte|X=1 Taglierina Abilitata X=0 Taglierina disabilitata|

**2 OPERAZIONI FISCALI**

**2001 Programmazione data/ora![ref8]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**2**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**001**|3 bytes|HEADER2: indica la funzione|
|4-5|GG|2 bytes|GG = Giorno  [01÷31]|
|6-7|MM|2 bytes|MM = Mese  [01÷12]|
|8-9|AA|2 bytes|AA = Anno  [00÷99]|
|10-11|HH|2 bytes|HH = Ora  [00÷24]|
|12-13|mm|2 bytes|mm = Minuti  [00÷59]|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>2</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>001</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4</td><td colspan="1">STEP</td><td colspan="1">1 byte</td><td colspan="1"><p>STEP [0,1,2] dove:</p><p>0  Se data programmata</p><p>1  Ricevuto messaggio, attendo conferma (re-invio dello </p><p>stesso comando</p><p>2  Ricevuto messaggio, attende 2° conferma</p></td></tr>
</table>

***Nota:***  Quando alla stampante FISCALE, viene richiesto di programmare la data/ora, questa si aspetta una

conferma, se la nuova data supera di due o più giorni la data dell’ultima chiusura giornaliera, prima di eseguire la programmazione dell’orologio. Se la sequenza sopra descritta non è rispettata, la stampante FISCALE non accetta la nuova data e mantiene quella precedente.

**2002 Esecuzione chiusura giornaliera![ref17]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**2**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**002**|3 bytes|HEADER2: indica la funzione|
|4|PITCH|1byte|PITCH = 1 (opzionale)|
|5-6|LUN|2 bytes|LUN = lunghezza (num. bytes) del campo che segue (opzionale)|
|7-28|DESCR|0-22 bytes|DESCR = Descrizione aggiuntiva stampata in coda alla chiusura [alfanumerico] (opzionale)|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>2</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>002</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota1:*** Se la stampa dello scontrino di chiusura giornaliera non è eseguita correttamente, sarà inviato un

messaggio d’errore in seguito al quale il master potrà chiedere lo stato per conoscere l’errore ( o gli errori) verifi catosi.

***Nota2:*** Le sequenze di bytes da 4 a 22 sono opzionali.

- Se viene inserito il byte 4 verrà stampato in coda alla chiusura fi scale il numero rimanente di righe di DGFE (stampato con pitch 1)
- Se vengono inseriti i bytes 5-28 verrà stampato in coda alla chiusura la descrizione inserita. Tale campo può essere utilizzato, ad esempio, per inserire il numero di cassa. I comandi descritti in nota due sono disponibili dalla Rel. 146 della Kube-F

**2003 Esecuzione lettura giornaliera![](cef2e6c5-b46b-44be-b392-3359776d8743.030.png)**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**2**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**003**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>2</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>003</b></td><td colspan="1">3 bytes</td></tr>
</table>
**2005 Fiscalizzazione![ref13]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**2**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**005**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>2</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>005</b></td><td colspan="1">3 bytes</td></tr>
</table>
**2006 Verifica periodica![ref12]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**2**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**006**|3 bytes|HEADER2: indica la funzione|
|4-5|MM|2 bytes|MM = Mese [01÷12] della prossima verifi ca periodica|
|6-7|AA|2 bytes|AA = Anno [00÷99] della prossima verifi ca periodica|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>2</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>006</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:***  A seguito di questo comando, vengono avviate automaticamente delle verifi che per testare tutte le

funzionalità operative come ad es. della memoria fi scale, della memory card (giornale elettronico). Al termine di queste verifi che viene stampato uno scontrino come riportato di seguito:

**NON FISCALE![](cef2e6c5-b46b-44be-b392-3359776d8743.031.png)**

**AVVIO PROCEDURA VERIF. PERIODICA 01/01/2008  12:00:00  EV93000376**

**TEST FISCAL MEMORY  = OK TEST MEMORY CARD   = OK TEST uC RAM   = OK TEST NVRAM   = OK TEST DRAM  = OK**

**HEAD TEMPERAT. [°C]  = 30,00 HEAD VOLTAGE [V  = 24,25**

**TERM. PROCEDURA VERIF. PERIODICA 01/01/2008  12:00:00  EV93000376**

**01/01/2008  12:00:11 SNF.1 NON FISCALE**

**2102 Azzeramento reparti ![ref10]**Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**2**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**102**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>2</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>102</b></td><td colspan="1">3 bytes</td></tr>
</table>
**2103 Lettura reparti![ref18]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**2**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**103**|9 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>2</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>103</b></td><td colspan="1">93 bytes</td></tr>
</table>
**2201 Incremento contatori di classe 2![](cef2e6c5-b46b-44be-b392-3359776d8743.033.png)**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**2**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**201**|3 bytes|HEADER2: indica la funzione|
|4-12|Val. Doc2|9 bytes|Val. Doc2 = valore con decimale implicito della fattura stampata tramite scontrino “non fi scale”|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>2</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>201</b></td><td colspan="1">3 bytes</td></tr>
</table>
**3 GENERAZIONE DI DOCUMENTI FISCALI**

**3001 Operazione fiscale![ref8]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**001**|3 bytes|HEADER2: indica la funzione|
|4|TIPO|1 byte|<p>TIPO = tipo [1÷9, A] dove:</p><p>1  Vendita</p><p>2  Maggiorazioni</p><p>3  Sconti</p><p>4  Void</p><p>5  Annullo ultima operazione fi scale 8  All void</p><p>9  Resi</p><p>A  Cauzione</p>|
|5-6|LUN|2 bytes|LUN = lunghezza (num. bytes) del campo che segue|
|7-28|DESCR|0-22 bytes|DESCR = Descrizione dell’operazione [alfanumerico]|
|29-37|IMP|9 bytes|IMP = Importo [numerico]|

***Importante:*  il comando 3001 esegue una vendita generica non associata a un reparto e quindi ad**

**un’aliquota IVA.Vedere comando 3101 per vendite per reparto / aliquota IVA.                  *Importante:***  All’interno del campo “descrizione” (DESCR) possono essere utilizzati i caratteri che , appar-

tenenti al set ASCII standard, fi no al 125h.

***Nota:***  Il campo “descrizione” (DESCR) non può in nessun caso occupare le stesse colonne delle 5 cifre meno

rilevanti dell’importo, altrimenti verrà troncata. Inoltre descrizione ed importo, o simboli che lo precedono, devono essere separati da almeno uno spazio, in caso contrario l’importo (con simboli) verrà stampato su una seconda riga.

Nel caso di tipo = 4 (void), il campo importo (IMP) deve essere uguale all’importo da stornare. Inoltre, dopo un’operazione “all void” (tipo = 8) se si vuole l’espulsione sono da inviare gli opportuni comandi (3011 e 3013).

Dalla Rel.1.48 della Kube-F  è possibile inviare i comandi di tipo = 8 (all void)  e di tipo = 4 (void) anche a pagamento iniziato (dai comandi 3004, 3005, 3006) con lo stesso comportamento che si ottiene in fase di vendita. Per cui ora, anche a pagamento iniziato, è possibile eseguire l’annullo totale dello scontrino e l’annullo e dell’ultimo pagamento. Nello specifi co il comando di tipo = 4 (void) quando lo si vuole eseguire per annullare un pagamento richiede in input (campo IMP) il valore del pagamento da annullare: se questo è uguale viene annullato e restituito l’echo, mentre se questo è diverso viene restituito ERR05.

Dalla release 1.54 della Kube-F stato aggiunto un nuovo pitch = 5 che permette di annullare l’ultima operazione di vendita, sconto, maggiorazione, reso o annullo, con il corretto ripristino dei contatori relativi a tali operazioni. Tale comando non permette di annullare ne una descrizione di vendita (3002), ne l’operazione di subtotale (3003) o di annullo totale transazione (3001-8): in tal caso viene restitu- ito errore 05 di sequenza errata. Quando viene annullata un’operazione con questo comando , sullo scontrino fi scale viene scritta la dicitura “ANNULLO OPERAZ. PREC.”, seguita da un importo pari a quello annullato  ma con segno contrario, inoltre tale comando non può annullare sé stesso, una volta eseguito è quindi irreversibile

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>001</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:***  Alla ricezione della stringa, prima di eseguire la stampa, vengono verifi cate le seguenti condizioni:

- All’interno della descrizione non si trovi la scritta “TOTALE”;
- Non sia in corso nessun’operazione o sia in corso uno scontrino fi scale;
- L’importo non mandi in overfl ow o in underfl ow i totali dello scontrino, i totali giornalieri ed il totale fi scale progressivo.

Se tutte queste condizioni sono verificate, verrà stampata l’operazione, in caso contrario verrà segnalato il tipo d’errore.

**3002 Riga aggiuntiva (ulteriore descrizione operazione)![ref19]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**002**|3 bytes|HEADER2: indica la funzione|
|4|PITCH|1 byte|<p>PITCH [1÷9] =  1 (normale)</p><p>2 (grassetto)</p><p>3 (42 caratteri)</p><p>4 (doppia altezza)</p><p>5 (doppia larghezza)</p><p>6 (corsivo)</p><p>7 (normale/doppia altezza/42 caratteri) 8 (grassetto/42 caratteri)</p><p>9 (grassetto/doppia altezza/42 caratteri)</p>|
|5-6|LUN|2 bytes|LUN = lunghezza (num. bytes) del campo che segue|
|7-38|RIG|0-32 bytes|RIG = testo della riga di descrizione aggiuntiva di un’ope- razione all’interno di un documento fi scale [alfanumerico]|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>002</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:***  Si può usare il comando, quando è consentita un’operazione fi scale.

Se RIG contiene operatori e/o simboli speciali non viene eseguito nessun calcolo, viene solamente gestita e stampata come testo.

***Nota:***  I valori di PITCH corrispondenti a 4, 5 e 6 sono presenti nei prodotti fi scali di 1° generazione (dalle

release fi rmware 1.34 e successive) e nei prodotti fi scali di 2° generazione (tutte le release).

***Nota:***  I valori di PITCH corrispondenti a 7, 8, 9 sono presenti solo nei prodotti fi scali di 2° generazione (dalle

release fi rmware 1.14 e successive).

**3003 Stampa subtotale![ref12]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**003**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>003</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:*** Se il subtotale è negativo, viene stampato il suo valore preceduto dal segno “-”.

**3004 Pagamento con corrispettivo pagato![ref20]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**004**|3 bytes|HEADER2: indica la funzione|
|4-5|LUN|2 bytes|LUN = lunghezza (num. bytes) del campo che segue|
|6-27|DESCR|0-22 bytes|DESCR = Descrizione dell’operazione [alfanumerico]|
|28-36|IMP|9 bytes|IMP = Importo [numerico]|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>004</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4</td><td colspan="1">SEGNO</td><td colspan="1">1 byte</td><td colspan="1">SEGNO = segno della rimanenza [+/-] dove il segno “–“ indica il resto </td></tr>
<tr><td colspan="1">5-13</td><td colspan="1">RIM</td><td colspan="1">9 bytes</td><td colspan="1">RIM = Rimanenza da pagare (o resto) [0÷999999999] (se rimanenza = 0 il segno è “-“).</td></tr>
</table>

***Nota:*** Prima della prima riga di pagamento, sarà stampata la riga di totale.

**3005 Pagamento con corrispettivo non pagato ![ref10]**Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**005**|3 bytes|HEADER2: indica la funzione|
|4-5|LUN|2 bytes|LUN = lunghezza (num. bytes) del campo che segue|
|6-27|DESCR|0-22 bytes|DESCR = Descrizione dell’operazione [alfanumerico]|
|28-36|IMP|9 bytes|IMP = Importo [numerico]|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>005</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4</td><td colspan="1">SEGNO</td><td colspan="1">1 byte</td><td colspan="1">SEGNO = segno della rimanenza [+/-] dove il segno “–“ indica il resto </td></tr>
<tr><td colspan="1">5-13</td><td colspan="1">RIM</td><td colspan="1">9 bytes</td><td colspan="1">RIM = Rimanenza da pagare (o resto) [0÷999999999] (se rimanenza = 0 il segno è “-“).</td></tr>
</table>

***Nota:*** Prima della prima riga di pagamento, sarà stampata la riga di totale.

**3006 Pagamento con EFT POS![ref15]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**006**|3 bytes|HEADER2: indica la funzione|
|4-5|LUN|2 bytes|LUN = lunghezza (num. bytes) del campo che segue|
|6-27|DESCR|0-22 bytes|DESCR = Descrizione dell’operazione [alfanumerico]|
|28-36|IMP|9 bytes|IMP = Importo [numerico]|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>006</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4</td><td colspan="1">SEGNO</td><td colspan="1">1 byte</td><td colspan="1">SEGNO = segno della rimanenza [+/-] dove il segno “–“ indica il resto </td></tr>
<tr><td colspan="1">5-13</td><td colspan="1">RIM</td><td colspan="1">9 bytes</td><td colspan="1">RIM = Rimanenza da pagare (o resto) [0÷999999999] (se rimanenza = 0 il segno è “-“).</td></tr>
</table>

***Nota:***  Prima della prima riga di pagamento, sarà stampata la riga di totale e viene sempre considerato come

corrispettivo incassato.

**3008 Riga aggiuntiva pagamenti![ref12]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**008**|3 bytes|HEADER2: indica la funzione|
|4|PITCH|1 byte|<p>PITCH [1÷9] =  1 (normale)</p><p>2 (grassetto)</p><p>3 (42 caratteri)</p><p>4 (doppia altezza)</p><p>5 (doppia larghezza)</p><p>6 (corsivo)</p><p>7 (normale/doppia altezza/42 caratteri) 8 (grassetto/42 caratteri)</p><p>9 (grassetto/doppia altezza/42 caratteri)</p>|
|5-6|LUN|2 bytes|LUN = lunghezza (num. bytes) del campo che segue|
|7-38|RIG|0-32 bytes|RIG = testo della riga di descrizione aggiuntiva di un pa- gamento [alfanumerico]|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>008</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:***  Si può usare il comando, quando è consentito un pagamento.

Il testo della riga (RIG) non può invadere le colonne delle ultime 5 cifre dell’importo, altrimenti verrà troncata.

Se RIG contiene operatori e/o simboli speciali non viene eseguito nessun calcolo, viene solamente gestita e stampata come testo.

Se si lavora in stampa bufferizzata, questa riga non viene stampata subito ma quando si esegue l’ope- razione successiva (pagamento o rimanenza o chiusura).

***Nota:***  I valori di PITCH corrispondenti a 7, 8, 9 sono presenti solo nei prodotti fi scali di 2° generazione (dalle

release fi rmware 1.14 e successive).

**3009 Stampa rimanenza![ref21]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**009**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>009</b></td><td colspan="1">3 bytes</td></tr>
</table>
**3010 Righe fisse ![ref10]**Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**010**|3 bytes|HEADER2: indica la funzione|
|4|PITCH|1 byte|<p>PITCH [1÷9] =  1 (normale)</p><p>2 (grassetto)</p><p>3 (42 caratteri)</p><p>4 (doppia altezza)</p><p>5 (doppia larghezza)</p><p>6 (corsivo)</p><p>7 (normale/doppia altezza/42 caratteri) 8 (grassetto/42 caratteri)</p><p>9 (grassetto/doppia altezza/42 caratteri)</p>|
|5-6|LUN|2 bytes|LUN = lunghezza (num. bytes) del campo che segue|
|7-38|RIG|0-32 bytes|RIG = testo della riga di descrizione aggiuntiva di un pa- gamento [alfanumerico]|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>010</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:***  Questo comando può essere usato, quando è lecito eseguire la chiusura scontrino. Utile per stampare dati

come n° confezioni, numero/nome operatore, etc. Le righefi sse possono occupare l’intera larghezza dello scontrino.

***Nota:***  I valori di PITCH corrispondenti a 4, 5 e 6 sono presenti nei prodotti fi scali di 1° generazione (dalle

release fi rmware 1.34 e successive) e nei prodotti fi scali di 2° generazione (tutte le release).

***Nota:***  I valori di PITCH corrispondenti a 7, 8, 9 sono presenti solo nei prodotti fi scali di 2° generazione (dalle

release fi rmware 1.14 e successive).

**3011 Chiusura scontrino![](cef2e6c5-b46b-44be-b392-3359776d8743.037.png)**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**011**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>011</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:***  Con questo comando vengono stampate due righe fi sse: la prima riporta la data, l’ora ed il n° di scontrini

fi scali emessi; la seconda il logotipo fi scale ed il n° matricola. Lo scontrino non viene espulso automati- camente.

***Note operative sulla chiusura:***

- La riga di totale pre-impostata, con descrizione, pitch e simboli a destra e/o sinistra dell’importo, viene stampata automaticamente alla prima richiesta di un’operazione come : pagamento, riga aggiuntiva paga- mento, riga fi ssa o chiusura scontrino.
- Se non si usano pagamenti parziali, con il comando di chiusura viene stampato il TOTALE e la chiusura medesima.
- Se si usano pagamenti parziali bisogna raggiungere completamente l’importo, come valore, prima di chiu- dere, eventualmente usando un pagamento con IMPORTO = 0 che viene interpretato come: IMPORTO = RIMANENZA (può essere usato anche come primo ed unico pagamento).
- Se si invia un comando di chiusura senza aver raggiunto l’importo, viene inviato un messaggio di errore.
- Se si invia un altro pagamento, dopo aver coperto l’importo, viene inviato un messaggio di errore.
- Prima della chiusura o della prima riga fi ssa, se sono stati effettuati dei pagamenti, viene automaticamente stampato il RESTO.

**3012 Righe di cortesia![](cef2e6c5-b46b-44be-b392-3359776d8743.038.png)**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**012**|3 bytes|HEADER2: indica la funzione|
|4|PITCH|1 byte|<p>PITCH [1÷9] =  1 (normale)</p><p>2 (grassetto)</p><p>3 (42 caratteri)</p><p>4 (doppia altezza)</p><p>5 (doppia larghezza)</p><p>6 (corsivo)</p><p>7 (normale/doppia altezza/42 caratteri) 8 (grassetto/42 caratteri)</p><p>9 (grassetto/doppia altezza/42 caratteri)</p>|
|5-6|LUN|2 bytes|LUN = lunghezza (num. bytes) del campo che segue|
|7-38|RIG|0-32 bytes|RIG = testo della riga di descrizione aggiuntiva di un pa- gamento [alfanumerico]|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>012</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:***  Questo comando può essere usato solo prima del comando d’espulsione scontrino.

Le righe di cortesia possono occupare l’intera larghezza dello scontrino; tra la riga di logotipo e la prima riga di cortesia sono inserite 2 righe bianche

***Nota:***  I valori di PITCH corrispondenti a 4, 5 e 6 sono presenti nei prodotti fi scali di 1° generazione (dalle

release fi rmware 1.34 e successive) e nei prodotti fi scali di 2° generazione (tutte le release).

***Nota:***  I valori di PITCH corrispondenti a 7, 8, 9 sono presenti solo nei prodotti fi scali di 2° generazione (dalle

release fi rmware 1.14 e successive).

**3013 Espulsione scontrino con taglio parziale ![ref10]**Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**013**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>013</b></td><td colspan="1">3 bytes</td></tr>
</table>
**3014 Espulsione scontrino con taglio parziale e avanzamento carta![ref18]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**014**|3 bytes|HEADER2: indica la funzione|
|4-5|Feed|1 bytes|Numero di avanzamenti carta dopo il taglio da 0 a 9|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>014</b></td><td colspan="1">3 bytes</td></tr>
</table>
**3015 Espulsione scontrino con taglio totale![](cef2e6c5-b46b-44be-b392-3359776d8743.039.png)**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**015**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>015</b></td><td colspan="1">3 bytes</td></tr>
</table>
**3016 Stampa bufferizzata![ref12]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**016**|3 bytes|HEADER2: indica la funzione|
|4|SET|1 bytes|<p>SET = set dove:</p><p>0  Disabilita stampa bufferizzata 1  Abilita stampa bufferizzata</p>|

***Nota:***  Quando viene abilitata la stampa bufferizzata viene emesso un beep, mentre quando viene disabilitata

la stampa bufferizzata vengono emessi due beep.

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>016</b></td><td colspan="1">3 bytes</td></tr>
</table>
**3017 Stampa immagine grafica![ref14]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**017**|3 bytes|HEADER2: indica la funzione|
|4|X|1 bytes|X = Inizio slide [0÷3]|
|5|Y|1 bytes|Y = Numero slide [0÷3]|
|6|Z|1 bytes|Z = Numero logo [1÷2]|

***Nota:***  Questo comando viene accettato solo a scontrino chiuso.

La STAMPANTE FISCALE dispone di due immagini grafi che interne di 608 (L) x 862 (H) pixel a loro volta divisibili in 4 parti stampabili in modo modulare.

*Esempio: 3017121 stampa la seconda e la terza slide del grafi co 1.*

*Le immagini sono immagazzinate tenendo conto di una larghezza teorica di 80 mm.*

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>017</b></td><td colspan="1">3 bytes</td></tr>
</table>
**3020 Forzatura stampa non bufferizzata ![ref10]**Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**020**|3 bytes|HEADER2: indica la funzione|

***Nota:***  Questo comando consente di liberare automaticamente il buffer prima del suo riempimento, in modo

da ottimizzare l’emissione di documenti molto lunghi.

***Nota:***  Questo comando è presente nei prodotti fi scali di 1° generazione (dalle release fi rmware 1.46 e suc-

cessive) e nei prodotti fi scali di 2° generazione (tutte le release).

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>020</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:***  Sui prodotti fi scali di 2° generazione questo comando viene accettato con echo corretto, ma non esegue

l’operazione.

**3021 Stampa barcode interno a scontrino![ref18]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**021**|3 bytes|HEADER2: indica la funzione|
|4|TIP|1 byte|<p>TIP = tipo di barcode [1÷4] dove: 1  (EAN13)</p><p>2  (EAN8)</p><p>3  (CODE39)</p><p>4  (EAN128)</p>|
|5|HRI|1 byte|<p>HRI = Human Readable Interpretation (Codice numerico barcode)</p><p>0  Codice numerico barcode non stampato</p><p>2  Codice numerico barcode stampato sotto </p>|
|6|N/A|1 byte|Riservato per utilizzi futuri|
|7|N/A|1 byte|Riservato per utilizzi futuri|
|8-9|LUN|2 bytes|LUN = lunghezza del codice a barre|
|10-49|Codice|0-40 bytes|Codice numerico barcode|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>021</b></td><td colspan="1">3 bytes</td></tr>
</table>
**3022 Definizione lunghezza stampa bufferizzata![ref12]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1:indica il gruppo di comandi|
|1-3|**017**|3 bytes|HEADER2: indica la funzione|
|4-6|N. RIGHE|3 bytes|N. RIGHE= n° righe del buffer [0÷255]|

***Nota:***  il valore di default del buffer è pari a 50 righe. Con questo comando è possibile defi nire la dimensione

dello spazio di memoria  disponibile per l’acquisizione dei dati. La personalizzazione del buffer viene salvata in EEPROM, quindi rimane settata anche a fronte di un HW-Init o di un upgrade.

***Nota:***  Questo comando è presente nei prodotti fi scali di 1° generazione (dalle release fi rmware 1.46 e suc-

cessive). Sui prodotti fi scali di 2° generazione questo comando viene accettato con echo corretto, ma non esegue l’operazione.

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto Il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>022</b></td><td colspan="1">3 bytes</td></tr>
</table>
**3101 Operazione fiscale su reparto selezionato![ref14]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**101**|3 bytes|HEADER2: indica la funzione|
|4|TIPO|1 byte|<p>TIPO = tipo [1÷9, A] dove:</p><p>1  Vendita articolo su reparto dichiarato 2  Maggiorazioni su reparto dichiarato 3  Sconti su reparto dichiarato</p><p>4  Void</p><p>5  Annullo ultima operazione (solo XG) 8  All void</p><p>9  Resi su reparto dichiarato</p><p>A  Cauzione</p>|
|5-6|REP. MERC|2 bytes|REP. MERC = Reparto merceologico su cui agisce il Tipo 4 [1÷20]|
|7-8|LUNG.DE|2 bytes|LUNG DE = Lunghezza della descrizione del reparto [alfanumerico]|
|9-30|DESCR|22 bytes|DESCR = Descrizione dell’operazione [alfanumerico]|
|31-39|IMP|9 bytes|IMP = Importo dell’operazione  [numerico]|

***Importante:***  All’interno del campo “descrizione” (DESCR) possono essere utilizzati i caratteri che, appar-

tenenti al set ASCII standard, fi no al 125h.

***Nota:***  Il campo “descrizione” (DESCR) non può in nessun caso occupare le stesse colonne delle 5 cifre meno

rilevanti dell’importo, altrimenti verrà troncata. Inoltre descrizione ed importo, o simboli che lo precedono, devono essere separati da almeno uno spazio, in caso contrario l’importo (con simboli) verrà stampato su una seconda riga.

Nel caso di tipo = 4 (void), il campo importo (IMP) deve essere uguale all’importo da stornare. Inoltre, dopo un’operazione “all void” (tipo = 8) se si vuole l’espulsione sono da inviare gli opportuni comandi (3011 e 3013).

Dalla Rel.1.48 della KubeF  è possibile inviare i comandi di tipo = 8 (all void) e di tipo = 4 (void) anche a pagamento iniziato (dai comandi 3004, 3005, 3006) con lo stesso comportamento che si ottiene in fase di vendita. Per cui ora, anche a pagamento iniziato, è possibile eseguire l’annullo totale dello scontrino e l’annullo e dell’ultimo pagamento. Nello specifi co il comando di tipo = 4 (void) quando lo si vuole eseguire per annullare un pagamento richiede in input (campo IMP) il valore del pagamento da annullare: se questo è uguale viene annullato e restituito l’echo,  mentre se questo è diverso viene restituito ERR05.

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto Il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>101</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:***  Al momento le operazioni di vendita possibili sui reparti sono solo quelle di tipo 1,2,3,9.

Alla ricezione della stringa, prima di eseguirne la stampa, si deve controllare che:

- All’interno della descrizione non si trovi la scritta “TOTALE”
- Non sia in corso nessuna operazione o sia in corso uno scontrino fi scale
- L’importo non mandi in overfl ow o in underfl ow i totali dello scontrino, i totali giornalieri ed il totale fi scale progressivo

Se tutte queste condizioni sono verificate, verrà stampata l’operazione, in caso contrario verrà segnalato il tipo di errore. Inoltre, dopo un “all void”, lo scontrino viene automaticamente terminato ed espulso.

**3116 Comando di attivazione buzzer![ref19]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**3**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**116**|3 bytes|HEADER2: indica la funzione|
|4|N. Beep|1 byte|N.Beep = n° di beep emessi [0÷9]|
|5|Nota|1 byte|<p>Nota = Nota musicale [0÷6] dove: 0  DO</p><p>1  RE</p><p>2  MI</p><p>3  FA</p><p>4  SOL</p><p>5  LA</p><p>6  SI</p>|

***Nota:***  Tale comando è presente dalla release fi rmware 1.46 e successive, della stampante KUBE-F.

***Nota:***  Questo comando è presente nei prodotti fi scali di 1° generazione (dalle release fi rmware 1.46 e suc-

cessive) e nei prodotti fi scali di 2° generazione (tutte le release).

Questo comando permette di far emettere alla stampante una segnalazione acustica per attirare l’at- tenzione dell’operatore, a seconda delle necessità operative.

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>3</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>116</b></td><td colspan="1">3 bytes</td></tr>
</table>
**4 GENERAZIONE DI DOCUMENTI NON FISCALI**

**4001 Apertura documento non fiscale![ref8]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**4**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**001**|3 bytes|HEADER2: indica la funzione|
|4|ST|1 byte|ST = stampante/i da usare [1] dove: 1  Scontrino|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>4</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>001</b></td><td colspan="1">3 bytes</td></tr>
</table>
**4002 Stampa intestazione![ref22]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**4**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**002**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>4</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>002</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:*** Esegue la stampa dell’intestazione e viene accettato solo immediatamente dopo il comando di apertura.

**4003 Stampa riga non fiscale![ref23]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**4**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**003**|3 bytes|HEADER2: indica la funzione|
|4|PITCH|1 byte|<p>PITCH [1÷6] =  1 (normale)</p><p>2 (grassetto)</p><p>3 (42 caratteri)</p><p>4 (doppia altezza)</p><p>5 (doppia larghezza) 6 (corsivo)</p>|
|5-6|LUN|2 bytes|LUN = lunghezza (num. bytes) del campo che segue|
|7-48|RIGA|0-42 bytes|RIG = testo della riga [alfanumerico]|

***Nota:***  I valori di PITCH corrispondenti a 4, 5 e 6 sono presenti nei prodotti fi scali di 1° generazione (dalle

release fi rmware 1.34 e successive) e nei prodotti fi scali di 2° generazione (tutte le release).

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>4</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>003</b></td><td colspan="1">3 bytes</td></tr>
</table>
**4004 Chiusura documento non fiscale![ref19]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**4**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**004**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>4</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>004</b></td><td colspan="1">3 bytes</td></tr>
</table>
**Nota:**  Con questo comando vengono stampate le due righe di chiusura:

1° riga = data/ora e n° scontrini non fi scali.

2° riga = scritta “NON FISCALE”

ed eseguita l’espulsione dello scontrino ed il taglio carta.

**4005 Stampa ragione sociale![](cef2e6c5-b46b-44be-b392-3359776d8743.042.png)**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**4**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**005**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>4</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>005</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:*** Viene stampato uno scontrino non fi scale riportante le righe di intestazione programmate.

**5 STAMPA DEL CONTENUTO DELLA MEMORIA FISCALE**

**5001 Stampa chiusure giornaliere per n° d’ordine![ref8]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**5**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**001**|3 bytes|HEADER2: indica la funzione|
|4-7|Ni|4 bytes|Ni = numero d’ordine iniziale [0001÷9999]|
|8-11|Nf|4 bytes|Nf = numero d’ordine fi nale [0001÷9999]|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>5</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>001</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:***  Se i numeri d’ordine sono congruenti, viene stampato uno scontrino fi scale contenente i dati identifi -

cativi dell’utente, i numeri d’ordine iniziale e fi nali impostati, la data e l’importo di ciascun corrispettivo giornaliero, il n° dei corrispettivi stampati e la somma degli stessi, il numero progressivo scontrini fiscali, la data e l’ora di emissione ed il logotipo fi scale.

La stampa termina con il numero d’ordine fi nale, oppure con la stampa dell’ultimo totale effettivamente contenuto nella memoria fi scale.

La sequenza della stampa dei totali può essere interrotta con il comando “INTERRUZIONE STAMPA”.

**5002 Stampa chiusure giornaliere per data![ref24]**

Comando inviato:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>5</b></td><td colspan="1">1 byte</td><td colspan="1">HEADER1: indica il gruppo di comandi</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>002</b></td><td colspan="1">3 bytes</td><td colspan="1">HEADER2: indica la funzione</td></tr>
<tr><td colspan="1">4-5</td><td colspan="1">GGi</td><td colspan="1">2 bytes</td><td colspan="1" rowspan="3">XXi = giorno, mese, anno iniziali</td></tr>
<tr><td colspan="1">6-7</td><td colspan="1">MMi</td><td colspan="1">2 bytes</td></tr>
<tr><td colspan="1">8-9</td><td colspan="1">AAi</td><td colspan="1">2 bytes</td></tr>
<tr><td colspan="1">10-11</td><td colspan="1">GGf</td><td colspan="1">2 bytes</td><td colspan="1" rowspan="3">XXf = giorno, mese, anno fi nali</td></tr>
<tr><td colspan="1">12-13</td><td colspan="1">MMf</td><td colspan="1">2 bytes</td></tr>
<tr><td colspan="1">14-15</td><td colspan="1">AAf</td><td colspan="1">2 bytes</td></tr>
</table>
Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>5</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>002</b></td><td colspan="1">3 bytes</td></tr>
</table>
**Nota:**  Se le date sono congruenti, viene stampato uno scontrino fiscale contenente i dati identificativi dell’utente,

le date iniziale e fi nale impostate, il n° d’ordine, la data e l’importo di ciascun corrispettivo giornaliero, il n° dei corrispettivi stampati e la somma degli stessi, il numero progressivo scontrini fi scali, la data e l’ora d’emissione ed il logotipo fi scale.

La stampa termina al raggiungimento (o superamento) della data fi nale, oppure all’ultimo totale effet- tivamente contenuto nella memoria fi scale.

La sequenza della stampa dei totali può essere interrotta con il comando “INTERRUZIONE STAMPA”.

**5003 Stampa somma chiusure giornaliere per data ![ref10]**Comando inviato:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>5</b></td><td colspan="1">1 byte</td><td colspan="1">HEADER1: indica il gruppo di comandi</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>003</b></td><td colspan="1">3 bytes</td><td colspan="1">HEADER2: indica la funzione</td></tr>
<tr><td colspan="1">4-5</td><td colspan="1">GGi</td><td colspan="1">2 bytes</td><td colspan="1" rowspan="3">XXi = giorno, mese, anno iniziali</td></tr>
<tr><td colspan="1">6-7</td><td colspan="1">MMi</td><td colspan="1">2 bytes</td></tr>
<tr><td colspan="1">8-9</td><td colspan="1">AAi</td><td colspan="1">2 bytes</td></tr>
<tr><td colspan="1">10-11</td><td colspan="1">GGf</td><td colspan="1">2 bytes</td><td colspan="1" rowspan="3">XXf = giorno, mese, anno fi nali</td></tr>
<tr><td colspan="1">12-13</td><td colspan="1">MMf</td><td colspan="1">2 bytes</td></tr>
<tr><td colspan="1">14-15</td><td colspan="1">AAf</td><td colspan="1">2 bytes</td></tr>
</table>
Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>5</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>003</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:***  Se le date sono congruenti, viene stampato uno scontrino fiscale contenente i dati identificativi dell’uten-

te, le date iniziale e fi nale impostate, il n° dei corrispettivi compresi fra le due date e la somma degli stessi, il numero progressivo scontrini fi scali, la data e l’ora di emissione ed il logotipo fi scale.

La stampa termina al raggiungimento della data finale, oppure all’ultimo totale effettivamente contenuto nella memoria fi scale.

La sequenza della stampa dei totali non può essere interrotta.

**5004 Stampa integrale contenuto memoria fiscale![ref25]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**5**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**004**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>5</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>004</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:***  Viene stampato uno scontrino fi scale riportante il contenuto integrale della memoria fi scale (dati iden-

tifi cativi dell’utente, ripristini effettuati, totali giornalieri), il numero progressivo scontrini fi scali, la data e l’ora di emissione ed il logotipo fi scale.

La sequenza della stampa dei totali può essere interrotta con il comando “INTERRUZIONE STAMPA”.

**5005 Comando di interruzione stampa![ref12]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**5**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**005**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>5</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>005</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:***  Quando la Stampante FISCALE riceve questo comando, interrompe la stampa degli scontrini sopra

descritti chiudendo lo scontrino.

**6 IMPOSTAZIONI FORMATI STAMPA**

**6.1 Programmazione ragione sociale**

**6301 Numero max righe da stampare per ragione sociale![](cef2e6c5-b46b-44be-b392-3359776d8743.045.png)**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**6**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**301**|3 bytes|HEADER2: indica la funzione|
|4|NRRS|1 byte|NRRS =n° righe ragione sociale da stampare [0÷6] Se = 0 viene stampato solo il logo|

***Nota:*** Le righe sono stampate anche se bianche. Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>6</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>301</b></td><td colspan="1">3 bytes</td></tr>
</table>
**6302 Programmazione ragione sociale![ref26]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**6**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**302**|3 bytes|HEADER2: indica la funzione|
|4|N. RIGA|1 byte|N. RIGA = Numero riga [1÷6]|
|5|PITCH|1 byte|<p>PITCH [1÷6] =  1 (normale)</p><p>2 (grassetto)</p><p>3 (font 42 caratteri) 4 (doppia altezza)</p><p>5 (doppia larghezza) 6 (corsivo)</p>|
|6-7|LUN|2 bytes|LUN = lunghezza (num. bytes) del campo che segue|
|8-39|RIGA|0-32 bytes|RIGA = testo della riga [alfanumerico]|

***Nota:***  I valori di PITCH corrispondenti a 4, 5 e 6 sono presenti nei prodotti fi scali di 1° generazione (dalle

release fi rmware 1.34 e successive) e nei prodotti fi scali di 2° generazione (tutte le release). Il valore di PITCH corrispondente a 3 è presente solo nei prodotti fi scali di 2° generazione

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>6</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>302</b></td><td colspan="1">3 bytes</td></tr>
</table>
**7 VARIE**

**7001 Avanzamento carta![ref8]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**7**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**001**|3 bytes|HEADER2: indica la funzione|
|4|ST|1 byte|ST = z    Se presente esegue n avanzamenti in stato di idle anche se la stampante è in modalità bufferizzata.|
|5|NAVC|1 byte|NAVC = n° avanzamenti carta [0÷9] dove: 0  non esegue nessun avanzamento|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>7</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>001</b></td><td colspan="1">3 bytes</td></tr>
</table>
**7005 Inizio modalità apprendimento![ref24]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**7**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**005**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>7</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>005</b></td><td colspan="1">3 bytes</td></tr>
</table>
**7006 Fine modalità apprendimento![ref27]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**7**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**006**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>7</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>006</b></td><td colspan="1">3 bytes</td></tr>
</table>
**7007 Visualizzazione su display ![ref10]**Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**7**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**007**|3 bytes|HEADER2: indica la funzione|
|4-43|RIGHE|40 bytes|RIGHE = righe da visualizzare dul display [alfanumerico] I primi 20 bytes sono visualizzati sulla prima riga del display, mentre i successivi 20 sulla seconda.|

***Nota:***  E’ indispensabile per ogni publicazione di messaggi al display inviare tutti i 40 caratteri come da sintassi

di protocollo riempiendo di blank (hex = 20 spazio)

**7008 Apertura cassetto![](cef2e6c5-b46b-44be-b392-3359776d8743.048.png)**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**7**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**008**|3 bytes|HEADER2: indica la funzione|
|4|CASS|1 byte|<p>CASS = “1” per cassetto n. 1</p><p>CASS = “2” per cassetto n. 2 (solo su XG)</p>|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>7</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>008</b></td><td colspan="1">3 bytes</td></tr>
</table>
**7009 Programmazione reparti![ref11]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**7**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**009**|3 bytes|HEADER2: indica la funzione|
|4-5|N.REP|2 bytes|N.REP: Numero del reparto [1-20] Fuori da questi valori ritorna ERR03 |
|6-7|LUN|2 bytes|LUN: Lunghezza in caratteri della descrizione del reparto merceologico [0-16] è consentita anche la lunghezza 00|
|8-23|DESCR|0-16 bytes|DESCR: Descrizione alfanumerica del reparto merceolo- gico che rispetti la lunghezza dichiarata in LUN. (In caso contrario ERR03)|
|24-28|IMP|5 bytes|IMP: Prezzo programmato del reparto merceologico con decimale implicito (Esempio: 00010 = 10 centesimi)|
|29-30|IVA|2 bytes|IVA: Aliquota iva del reparto|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>7</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>009</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:***  Questo comando è valido solo sulla stampante fiscale Kube-F di 1° generazione, attivata nella modalità

FP e non nella modalità ECR.

**8 GESTIONE DEL GIORNALE ELETTRONICO**

**8001 Stampa giornale elettronico da data a data![](cef2e6c5-b46b-44be-b392-3359776d8743.049.png)**

Comando inviato:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>8</b></td><td colspan="1">1 byte</td><td colspan="1">HEADER1: indica il gruppo di comandi</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>001</b></td><td colspan="1">3 bytes</td><td colspan="1">HEADER2: indica la funzione</td></tr>
<tr><td colspan="1">4-5</td><td colspan="1">GGi</td><td colspan="1">2 bytes</td><td colspan="1" rowspan="3">XXi = giorno, mese, anno iniziali</td></tr>
<tr><td colspan="1">6-7</td><td colspan="1">MMi</td><td colspan="1">2 bytes</td></tr>
<tr><td colspan="1">8-9</td><td colspan="1">AAi</td><td colspan="1">2 bytes</td></tr>
<tr><td colspan="1">10-11</td><td colspan="1">GGf</td><td colspan="1">2 bytes</td><td colspan="1" rowspan="3">XXf = giorno, mese, anno fi nali</td></tr>
<tr><td colspan="1">12-13</td><td colspan="1">MMf</td><td colspan="1">2 bytes</td></tr>
<tr><td colspan="1">14-15</td><td colspan="1">AAf</td><td colspan="1">2 bytes</td></tr>
<tr><td colspan="1">16</td><td colspan="1">TI</td><td colspan="1">1 byte</td><td colspan="1">Type = Tipo (ignorato) ‘0’</td></tr>
</table>

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>8</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>001</b></td><td colspan="1">3 bytes</td></tr>
</table>
**8002 Stampa giornale elettronico per data e n° di scontrino![ref11]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**8**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**002**|3 bytes|HEADER2: indica la funzione|
|4-5|GG|2 bytes|GG = Giorno  [01÷31]|
|6-7|MM|2 bytes|MM = Mese  [01÷12]|
|8-9|AA|2 bytes|AA = Anno  [00÷99]|
|10-13|Nsi|4 bytes|Nsi = Numero scontrino iniziale  [0000÷9999]|
|14-17|Nsf|4 bytes|Nsf = Numero scontrino fi nale  [0000÷9999]|
|18|TI|1 byte|Type = Tipo (ignorato) ‘0’|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>8</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>002</b></td><td colspan="1">3 bytes</td></tr>
</table>
**8003 Stampa giornale elettronico da n. chiusura a n. chiusura![ref12]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**8**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**003**|3 bytes|HEADER2: indica la funzione|
|4-7|Nci|4 bytes|Nci = Numero chiusura iniziale|
|8-11|Ncf|4 bytes|Ncf = Numero chiusura fi nale|
|12-15|TI|4 byte|Type = Tipo (ignorato) ‘0000’|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>8</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>003</b></td><td colspan="1">3 bytes</td></tr>
</table>
**8004 Richiesta riga di giornale elettronico![ref21]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**8**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**004**|3 bytes|HEADER2: indica la funzione|
|4-12|NR|9 byte|NR = N° Riga [000000001÷999999999]|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>8</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>004</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4-35</td><td colspan="1">RIGA</td><td colspan="1">32 bytes</td><td colspan="1">RIGA = Testo della riga [alfanumerico]</td></tr>
</table>

**8005 Stampa integrale giornale elettronico![ref27]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**8**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**005**|3 bytes|HEADER2: indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>8</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>005</b></td><td colspan="1">3 bytes</td></tr>
</table>
**8006 Richiesta dati giornale elettronico ![ref10]**Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**8**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**006**|3 bytes|HEADER2: indica la funzione|
|4-7|XXXX|4 bytes|XXXX  = numero chiusura fi scale [0÷9999] dove (0000= corrente)|
|8-11|YYYY|4 bytes|YYYY = numero scontrino iniziale [0÷9999] dove (0000 = primo)|
|12-15|ZZZZ|4 bytes|ZZZZ = numero scontrino fi nale [0÷9999] dove (0000 = ultimo)|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>8</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>006</b></td><td colspan="1">3 bytes</td></tr>
<tr><td colspan="1">4-12</td><td colspan="1">REC INI</td><td colspan="1">9 bytes</td><td colspan="1">REC INI = n° di riga DFGE iniziale richiesta [1÷999999999]</td></tr>
<tr><td colspan="1">13-21</td><td colspan="1">REC.FIN</td><td colspan="1">9 bytes</td><td colspan="1">REC.FIN = n° di riga DFGE fi nale richiesta + 1 [1÷999999999]</td></tr>
<tr><td colspan="1">22-30</td><td colspan="1">REC.CUR</td><td colspan="1">9 bytes</td><td colspan="1">REC.CUR = n° della prossima riga utilizzata dal DGFE [1÷999999999]</td></tr>
<tr><td colspan="1">31-39</td><td colspan="1">REC. TOT</td><td colspan="1">9 bytes</td><td colspan="1">REC. TOT = n° totale di righe DGFE disponibili [1÷999999999]</td></tr>
</table>

**8007 Inizializzazione di un nuovo giornale elettronico![ref13]**

Comando inviato:

|**SEQ. BYTE**|**CONTENUTO**|**LUNGHEZZA**|**NOTE**|
| - | - | - | - |
|0|**8**|1 byte|HEADER1: indica il gruppo di comandi|
|1-3|**007**|3 bytes|HEADER2 : indica la funzione|

Risposta:

<table><tr><th colspan="1"><b>SEQ. BYTE</b></th><th colspan="1"><b>CONTENUTO</b></th><th colspan="1"><b>LUNGHEZZA</b></th><th colspan="1"><b>NOTE</b></th></tr>
<tr><td colspan="1">0</td><td colspan="1"><b>8</b></td><td colspan="1">1 byte</td><td colspan="1" rowspan="2">Nei primi 4 bytes, viene ripetuto il comando inviato</td></tr>
<tr><td colspan="1">1-3</td><td colspan="1"><b>007</b></td><td colspan="1">3 bytes</td></tr>
</table>
***Nota:***  A seguito di questo comando, le istruzioni per il cambio di DGFE sono fornite attraverso stampe non.

fi scali di aiuto, con questa sequenza:

ESTRARRE CARD ESAURITA![](cef2e6c5-b46b-44be-b392-3359776d8743.050.png)

INS.NUOVA CARD E CHIUDERE COVER![](cef2e6c5-b46b-44be-b392-3359776d8743.051.png)

INIZIO PREP. DGFE, ATTENDERE...![](cef2e6c5-b46b-44be-b392-3359776d8743.052.png)

in caso di corretta inizializzazione, il messaggio e’:

CARD DGFE INIZIALIZZATA![](cef2e6c5-b46b-44be-b392-3359776d8743.053.png)

in caso contrario:

CARD DGFE <NON> INIZIALIZZATA![](cef2e6c5-b46b-44be-b392-3359776d8743.054.png)

Si consiglia in quest’ultimo caso di ripetere l’operazione con una nuova card.

**9 ESEMPI**

1. **Scontrino di vendita**

|<p>**Custom Engineering S.p.A. Via Berettine 2/B Fontevivo (PARMA) - ITALY Tel. +39-0521-68011**</p><p>**Fax. +39-0521-610701**</p><p>**EURO**</p>|
| :-: |
|**Reparto 1 10,00**|
|**MAGGIORAZIONE 2,00**|
|**Reparto 2 20,00**|
|**Sconto -1,50**|
|**Reparto 3 20,00**|
|**annullo Reparto 3 -20,00**|
|**Reparto 3 20,00**|
|**riga aggiuntiva**|
|**Sconto -1,50**|
|**ANNULLO OPERAZ. PREC. 1,50**|
|**Reparto 1 10,00**|
|**reso -5,00**|
|**cauzione -3,50**|
|**TOTALE EURO 52,00**|
|**CONTANTI 100,00**|
|**riga aggiuntiva**|
|**RESTO 48,00**|
|<p>**11/07/08  15:12 SF.10**</p><p>***MF*vk 96xxxxxx**</p>|
|**riga di cortesia**|
||

|**3001**1**09**Reparto 1**000001000**|
| - |
|**1001**2**13**Maggiorazione**000000200**|
|**3001**1**09**Reparto 2**000002000**|
|**3001**3**06**Sconto**000000150**|
|**3001**1**09**Reparto 3**000002000**|
|**3001**4**17**annullo Reparto 3**000002000**|
|**3001**1**09**Reparto 3**000002000**|
|**3002**7**15**riga aggiuntiva|
|**3001**3**06**Sconto**000000150**|
|**3001**5**14**annullo sconto**000000150**|
|**3001**1**09**Reparto 1**000001000**|
|**3001**9**04**reso**000000500**|
|**3001**A**08**cauzione**000000350**|

- **3004**08**CONTANTI**000010000
- **3008**8**15**riga aggiuntiva
- **3011**
- **3012**9**16**riga di cortesia
- **3013**

2. **Annullo scontrino**

|<p>**Custom Engineering S.p.A. Via Berettine 2/B Fontevivo (PARMA) - ITALY Tel. +39-0521-68011**</p><p>**Fax. +39-0521-610701**</p><p>**EURO**</p>|
| :-: |
|**articolo 1 10,00**|
|**SUBTOTALE 10,00**|
|**TOTALE EURO 10,00**|
|**CONTANTI 50,00**|
|**annullo scontrino -10,00 ---> TRANSAZIONE ANNULLATA <---**|
|**RESTO 490,00**|
|<p>**11/07/08  15:12 SF.10**</p><p>***MF*vk 96xxxxxx**</p>|
|**riga di cortesia**|
||

- **3001**1**10**articolo 1**000001000![](cef2e6c5-b46b-44be-b392-3359776d8743.055.png)**
- **3003**
- **3004**08**CONTANTI**000005000
- **3001**8**17**annullo scontrino**000000000**
- **3011**
- **3012**9**16**riga di cortesia
- **3013**

55***![ref2]
*PROTOCOLLO CUSTOM*

57***![ref3]

PROTOCOLLO XON/XOFF![ref4]

***KUBE-F THEA-F MAX***

***BIG XTHEA-F XKUBE-F***

*PROTOCOLLO XON/XOFF*

**1 SCOPO ED APPLICABILITÀ**

Scopo del presente documento è quello di illustrare le specifi che relative al protocollo di comunicazione tra stampanti fiscali e HOST generico denominato “XON/XOFF”. Quanto definito nel presente documento si applica a tutti i dispositivi fi scali Custom (dove previsto).

Questo protocollo permette di creare a priori tutti i dati relativi ad operazioni di vendita su un HOST e di trasferirli in blocco al dispositivo fi scale per l’effettiva stampa del documento e per tutti i relativi aggiornamenti fi scali e gestionali.

Il protocollo “XON/XOFF” risulta essere più adatto in tutte quelle comunicazioni con HOST generici o terminali asserviti, governati da sistemi operativi, nei quali, i meccanismi di trasferimento dati via linea seriale, non sono normalmente accessibili in modo semplice, né ai programmatori né agli utenti.

**NOTA![](cef2e6c5-b46b-44be-b392-3359776d8743.056.png)**

**Sulla stampante fiscale VKP80II-XF non è possibile utilizzare il protocollo XON/XOFF.**

**2 FUNZIONALITÀ**

Il protocollo XON/XOFF è un protocollo software utilizzato per regolare lo scambio di dati fra due dispositivi seriali, uno trasmettitore (HOST) ed uno ricevitore (STAMPANTE FISCALE).

Il protocollo prevede la trasmissione da parte del dispositivo HOST di pacchetti di dati congruenti con quanto defi nito nel presente manuale sia a livello sintattico che semantico.

Essendo una comunicazione unidirezionale, durante l’esecuzione dei comandi la stampante fi scale non ha la possibilità di segnalare al dispositivo trasmettitore (HOST) eventuali condizioni di errore generato da comandi o sequenze di comandi errati. In tali casi, le segnalazioni saranno visualizzate a display. Per i dettagli sui mes- saggi di errore consultare il manuale utente del dispositivo fi scale in uso.

La funzionalità di collegamento tramite protocollo XON/XOFF, deve essere esplicitamente programmata sulla stampante fi scale, in quanto la modalità standard di collegamento è impostata su protocollo CUSTOM.

Nello schema seguente è sinteticamente descritto il comportamento della stampante fi scale che è regolato da un fl ag o semaforo che in condizioni di riposo è verde (XON). Se la stampante riceve dal dispositivo HOST i dati da elaborare, ogni dato inviato dalla TASTIERA non può essere elaborato e viceversa. Quando la stampante fi scale è nuovamente in grado di accettare nuovi dati, invia al dispositivo HOST il segnale di semaforo verde (XON) e rimane in attesa di ricevere nuovi dati dalla TASTIERA o dal dispositivo HOST.

SCHEMA:

1. Stato di riposo. Semafori verdi. Entrambi i trasmettitori (HOST o TASTIERA) non stanno inviano dati.
1. La TASTIERA trasmette i dati. Il semaforo del dispositivo HOST diventa rosso. Tutti i dati eventualmente trasmessi dal dispositivo HOST vengo accumulati nel BUFFER.
1. La stampante fi scale ha elaborato i dati inviati dalla TASTIERA. Il semaforo della tastiera diventa rosso. Il semaforo del dispositivo HOST diventa verde e i comandi vengono trasferiti dal buffer alla stampante fiscale. Eventuali dati trasmessi dalla TASTIERA alla stampante fi scale vengono irrimediabilmente perduti.

59***![ref28]
*PROTOCOLLO XON/XOFF*

***1.![](cef2e6c5-b46b-44be-b392-3359776d8743.058.png)***

***HOST TASTIERA***

BUFFER

**STAMPANTE FISCALE**

***2.***

***HOST ![](cef2e6c5-b46b-44be-b392-3359776d8743.059.png)TASTIERA***

BUFFER

**STAMPANTE FISCALE**

***3.***

***HOST ![](cef2e6c5-b46b-44be-b392-3359776d8743.060.png)TASTIERA***

BUFFER

**STAMPANTE FISCALE**

![ref28]
*PROTOCOLLO XON/XOFF*

Nel corso della comunicazione tra dispositivo HOST e stampante fi scale, il buffer di quest’ultima si può fa- cilmente riempire e può verifi carsi la condizione di “buffer-overfl ow” in cui, parte dei dati trasmessi possono andare irrimediabilmente perduti.

Per evitare ciò, viene stabilito un livello di riempimento del buffer (SOGLIA DI SICUREZZA). Quando la quantità di dati ricevuti supera questo livello la stampante fi scale invia al dispositivo HOST il segnale di semaforo rosso (XOFF). Il dispositivo HOST deve concludere la trasmissione del pacchetto di dati in corso e sospendere l’invio di ulteriori dati. Quando il livello dei dati contenuti nel buffer ha raggiunto un livello accettabile il trasferimento dal dispositivo HOST potrà ricomnciare.

Dividendo i dati in pacchetti non superiori a 512 byte si evita la possibilità di perdere irrimediabilmente parte del pacchetto di dati (vedi esempio).

MAX. 512 byte![](cef2e6c5-b46b-44be-b392-3359776d8743.061.png)

<table><tr><th colspan="1" rowspan="5" valign="top">B</th><th colspan="2"></th></tr>
<tr><td colspan="2">![](cef2e6c5-b46b-44be-b392-3359776d8743.062.png)</td></tr>
<tr><td colspan="2">![](cef2e6c5-b46b-44be-b392-3359776d8743.063.png)</td></tr>
<tr><td colspan="2" valign="top"><p>UFFER</p><p>![](cef2e6c5-b46b-44be-b392-3359776d8743.064.png)</p></td></tr>
<tr><td colspan="2" valign="top">![](cef2e6c5-b46b-44be-b392-3359776d8743.065.png)</td></tr>
<tr><td colspan="2"></td><td colspan="2"></td></tr>
</table>

<table><tr><th colspan="1" rowspan="5" valign="top">B</th><th colspan="2" valign="top">![](cef2e6c5-b46b-44be-b392-3359776d8743.066.png)</th></tr>
<tr><td colspan="2">![](cef2e6c5-b46b-44be-b392-3359776d8743.067.png)</td></tr>
<tr><td colspan="2">![](cef2e6c5-b46b-44be-b392-3359776d8743.068.png)</td></tr>
<tr><td colspan="2" valign="top"><p>UFFER</p><p>![](cef2e6c5-b46b-44be-b392-3359776d8743.069.png)</p></td></tr>
<tr><td colspan="2" valign="top">![](cef2e6c5-b46b-44be-b392-3359776d8743.070.png)</td></tr>
<tr><td colspan="2"></td><td colspan="2"></td></tr>
</table>
512 byte![](cef2e6c5-b46b-44be-b392-3359776d8743.071.png)

**SOGLIA DI CISUREZZA**

Semaforo rosso (XOFF) all’HOST![](cef2e6c5-b46b-44be-b392-3359776d8743.072.png)

**ATTENZIONE![](cef2e6c5-b46b-44be-b392-3359776d8743.073.png)**

**È stato definito sulla stampante fiscale, un timeout di comunicazione, ovvero un intervallo di tempo di 4 sec. scaduto il quale, se un comando inviato dall’Host risulta essere incom- pleto, questo viene cancellato e la comunicazione ritorna ad essere libera (ad es. è possibile utilizzare la tastiera).**

**La stampante fiscale può eseguire solo comandi relativi alle funzionalità previste e docu- mentate nel manuale utente o negli add-on che accompagnano le nuove versioni FW. Di seguito verranno elencati tutti i comandi per l’esecuzione delle funzioni disponibili.**

**3 STRUTTURA DEI DATI**

1. **Definizioni – Regole**

Il protocollo XON/XOFF a livello logico prevede una codifi ca “leggera” dei dati e/o dei comandi ricevuti. Non utilizza dati di controllo della validità del pacchetto.

Ogni comando è costituito da una sequenza *CAMPI DATI* seguiti da un *CAMPO TERMINATORE* che definisce univocamente la conclusione del comando secondo la seguente struttura:

**C        O        M        A        N        D        O**

*CAMPO TERMINATORE CAMPO DATI (opzionale)![](cef2e6c5-b46b-44be-b392-3359776d8743.074.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.075.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.076.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.077.png) CAMPO DATI (opzionale) CAMPO DATI (opzionale)*

*(obbligatorio)*

|<attributo>|**<separatore>**|<attributo>|**<separatore>**|<attributo>|**<separatore>**|**<terminatore>**|
| - | - | - | - | - | - | - |

In cui si ha:

*CAMPI DATI* (opzionali):**  <attributo> **+ <separatore>**

dove <attributo> indica una serie di caratteri numerici o alfa- numerici inseriti e **<separatore>** definisce il tipo di valenzaa da assegnare a <attributo> (prezzo, valore, quantità , quantità con decimali, descrizione) (vedi capitolo 4.2).

*CAMPO TERMINATORE* (obbligatorio):   **<terminatore>**

dove **<terminatore>** definisce il tipo di operazione che chiude il comando. (vedi capitolo 4.3)

***Nota:***  Nel seguito i dati verranno rappresentati racchiusi tra i caratteri ‘[‘ ‘]’; tali caratteri non fanno parte dei

dati stessi. Differenti sequenze di input dello stesso tipo saranno invece separate dal carattere ‘/’.

**IMPORTANTE: Tutti i caratteri, costituenti il campo dati, ritenuti validi, appartengono al set ASCII stan-**

**dard compresi tra 20H - 7FH.**

63***![ref28]
*PROTOCOLLO XON/XOFF*

2. **Separatori di campo**

Nella seguente tabella sono elencati tutti i caratteri separatori per la costruzione dei comandi nel protocollo XON/XOFF.

<separatore> FUNZIONE DESCRIZIONE

|**\***|Quantità|*La cifra che lo precede rappresenta una quantità*|
| - | - | - |
|**.**|Quantità decimale|*La cifra che lo precede rappresenta una quantità con decimali*|
|**H**|Prezzo/valore|*La cifra che lo precede rappresenta un valore o un prezzo*|
|<p>**“   “**</p><p>(1)</p>|Descrizione al volo|*Il testo tra i 2 caratteri rappresenta una scritta descrittiva*|

*Esempi:*

![ref3]
*PROTOCOLLO XON/XOFF*
|100|**\***|
| - | - |

|100\.25|**\***|
| - | - |

|1000|**H**|
| - | - |

|100000|**H**|
| - | - |

|**“**|ART.N.1|**“**|
| - | - | - |

|**“**|~TOT.~|**“**|
| - | - | - |

*moltiplicazione per 100*

*moltiplicazione per 100.25 prezzo/valore uguale a 1000 prezzo/valore uguale a 100000*

*scritta ART.N.1*

*scritta TOT. stampata in doppia altezza*

![ref3]
*PROTOCOLLO XON/XOFF*

***Note (1):*** la massima lunghezza del campo descrizione è di 22 caratteri; il campo descrizione può contenere

caratteri ALFANUMERICI.

***Note(1):*** Il campo descrizione può essere stampato in modalità doppia altezza inserendo il carattere ‘~’ all’ini-

zio della stringa per attivare tale modalità; al successivo carattere ‘~’ la modalità doppia altezza verrà disattivata. Per digitare il carattere ‘~’ (ALT+126) mantenere premuto il tasto ALT e premere contem- poraneamente in sequenza i tasti 1 2 6 .

![ref3]
*PROTOCOLLO XON/XOFF*

3. **Terminatori di comando**

Nella seguente tabella sono elencati tutti i caratteri terminatori per la costruzione dei comandi nel protocollo XON/XOFF.

<terminatore> FUNZIONE

|**=**|Subtotale|
| - | - |
|<p>**#**</p><p>``(1)</p>|Stampa codice numerico non sommante|
|<p>**@**</p><p>``(2)</p>|Stampa messaggio alfanumerico|
|**1%**|Visualizza la descrizione sulla prima riga del customer display|
|**2%**|Visualizza la descrizione sulla seconda riga del customer display|
|**a**|Apertura cassetto|
|**1f**|Rendiconto report fi scale giornaliero senza azzeramento|
|**2f**|Rendiconto report reparti senza azzeramento|
|**3f**|Rendiconto report PLU senza azzeramento|
|**4f**|Rendiconto report Operatori senza azzeramento|
|**5f**|Rendiconto report Tavoli senza azzeramento *(dove previsto)*|
|**6f**|Rendiconto report Clienti senza azzeramento|
|**7f**|Rendiconto report Convenzioni senza azzeramento *(dove previsto)*|
|**8f**|Rendiconto report fi nanziario|
|**j**|Apertura scontrino non fi scale|
|**k**|Annullo scontrino|
|**1w**|Dump memoria fi scale totale|
|**2w**|Dump memoria fi scale per data|
|**3w**|Dump memoria fi scale per numero|
|**4w**|Dump giornale totale|
|**5w**|Dump giornale per data|
|**6w**|Dump giornale per numero|
|**7w**|Termina dump|
|**D**|Imposta data/ora|
|**1F**|Azzeramento report fi scale giornaliero|
|**2F**|Azzeramento report reparti|
|**3F**|Azzeramento report PLU|
|**4F**|Azzeramento report Operatori|
|**5F**|Azzeramento report Tavoli *(dove previsto)*|
|||

``***65***![ref6]***
*PROTOCOLLO XON/XOFF*

<terminatore> FUNZIONE

|**6F**|Azzeramento report Clienti|
| - | - |
|**7F**|Azzeramento report Convenzioni*(dove previsto)*|
|**8F**|Azzeramento report fi nanziario|
|**39F**|Stampa Codice Fiscale / Partita IVA cliente|
|**40F**|Stampa messaggio di cortesia a fi ne scontrino|
|**J**|Chiusura scontrino non fi scale|
|**K**|Clear|
|**0M**|Modifi catore storno|
|**1M**|Modifi catore sconto % su transazione articolo|
|**2M**|Modifi catore sconto % su subtotale|
|**3M**|Modifi catore sconto a valore su transazione articolo|
|**4M**|Modifi catore sconto a valore su subtotale|
|**5M**|Modifi catore maggiorazione % su transazione articolo|
|**6M**|Modifi catore maggiorazione % su subtotale|
|**7M**|Modifi catore maggiorazione a valore su transazione articolo|
|**8M**|Modifi catore maggiorazione a valore su subtotale|
|**9M**|Reso|
|**10M**|Cauzione|
|**12M**|Chiusura a credito|
|**O**|Selezione operatore|
|**P**|Vendita a PLU|
|**R**|Vendita a REPARTO|
|**1T**|Pagamento (tender) con contante|
|**2T**|Pagamento (tender) con assegno|
|**3T**|Pagamento (tender) con carta elettronica|
|**4T**|Pagamento (tender) con credito|
|**5T**|Pagamento (tender) con buono pasto|
|**6T**|Pagamento (tender) con sospensione|
|**7T**|Pagamento (tender) con pagamento generico|
|**21T**|Pagamento (tender) con buono pasto e calcolo del resto (*solo per modelli FP*)|
|**22T**|Pagamento (tender) con buono pasto e calcolo del resto (*solo per modelli ECR*)|
|**Y**|Restituisce il controllo della transazione alla tastiera|
|**1Z**|Stampa BARCODE EAN13|
|||

``***![ref7]***
*PROTOCOLLO XON/XOFF*

<terminatore> FUNZIONE![ref5]

**2Z** Stampa BARCODE EAN8 **3Z** Stampa BARCODE CODE39![ref1]

1) **Restrizioni:** • La stampa del codice numerico può essere eseguita solo a scontrino già aperto.
   1. La massima lunghezza del codice numerico è di 20 cifre.
1) **Restrizioni:** • La stampa del codice numerico può essere eseguita solo a scontrino già aperto, quindi, non come prima operazione.

- La massima lunghezza del codice numerico è di 20 cifre, di cui 19 defi niti dall’utente e 1 fi sso (# = carattere di fi ne codice) inserito dal registratore di cassa.
- I caratteri bianchi in fondo al codice vengono automaticamente scartati
- **Subtotale![ref10]**

Stampa un riga con il totale delle vendite effettuate fi no a quel momento senza chiudere lo scontrino.

- **Stampa codice numerico non sommante![](cef2e6c5-b46b-44be-b392-3359776d8743.078.png)**

Stampa una riga con il numero che precede il carattere [ # ] senza considerarlo vendita.

*Esempio di comando:* 1000 **#![](cef2e6c5-b46b-44be-b392-3359776d8743.079.png)**

*Risultato sullo scontrino:*

**EURO ![](cef2e6c5-b46b-44be-b392-3359776d8743.080.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.081.png)1 REP1 8,00 1 PLU3 5,00 #1000**

- **Stampa messaggio alfanumerico![](cef2e6c5-b46b-44be-b392-3359776d8743.082.png)**

Stampa una riga sul fondo dello scontrino con il testo che precede il carattere [ @ ] senza considerarlo ven- dita.

*Esempio di comando:*

|**“**|123456|**“**|**@**|
| - | - | - | - |

*Risultato sullo scontrino:*

**TOTALE EURO 13,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.083.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.084.png)**

**CONTANTI 13,00 RESTO 0,00 123456**

**1%  Visualizza la descrizione sulla prima riga del customer display![ref12]**

Scrive sulla prima riga del customer display il testo che precede il carattere [ # ]. Il testo rimane visualizzato sul display fi no a quando non viene sovrascritto da un nuovo messaggio.

*Esempio di comando:*

|**“**|TEST|**“**|**1%**|
| - | - | - | - |

*Risultato sul customer display:*

TEST![](cef2e6c5-b46b-44be-b392-3359776d8743.085.png)

**2%  Visualizza la descrizione sulla seconda riga del customer display![ref20]**

Scrive sulla seconda riga del customer display il testo che precede il carattere [ # ]. Il testo rimane visualizzato sul display fi no a quando non viene sovrascritto da un nuovo messaggio.

*Esempio di comando:*

|**“**|TEST|**“**|**2%**|
| - | - | - | - |

*Risultato sul customer display:*

TEST![](cef2e6c5-b46b-44be-b392-3359776d8743.086.png)

**a  Apertura cassetto![](cef2e6c5-b46b-44be-b392-3359776d8743.087.png)**

Invia al registratore di casa il segnale di apertura cassetto.

**j  Apertura scontrino non fiscale![ref10]**

Concordemente con la defi nizione di operazione di tipo “non fi scale” prevista dalla legge fi scale vigente in Italia, è possibile gestire da Host scontrini non fi scali contenenti stampe di messaggi di contenuto generico. La suddetta legge vieta la stampa della dicitura “TOTALE” in qualsiasi condizione essa venga richiesta all’interno di uno scontrino non fi scale: le stampanti fiscali Custom controllano tutto ciò annullando la stampa di messaggi contenenti la dicitura stessa. La sequenza di gestione prevede i seguenti comandi:

1. Apertura scontrino non fi scale  [ j ]
1. Stampe di messaggi generici  [ @ ]
1. Chiusura di scontrino non fi scale  [ J ] *Esempio di comando:*

|**“**|123456|**“**|**@**|
| - | - | - | - |

**j**

**J![](cef2e6c5-b46b-44be-b392-3359776d8743.088.png)![ref29]**

*Risultato sullo scontrino:*

**NON FISCALE ![](cef2e6c5-b46b-44be-b392-3359776d8743.090.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.091.png)123456**

**NON FISCALE**

**k  Annullo scontrino![ref18]**

Annulla le vendite inserite e stampa comunque lo scontrino con il totale a 0 e la dicitura “TRANSAZIONE CANCELLATA”.

*Esempio di comando:*

**k![](cef2e6c5-b46b-44be-b392-3359776d8743.092.png)**

*Risultato sullo scontrino:*

**1 REP1 8,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.093.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.094.png)1 PLU3 5,00 ANNULLO TRANSAZIONE 13,00 --->  TRANSAZIONE ANNULLATA  <---**

**TOTALE EURO 0,00**

***Note:***  quando sulla stampante fi scale è impostata la *STAMPA BUFFERIZZATA* e l’opzione “*STAMPA SCON-*

*TRINO FISCALE ANNULLATO*” è abilitata, il terminatore [ k ] non produce lo scontrino annullato.

**1w  Dump memoria fiscale totale![ref12]**

Stampa l’intero contenuto della memoria fi scale. *Esempio di comando:*

**1w![ref30]**

**2w  Dump memoria fiscale per data![ref20]**

Stampa il contenuto della memoria fi scale compreso tra due date. La sequenza del comando prevede l’inseri- mento della data di inizio e la data di fi ne nel formato DDMMYY tra i separatori “ “ seguito dal terminatore.

*Esempio di stampa dal 1 gennaio 2008 al 2 gennaio 2008:*

|**“**|010108020108|**“**|**2w**|
| - | - | - | - |

**3w  Dump memoria fiscale per numero![ref31]**

Stampa il contenuto della memoria fi scale compreso tra due numeri di scontrino. La sequenza del comando prevede l’inserimento del numero di scontrino di inizio e quello di fi ne nel formato nnnnNNNN tra i separatori “ “ seguito dal terminatore.

*Esempio di stampa dallo scontrino numero 0001 allo scontrino numero 0002:*

|**“**|00010002|**“**|**3w**|
| - | - | - | - |

**4w  Dump giornale totale![](cef2e6c5-b46b-44be-b392-3359776d8743.097.png)**

Stampa l’intero contenuto del DGFE. *Esempio di comando:*

**4w![ref32]**

**5w  Dump giornale per data![ref10]**

Stampa il contenuto del DGFE compreso tra due date. La sequenza del comando prevede l’inserimento della data di inizio e la data di fi ne nel formato DDMMYY tra i separatori “ “ seguito dal terminatore.

*Esempio di stampa dal 1 gennaio 2008 al 2 gennaio 2008:*

|**“**|010108020108|**“**|**5w**|
| - | - | - | - |

**6w  Dump giornale per numero![ref18]**

Stampa il contenuto del DGFE compreso tra due numeri di scontrino. La sequenza del comando prevede l’inserimento del numero di scontrino di inizio e quello di fi ne nel formato nnnnNNNN tra i separatori “ “ seguito dal terminatore.

*Esempio di stampa dallo scontrino numero 0001 allo scontrino numero 0002:*

|**“**|00010002|**“**|**6w**|
| - | - | - | - |

**7w  Termina dump![ref33]**

Termina istantaneamente la stampa del dump in corso. *Esempio di comando:*

**7w![](cef2e6c5-b46b-44be-b392-3359776d8743.100.png)**

**D  Imposta data/ora![ref16]**

Esegue il cambio di data e ora stampando uno scontrino NON FISCALE di conferma. La sequenza del comando prevede l’inserimento della data e l’ora nel formato DDMMYYhhmm tra i separatori “ “ seguito dal terminatore [D].

*Esempio di comando:*

|**“**|0101081200|**“**|**D**|
| - | - | - | - |

*Risultato sullo scontrino:*

**NON FISCALE ![](cef2e6c5-b46b-44be-b392-3359776d8743.101.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.102.png)NUOVA DATA SETTATA: 01/01/08  12:00**

**01/01/08  12:00 SNF.1**

**NON FISCALE**

**39F  Stampa Codice Fiscale / Partita IVA cliente![](cef2e6c5-b46b-44be-b392-3359776d8743.103.png)**

Stampa a fi ne scontrino il Codice Fiscale o la Partita IVA del cliente. La sequenza è la seguente:

1. Messaggio alfanumerico con Codice Fiscale o Partita IVA  [ @ ]
1. Stampa del messaggio alfanumerico come Codice Fiscale o Partita IVA  [ 39F ]

*Esempio di comando:*

|**“**|12312312312|**“**|**@**|
| - | - | - | - |

**39F![ref29]**

*Risultato sullo scontrino:*

**TOTALE EURO 13,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.104.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.105.png)**

**CONTANTI 13,00 RESTO 0,00**

**CF/PI: 12312312312**

***Note:***  il messaggio alfanumerico che defi nisce il Codice Fiscale o la Partita IVA deve essere costituito da 11 o

16 caratteri. Qualora il messaggio alfanumeirco non rispetti la regola appena descritta verrà considerato un normale messaggio generico.

**40F  Stampa messaggio di cortesia a fine scontrino![ref17]**

Stampa a fi ne scontrino un messaggio di cortesia. La sequenza è la seguente:

1. Messaggio alfanumerico  [ @ ]
1. Stampa del messaggio alfanumerico come messaggio di cortesia  [ 40F ]

*Esempio di comando:*

|**“**|TEST TEST TEST TEST|**“**|**@**|
| - | - | - | - |

**40F![](cef2e6c5-b46b-44be-b392-3359776d8743.106.png)**

*Risultato sullo scontrino:*

**TOTALE EURO 13,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.107.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.108.png)**

**CONTANTI 13,00 RESTO 0,00**

**TEST TEST TEST TEST**

***Note:***  il messaggio di cortesia deve essere costituito da max. 42 caratteri per riga per max. 20 righe. Le righe

eccedenti la 20 sovrascrivono quelle già inserite a partire dalla prima.

Il comando deve essere inserito prima della chiusura.

Il messaggio di cortesia viene stampato solamente sullo scontrino della transazione in corso.

**J  Chiusura scontrino non fiscale![](cef2e6c5-b46b-44be-b392-3359776d8743.109.png)**

|<p>Vedi descrizione del terminatore [ j ].</p><p>**K  Clear![](cef2e6c5-b46b-44be-b392-3359776d8743.110.png)**</p>|
| - |
|<p>Cancella l’importo appena inserito. Ha la medesima funzione deltasto “C” della tastiera operatore.</p><p>**0M  Modificatore storno![](cef2e6c5-b46b-44be-b392-3359776d8743.111.png)**</p>|

Esegue la sottrazione di un determinato importo allo scontrino corrente. La sequenza del comando prevede l’inser imento del modifi catore di storno [ 0M ] seguito dalle indicazioni della vendita da sottrarre. Quest’ultima può essere inserita utilizzando varie modalità illustrate negli esempi seguenti.

*Esempio di storno di PLU3 con prezzo di default e quantità unitaria:*

|**0M**|3|**P**|
| - | - | - |

*Risultato sullo scontrino:*

**REP1 8,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.112.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.113.png)PLU3 5,00 PLU3 -5,00**

*Esempio di storno di PLU3 con prezzo imposto e quantità unitaria:*

|**0M**|200|**H**|3|**P**|
| - | - | - | - | - |

*Risultato sullo scontrino:*

**REP1 8,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.114.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.115.png)PLU3 5,00 PLU3 -2,00**

*Esempio di storno di PLU3 con prezzo di default e quantità intera:*

|**0M**|2|**\***|3|**P**|
| - | - | - | - | - |

*Risultato sullo scontrino:*

**3 REP1 8,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.116.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.117.png)5 PLU3 5,00 2 PLU3 -4,00**

**1M  Modificatore sconto % su transazione articolo![ref12]**

Esegue la sottrazione di un valore percentuale sull’articolo inserito. La sequenza del comando prevede l’inse- rimento del valore percentuale seguito dal separatore [ \* ] e dal modifi catore di sconto % [1M].

*Esempio di sconto del 25% sulla transazione di PLU3:*

|3|**P**|
| - | - |

|25|**\***|**1M**|
| - | - | - |

*Risultato sullo scontrino:*

**REP1 8,00 ![ref34]![ref35]PLU3 10,00 25% SC(%) ART. -2,5**

**2M  Modificatore sconto % su subtotale![ref36]**

Esegue la sottrazione di un valore percentuale sul subtotale. La sequenza del comando prevede l’inserimento del valore percentuale seguito dal separatore [ \* ] e dal modifi catore di sconto % [2M].

*Esempio di sconto del 25% sul SUBTOTALE.*

|25|**\***|**2M**|
| - | - | - |

**=![ref37]**

*Risultato sullo scontrino:*

**REP1 10,00 ![ref38]![ref39]PLU3 10,00 SUBTOTALE 20,00 25% SC(%) SBTL. -5,00**

**3M  Modificatore sconto a valore su transazione articolo![ref31]**

Esegue la sottrazione di un valore numerico sull’articolo inserito. La sequenza del comando prevede l’inseri- mento del valore numerico seguito dal separatore [ H ] e dal modifi catore di sconto % [3M].

*Esempio di sconto di 5 euro sulla transazione di PLU3*

|3|**P**|
| - | - |

|500|**H**|**3M**|
| - | - | - |

*Risultato sullo scontrino:*

**REP1 10,00 ![ref40]![ref41]PLU3 10,00 SC(VAL) ART. -5,00**

**4M  Modificatore sconto a valore su subtotale![ref10]**

Esegue la sottrazione di un valore numerico sul subtotale. La sequenza del comando prevede l’inserimento del valore numerico seguito dal separatore [ H ] e dal modifi catore di sconto % [4M].

*Esempio di sconto di 5 euro sul SUBTOTALE.*

|500|**H**|**4M**|
| - | - | - |

**=![](cef2e6c5-b46b-44be-b392-3359776d8743.126.png)**

*Risultato sullo scontrino:*

**REP1 10,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.127.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.128.png)PLU3 10,00 SUBTOTALE 20,00 ABBUONO -5,00**

**5M  Modificatore maggiorazione % su transazione articolo![ref25]**

Esegue l’addizione di un valore percentuale sull’articolo inserito. La sequenza del comando prevede l’inserimento del valore percentuale seguito dal separatore [ \* ] e dal modifi catore di maggiorazione % [5M].

*Esempio di maggiorazione del 25% sulla transazione di PLU3:*

|3|**P**|
| - | - |

|25|**\***|**5M**|
| - | - | - |

*Risultato sullo scontrino:*

**REP1 8,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.129.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.130.png)PLU3 10,00 25% MAGG(%) ART. 2,5**

**6M  Modificatore maggiorazione % su subtotale![ref33]**

Esegue l’addizione di un valore percentuale sul subtotale. La sequenza del comando prevede l’inserimento del valore percentuale seguito dal separatore [ \* ] e dal modifi catore di maggiorazione % [6M].

*Esempio di maggiorazione del 25% sul SUBTOTALE.*

|25|**\***|**6M**|
| - | - | - |

**=![](cef2e6c5-b46b-44be-b392-3359776d8743.131.png)**

*Risultato sullo scontrino:*

**REP1 10,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.132.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.133.png)PLU3 10,00 SUBTOTALE 20,00 25% MAGG(%) SBTL. -5,00**

**7M  Modificatore maggiorazione a valore su transazione articolo![ref12]**

Esegue l’addizione di un valore numerico sull’articolo inserito. La sequenza del comando prevede l’inserimento del valore numerico seguito dal separatore [ H ] e dal modifi catore di maggiorazione % [7M].

*Esempio di maggiorazione di 5 euro sulla transazione di PLU3*

|3|**P**|
| - | - |

|500|**H**|**7M**|
| - | - | - |

*Risultato sullo scontrino:*

**REP1 10,00 ![ref34]![ref35]PLU3 10,00 MAGG(VAL) ART. 5,00**

**8M  Modificatore maggiorazione a valore su subtotale![ref36]**

Esegue l’addizione di un valore numerico sul subtotale. La sequenza del comando prevede l’inserimento del valore numerico seguito dal separatore [ H ] e dal modifi catore di maggiorazione % [8M].

*Esempio di maggiorazione di 5 euro sul SUBTOTALE.*

|500|**H**|**8M**|
| - | - | - |

**=![ref37]**

*Risultato sullo scontrino:*

**REP1 10,00 ![ref38]![ref39]PLU3 10,00 SUBTOTALE 20,00 MAGG(VAL) SBTL. 5,00**

**9M  Modificatore reso![ref31]**

Esegue la sottrazione di una vendita effettuata in precedenza scontrino corrente. La sequenza del comando prevede l’inserimento del modifi catore di reso [9M] seguito dalle indicazioni della vendita da sottrarre. Quest’ul- tima  può essere inserita utilizzando varie modalità illustrate negli esempi seguenti.

*Esempio di reso di PLU3 con prezzo di default e quantità unitaria:*

|**9M**|3|**P**|
| - | - | - |

*Risultato sullo scontrino:*

**REP1 8,00 ![ref40]![ref41]PLU3 5,00 PLU3 -5,00**

*Esempio di reso di PLU3 con prezzo imposto e quantità unitaria:*

|**9M**|200|**H**|3|**P**|
| - | - | - | - | - |

*Risultato sullo scontrino:*

**REP1 8,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.134.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.135.png)PLU3 5,00 PLU3 -2,00**

*Esempio di reso di PLU3 con prezzo di default e quantità intera:*

|**9M**|2|**\***|3|**P**|
| - | - | - | - | - |

*Risultato sullo scontrino:*

**3 REP1 8,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.136.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.137.png)5 PLU3 5,00 2 PLU3 -4,00**

**10M  Cauzione![ref42]**

Esegue la sottrazione di una vendita effettuata in precedenza scontrino corrente. La sequenza del comando prevede l’inserimento della cauzione [10M] seguito dalle indicazioni della vendita da sottrarre. Quest’ultima può essere inserita utilizzando varie modalità illustrate negli esempi seguenti.

*Esempio di cauzione di PLU3 con prezzo di default e quantità unitaria:*

|**10M**|3|**P**|
| - | - | - |

*Risultato sullo scontrino:*

**REP1 8,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.139.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.140.png)PLU3 5,00 PLU3 -5,00**

*Esempio di cauzione di PLU3 con prezzo imposto e quantità unitaria:*

|**10M**|200|**H**|3|**P**|
| - | - | - | - | - |

*Risultato sullo scontrino:*

**REP1 8,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.141.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.142.png)PLU3 5,00 PLU3 -2,00**

*Esempio di cauzione di PLU3 con prezzo di default e quantità intera:*

|**10M**|2|**\***|3|**P**|
| - | - | - | - | - |

*Risultato sullo scontrino:*

**3 REP1 8,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.143.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.144.png)5 PLU3 5,00 2 PLU3 -4,00**

**12M  Chiusura a credito![ref23]**

Esegue la chiusura dello scontrino fi scale mediante un pagamento con credito. Il pagamento con credito può essere inserito utilizzando varie modalità illustrate negli esempi seguenti.

*Esempio di pagamento con credito senza calcolo del resto:*

**12M![](cef2e6c5-b46b-44be-b392-3359776d8743.145.png)**

*Risultato sullo scontrino:* **------------------------------------ ![](cef2e6c5-b46b-44be-b392-3359776d8743.146.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.147.png)**

**TOTALE EURO 13,00**

**CREDITO 13,00 RESTO 0,00**

*Esempio di pagamento con 2 euro a credito e il restante in contanti:*

|200|**H**|**12M**|
| - | - | - |

**12M![](cef2e6c5-b46b-44be-b392-3359776d8743.148.png)**

*Risultato sullo scontrino:* **------------------------------------ ![](cef2e6c5-b46b-44be-b392-3359776d8743.149.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.150.png)**

**TOTALE EURO 13,00**

**CREDITO 2,00 CONTANTI 11,00 RESTO 0,00**

**O  Selezione operatore![](cef2e6c5-b46b-44be-b392-3359776d8743.151.png)**

Permette di selezionare l’operatore che effettuerà la vendita, stampando il numero operatore in testa allo scontrino fi scale.

*Esempio di comando:*

1 **O![](cef2e6c5-b46b-44be-b392-3359776d8743.152.png)**

*Risultato sullo scontrino:* **OPERATORE 1 ![](cef2e6c5-b46b-44be-b392-3359776d8743.153.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.154.png)**

**EURO 1 REP1 8,00 1 PLU3 5,00**

***Note:***  se l’operatore selezionato non è stato impostato, sul display viene visualizzato un messaggio d’errore.

**P  Vendita a PLU![ref26]**

Esegue una vendita su PLU. La vendita su PLU può essere inserita utilizzando varie modalità illustrate negli esempi seguenti.

*Esempio di comando vendita PLU con descrizione e prezzo di default, quantità unitaria:*

1 **P![](cef2e6c5-b46b-44be-b392-3359776d8743.155.png)**

*Risultato sullo scontrino:*

**EURO ![](cef2e6c5-b46b-44be-b392-3359776d8743.156.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.157.png)PLU1 8,00**

*Esempio di comando vendita PLU con descrizione e prezzo di default, quantità intera:*

|5|**\***|1|**P**|
| - | - | - | - |

*Risultato sullo scontrino:*

**EURO ![](cef2e6c5-b46b-44be-b392-3359776d8743.158.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.159.png)5 PLU1 8,00**

*Esempio di comando vendita PLU con descrizione e prezzo di default, quantità decimale:*

|5|**.**|25|**\***|1|**P**|
| - | - | - | - | - | - |

*Risultato sullo scontrino:*

**EURO ![](cef2e6c5-b46b-44be-b392-3359776d8743.160.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.161.png)**

**5.25 PLU1 8,00**

*Esempio di comando vendita PLU con descrizione, prezzo imposto, quantità intera:*

|1000|**H**|1|**P**|
| - | - | - | - |

*Risultato sullo scontrino:*

**EURO ![](cef2e6c5-b46b-44be-b392-3359776d8743.162.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.163.png)PLU1 10,00**

*Esempio di comando vendita PLU con descrizione, prezzo imposto, quantità decimale:*

|1025|**H**|1|**P**|
| - | - | - | - |

*Risultato sullo scontrino:*

**EURO ![](cef2e6c5-b46b-44be-b392-3359776d8743.164.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.165.png)PLU1 10,25**

*Esempio di comando vendita PLU con descrizione imposta, prezzo imposto, quantità intera:*

|**“**|MARGHERITA|**“**|5|**\***|1000|**H**|1|**P**|
| - | - | - | - | - | - | - | - | - |

*Risultato sullo scontrino:*

**EURO ![](cef2e6c5-b46b-44be-b392-3359776d8743.166.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.167.png)5 MARGHERITA 10,00**

**R  Vendita a REPARTO![ref23]**

Esegue una vendita su REPARTO. La vendita su REPARTO può essere inserita utilizzando varie modalità illustrate negli esempi seguenti.

*Esempio di comando vendita REPARTO con descrizione e prezzo di default, quantità unitaria:*

1 **R![](cef2e6c5-b46b-44be-b392-3359776d8743.168.png)**

*Risultato sullo scontrino:*

**EURO ![](cef2e6c5-b46b-44be-b392-3359776d8743.169.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.170.png)REP1 8,00**

*Esempio di comando vendita REPARTO con descrizione e prezzo di default, quantità intera:*

|5|**\***|1|**R**|
| - | - | - | - |

*Risultato sullo scontrino:*

**EURO ![](cef2e6c5-b46b-44be-b392-3359776d8743.171.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.172.png)5 REP1 8,00**

*Esempio di comando vendita REPARTO con descrizione e prezzo di default, quantità decimale:*

|5|**.**|25|**\***|1|**R**|
| - | - | - | - | - | - |

*Risultato sullo scontrino:*

**EURO ![](cef2e6c5-b46b-44be-b392-3359776d8743.173.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.174.png)**

**5.25 REP1 8,00**

*Esempio di comando vendita REPARTO con descrizione, prezzo imposto, quantità intera:*

|1000|**H**|1|**R**|
| - | - | - | - |

*Risultato sullo scontrino:*

**EURO ![](cef2e6c5-b46b-44be-b392-3359776d8743.175.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.176.png)REP1 10,00**

*Esempio di comando vendita REPARTO con descrizione, prezzo imposto, quantità decimale:*

|1025|**H**|1|**R**|
| - | - | - | - |

*Risultato sullo scontrino:*

**EURO ![](cef2e6c5-b46b-44be-b392-3359776d8743.177.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.178.png)REP1 10,25**

*Esempio di comando vendita REPARTO con descrizione imposta, prezzo imposto, quantità intera:*

|**“**|MARGHERITA|**“**|5|**\***|1000|**H**|1|**R**|
| - | - | - | - | - | - | - | - | - |

*Risultato sullo scontrino:*

**EURO ![](cef2e6c5-b46b-44be-b392-3359776d8743.179.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.180.png)5 MARGHERITA 10,00**

**1T  Pagamento (tender) con contante![ref42]**

Esegue la chiusura dello scontrino fi scale mediante un pagamento in contanti. Il pagamento in contanti può essere inserito utilizzando varie modalità illustrate negli esempi seguenti.

*Esempio di pagamento con contanti senza calcolo del resto:*

**1T![](cef2e6c5-b46b-44be-b392-3359776d8743.181.png)**

*Risultato sullo scontrino:* **------------------------------------ ![](cef2e6c5-b46b-44be-b392-3359776d8743.182.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.183.png)**

**TOTALE EURO 13,00**

**CONTANTI 13,00 RESTO 0,00**

*Esempio di pagamento con contanti con calcolo del resto:*

|2000|**H**|**1T**|
| - | - | - |

*Risultato sullo scontrino:* **------------------------------------ ![](cef2e6c5-b46b-44be-b392-3359776d8743.184.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.185.png)**

**TOTALE EURO 13,00**

**CONTANTI 20,00 RESTO 7,00**

**2T  Pagamento (tender) con assegno![](cef2e6c5-b46b-44be-b392-3359776d8743.186.png)**

Esegue la chiusura dello scontrino fi scale mediante un pagamento con assegno. Il pagamento con assegno può essere inserito utilizzando varie modalità illustrate negli esempi seguenti.

*Esempio di pagamento con assegno senza calcolo del resto:*

**2T![](cef2e6c5-b46b-44be-b392-3359776d8743.187.png)**

*Risultato sullo scontrino:* **------------------------------------ ![](cef2e6c5-b46b-44be-b392-3359776d8743.188.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.189.png)**

**TOTALE EURO 13,00**

**ASSEGNI 13,00 RESTO 0,00**

*Esempio di pagamento con assegno con calcolo del resto:*

|2000|**H**|**2T**|
| - | - | - |

*Risultato sullo scontrino:* **------------------------------------ ![](cef2e6c5-b46b-44be-b392-3359776d8743.190.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.191.png)**

**TOTALE EURO 13,00**

**ASSEGNI 20,00 RESTO 7,00**

**3T  Pagamento (tender) con carta elettronica![ref23]**

Esegue la chiusura dello scontrino fiscale mediante un pagamento con carta elettronica. Il pagamento con carta elettronica può essere inserito utilizzando varie modalità illustrate negli esempi seguenti.

*Esempio di pagamento con carta elettronica senza calcolo del resto:*

**3T![](cef2e6c5-b46b-44be-b392-3359776d8743.192.png)**

*Risultato sullo scontrino:* **------------------------------------ ![ref43]![ref44]**

**TOTALE EURO 13,00**

**CARTA ELETTRONICA 13,00 RESTO 0,00**

*Esempio di pagamento con carta elettronica con calcolo del resto:*

|2000|**H**|**3T**|
| - | - | - |

*Risultato sullo scontrino:* **------------------------------------ ![](cef2e6c5-b46b-44be-b392-3359776d8743.195.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.196.png)**

**TOTALE EURO 13,00**

**CARTA ELETTRONICA 20,00 RESTO 7,00**

**4T  Pagamento (tender) con credito![ref45]**

Esegue la chiusura dello scontrino fi scale mediante un pagamento con credito. Il pagamento con credito può essere inserito utilizzando varie modalità illustrate negli esempi seguenti.

*Esempio di pagamento con credito senza calcolo del resto:*

**4T![](cef2e6c5-b46b-44be-b392-3359776d8743.198.png)**

*Risultato sullo scontrino:* **------------------------------------ ![](cef2e6c5-b46b-44be-b392-3359776d8743.199.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.200.png)**

**TOTALE EURO 13,00**

**CREDITO 13,00 RESTO 0,00**

*Esempio di pagamento con 2 euro a credito e il restante in contanti:*

|200|**H**|**4T**|
| - | - | - |

**4T![](cef2e6c5-b46b-44be-b392-3359776d8743.201.png)**

*Risultato sullo scontrino:* **------------------------------------ ![](cef2e6c5-b46b-44be-b392-3359776d8743.202.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.203.png)**

**TOTALE EURO 13,00**

**CREDITO 2,00 CONTANTI 11,00 RESTO 0,00**

**5T  Pagamento (tender) con buono pasto![ref12]**

Esegue la chiusura dello scontrino fi scale mediante il pagamento con buono pasto. Il pagamento con buono pasto può essere inserito utilizzando varie modalità illustrate negli esempi seguenti. Se il corrispettivo incas- sato non raggiunge il valore del buono pasto viene automaticamente aggiunta una voce VARIE con l’importo necessario al raggiungimento del valore del buono pasto.

*Esempio di pagamento con buono pasto da 13 euro con raggiungimento del valore:*

**5T![ref30]**

*Risultato sullo scontrino:* **------------------------------------ ![](cef2e6c5-b46b-44be-b392-3359776d8743.204.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.205.png)**

**TOTALE EURO 13,00**

**BUONO PASTO 13,00**

*Esempio di pagamento con buono pasto da 20 euro senza il raggiungimento del valore:*

|2000|**H**|**5T**|
| - | - | - |

*Risultato sullo scontrino:*

**1 REP1 8,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.206.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.207.png)1 PLU3 5,00 VARIE 7,00 ------------------------------------**

**TOTALE EURO 20,00**

**BUONO PASTO 20,00**

***Note:***  questo terminatore non prevede la stampa della voce RESTO.

**6T  Pagamento (tender) con sospensione![](cef2e6c5-b46b-44be-b392-3359776d8743.208.png)**

Vedi descrizione del terminatore [ 7T ].

**7T  Pagamento (tender) con pagamento generico![ref22]**

Esegue la chiusura dello scontrino fi scale mediante un pagamento generico. Il pagamento generico può essere inserito utilizzando varie modalità illustrate negli esempi seguenti.

*Esempio di pagamento generico senza calcolo del resto:*

**7T![ref32]**

*Risultato sullo scontrino:* **------------------------------------ ![ref43]![ref44]**

**TOTALE EURO 13,00**

**PAGAMENTO GENERICO 13,00 RESTO 0,00**

*Esempio di pagamento generico con calcolo del resto:*

|2000|**H**|**7T**|
| - | - | - |

*Risultato sullo scontrino:* **------------------------------------ ![](cef2e6c5-b46b-44be-b392-3359776d8743.209.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.210.png)**

**TOTALE EURO 13,00**

**PAGAMENTO GENERICO 20,00 RESTO 7,00**

**21T Pagamento (tender) con buono pasto e calcolo del resto (solo per modelli FP)![ref45]**

Vedi descrizione del terminatore [ 5T ]. A differenza del terminatore [ 5T ], non viene aggiunta la voce VARIE se il corrispettivo incassato non raggiunge il valore del buono pasto; e viene stampata la voce RESTO.

*Esempio di pagamento con buono pasto senza calcolo del resto:*

**21T![](cef2e6c5-b46b-44be-b392-3359776d8743.211.png)**

*Risultato sullo scontrino:*

**1 REP1 8,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.212.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.213.png)1 PLU3 5,00 ------------------------------------**

**TOTALE EURO 13,00**

**BUONO PASTO 13,00 RESTO 0,00**

*Esempio di pagamento con buono pasto da 20 euro con calcolo del resto:*

|2000|**H**|**21T**|
| - | - | - |

*Risultato sullo scontrino:*

**1 REP1 8,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.214.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.215.png)1 PLU3 5,00 ------------------------------------**

**TOTALE EURO 13,00**

**BUONO PASTO 20,00 RESTO 7,00**

**22T Pagamento (tender) con buono pasto e calcolo del resto (solo per modelli ECR)![ref12]**

Vedi descrizione del terminatore [ 5T ]. A differenza del terminatore [ 5T ], non viene aggiunta la voce VARIE se il corrispettivo incassato non raggiunge il valore del buono pasto; e viene stampata la voce RESTO.

*Esempio di pagamento con buono pasto senza calcolo del resto:*

**22T![ref30]**

*Risultato sullo scontrino:*

**1 REP1 8,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.216.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.217.png)1 PLU3 5,00 ------------------------------------**

**TOTALE EURO 13,00**

**BUONO PASTO 13,00 RESTO 0,00**

*Esempio di pagamento con buono pasto da 20 euro con calcolo del resto:*

|2000|**H**|**22T**|
| - | - | - |

*Risultato sullo scontrino:*

**1 REP1 8,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.218.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.219.png)1 PLU3 5,00 ------------------------------------**

**TOTALE EURO 13,00**

**BUONO PASTO 20,00 RESTO 7,00**

**Y  Restituisce il controllo della transazione alla tastiera![](cef2e6c5-b46b-44be-b392-3359776d8743.220.png)**

Questo comando permette di trasferire il controllo alla tastiera durante transazione iniziata dall’HOST. Questo comando permette di terminare una transazione iniziata da HOST utilizzando la tastiera.

***ATTE*NZIONE:  Non esiste da tastiera la possibilità di trasferire il controllo all’HOST una volta che la**

**transazione è iniziata.**

**1Z  Stampa BARCODE EAN13![ref10]**

Stampa un BARCODE in formato EAN13 a fi ne scontrino. La stringa da convertire in BARCODE deve essere in formato numerico e costituito da 12 o 13 cifre.

*Esempio di comando con stringa a 12 cifre + CHECKDIGIT calolato:*

|**“**|123456789012|**“**|**1Z**|
| - | - | - | - |

*Risultato sullo scontrino:*

**TOTALE EURO 13,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.221.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.222.png)**

**CONTANTI 13,00 RESTO 0,00**

![](cef2e6c5-b46b-44be-b392-3359776d8743.223.png)

*Esempio di comando con stringa a 13 cifre:*

|**“**|1234567890123|**“**|**1Z**|
| - | - | - | - |

*Risultato sullo scontrino:*

**TOTALE EURO 13,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.224.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.225.png)**

**CONTANTI 13,00 RESTO 0,00**

![](cef2e6c5-b46b-44be-b392-3359776d8743.226.png)

***Note:***  se la stringa inserita è di 12 cifre viene aggiunto il CHECKDIGIT.

**2Z  Stampa BARCODE EAN8![ref12]**

Stampa un BARCODE in formato EAN8 a fi ne scontrino. La stringa da convertire in BARCODE deve essere in formato numerico e costituito da 7 o 8 cifre.

*Esempio di comando con stringa a 7 cifre + CHECKDIGIT calolato:*

|**“**|1234567|**“**|**2Z**|
| - | - | - | - |

*Risultato sullo scontrino:*

**TOTALE EURO 13,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.227.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.228.png)**

**CONTANTI 13,00 RESTO 0,00**

![](cef2e6c5-b46b-44be-b392-3359776d8743.229.png)

*Esempio di comando con stringa a 8 cifre:*

|**“**|12345678|**“**|**2Z**|
| - | - | - | - |

*Risultato sullo scontrino:*

**TOTALE EURO 13,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.230.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.231.png)**

**CONTANTI 13,00 RESTO 0,00**

![](cef2e6c5-b46b-44be-b392-3359776d8743.232.png)

***Note:***  se la stringa inserita è di 7 cifre viene aggiunto il CHECKDIGIT.

**3Z  Stampa BARCODE CODE39![ref10]**

Stampa un BARCODE in formato CODE39 a fi ne scontrino. La stringa da convertire in BARCODE deve essere in formato alfanumerico (caratteri in MAIUSCOLO).

*Esempio di comando:*

|**“**|ABCDEFGHILMNOP|**“**|**3Z**|
| - | - | - | - |

*Risultato sullo scontrino:*

**TOTALE EURO 13,00 ![](cef2e6c5-b46b-44be-b392-3359776d8743.233.png)![](cef2e6c5-b46b-44be-b392-3359776d8743.234.png)**

**CONTANTI 13,00 RESTO 0,00**

![](cef2e6c5-b46b-44be-b392-3359776d8743.235.png)

***Note:***  La lunghezza della stringa varia in base alla stampante utilizzata.

**4 COME EFFETTUARE LE PRIME PROVE DI COLLEGAMENTO**

In ambienti che utilizzano PC con sistemi operativi di tipo MS-DOS, per effettuare le prime prove di collegamento tra PC e stampante fi scale, dopo avere confi gurato la la stampante fi scale, si può agire come di seguito:

- Creare con un normale editor di testo un fi le contenente ad esempio le sequenze di input come defi nite nel precedente capitolo (ad. es. prova.txt”)
- Eseguire da prompt di MS-DOS il comando: MODE COM1:9600,N,8,1,R
- Eseguire: TYPE PROVA.TXT > COM1

In ambienti che utilizzano PC con sistema operativo WINDOWS, per effettuare le prime prove di collegamento tra PC e stampante fi scale, dopo avere confi gurato la stampante fi scale, si può agire come di seguito:

- Creare con un normale editor di testo un fi le contenente ad esempio le sequenze di input come defi nite nel precedente capitolo (ad. es. prova.txt”)
- Eseguire (a seconda del sistema operativo installato)
  - da WINDOWS 9X-2K. XP il programma Hyperterminal “Hypertrm.exe”
- Alla voce: “IMPOSTAZIONI”:
  - selezionare la porta,
  - la velocità di trasmissione (baud rate = 9600),
  - il n.di bit di stop (1),
  - la parità (no parità)
  - il controllo di fl usso (Xon-Xoff).
- Alla voce TRASFERIMENTI eseguire il comando INVIO FILE DI TESTO e selezionare il fi le “prova.txt”

**4.1  Parametri di collegamento**

I parametri di collegamento per i dispositivi fi scali di 1° generazione sono i seguenti:

|1° MODALITÀ [default]|2° MODALITÀ|
| - | - |
|BAUD RATE = 9600|BAUD RATE= 19200|
|PARITA’ = Nessuna|PARITÀ = Nessuna|
|DATA BIT = 8|DATA BIT= 8|
|STOP BIT = 1|STOP BIT= 1|
|FLOW CONTROL = Xon-Xoff|FLOW CONTROL = Xon-Xoff|

I parametri di collegamento per i dispositivi fi scali di 2° generazione sono identici a quelli della 1° MODALITÀ (vedi tabella precedente) con la differenza che la velocità di BAUD RATE può essere impostata a 1200, 2400, 4800, 9600, 19200, 38400 o 57600.

**Nota:** Per le modifi che dei suddetti parametri fare riferimento ai manuali delle stampanti fi scali.

95***![ref2]
*PROTOCOLLO XON/XOFF*

Blank page

97***![ref3]

**Part Number : DOMC-0017I\_1.00**

![ref46] ![ref47] ![ref48]

**CUSTOM ENGINEERING SPA**

World Headquarters

**Via Berettine, 2 - 43100 Fontevivo**

**Tel. +39 0521 680111 - Fax +39 0521 610701 <info@custom.biz> - <www.custom.biz>**

*All rigths reserved*

**<www.custom.biz>  ![ref49]![ref50]**

FISCALE![ref51]![ref52]![ref53]

Tutti i diritti riservati. È vietata la riproduzione totale o parziale del presente manuale in qualsiasi forma, sia essa cartacea o informatica. La CUSTOM ENGINEERING S.p.A. e le risorse impiegate nella realizzazione del manuale, non si assumono nessuna responsabilità derivante dall’utilizzo dello stesso, garantendo che le informazioni contenute nel manuale sono state accuratamente verifi cate.

Ogni suggerimento riguardo ad eventuali errori riscontrati o a possibili miglioramenti sarà particolarmente ap- prezzato. I prodotti sono soggetti ad un continuo controllo e miglioramento, pertanto la CUSTOM ENGINEERING S.p.A. si riserva di modifi care le informazioni contenute nel manuale senza preavviso.

Copyright © 2008 CUSTOM ENGINEERING S.p.A. – Italy

CUSTOM ENGINEERING S.p.A.

Str. Berettine 2 - 43010 Fontevivo (PARMA) - Italy

Tel. : +39 0521-680111  -  Fax : +39 0521-610701 http: <www.custom.it>

Assistenza Tecnica Clienti

*Prodotti POS & Retail:*   <supporto.pos@custom.it>

**ELENCO SEGNALAZIONI E TABELLA COMPARATIVA PRODOTTI**

In caso di anomalie viene emesso un segnale acustico e viene visualizzato sul display la dicitura ERRORE seguita da un codice numerico e da un messaggio (1). Nella seguente tabella è riportato l’elenco delle segna- lazioni raggruppate in base al tipo di prodotto fi scale e l’eventuale soluzione:

**THEA KUBE KUBE MESSAGGIO DI SEGNALAZIONE**

**FP FP ECR MAX MAX ì Cod.** *DESCRIZIONE / SOLUZIONE*

**“ERRORE <codice errore> SCONOSC.”![](cef2e6c5-b46b-44be-b392-3359776d8743.244.png)**

- ● ● ● ● **0** *È stato generato un errore sconosciuto. Prendere contatto con l’assistenza clienti.*

**“IN RICEZIONE DA MF”**

- ● ● ● ● **2** *Vi è stato un errore nella lettura dei dati della memoria fi scale, si richiede l’intervento del tecnico.*
- ● ● ● ● **3 “VALORE NON VALIDO”**

*L’immissione fatta non è corretta, cancellare e ricominciare.* **“OPERAZIONE NON POSSIBILE”**

- ● ● ● ● **5** *L’operazione fatta non è corretta, terminare eventuali documenti in corso e ripetere.*
- ● ● ● ● **6 “IN PROG. MATR. MF”**

*Impossibile scrivere il logotipo fi scale sulla memoria fi scale.*

- ● ● ● ● **7 IN SCRITTA TOTALE**

*Si è tentato di inviare la scritta totale in una vendita.*

**“TOT. SCONTR. ECCESS.”**

- ● ● ● ● **9** *Superato, come importo, il valore massimo sul totale scontrino pari a € 9999999,99.*

**“TOT. GIORN. ECCESS”**

- ● ● ● ● **10** *Superato, come importo, il valore massimo sul totale giornaliero pari a € 9999999,99.*
- ● ● ● ● **11 “V***E’ stato inviato un valore non congruo.***ALORE RICEVUTO NON CONGRUENTE”**

**“DATA ANTECEDENTE A MF”**

- ● ● ● ● **12** *E’ stata inserita una data antecedente a quella memorizzata nella memoria fi scale, correggere e reinserire.*
- ● ● ● ● **13 “DATA / ORA NON VALIDA”**

*Si è inserito una data / ora non valida, correggere e reimpostare.*

**“DATA DIVERSA”**

- ● ● ● ● **14** *Si è inserito una data differente da quella memorizzata, correggere e reimpostare.*
- ● ● ● ● **16 “FINE CARTA”**

*Errore sulla stampante per fi ne carta. Sostituire il rotolo.*

- ● ● ● ● **19 “CHIUSURA MF NON POSSIBILE”**

*Non si è riusciti a scrivere la chiusura in memoria fi scale.*

**“DOCUMENTO IN CORSO”**

- ● ● ● - **21** *Un terminale remoto sta inviando un documento. Attendere che l’operazione in corso venga terminata.*
- ● ● ● ● **22 “DATE DIVERSE”**

*Nella richiesta sono state inserite date incongruenti.*

- ● ● ● ● **23 “TOTALE NEGATIVO”**

*Il totale dello scontrino è negativo, aggiungere importi o annullare.*

- ● ● ● ● **24 “IN LUNGHEZZA COMANDO”**

*E’ stato inviato un comando di lunghezza sbagliata.*

- ● ● ● ● **25 “P***E’ stato inviato un pagamento non completo.***AGAMENTO INCOMPLETO”**
- ● ● ● ● **30 “DGFE ESAURIT***Il DGFE è completo, sostituire.***O”**
- ● ● ● ● **31 “DGFE QUASI ESAURIT***Si sta completando il DGFE, sostituire prima possibile.***O”**

**THEA KUBE KUBE MESSAGGIO DI SEGNALAZIONE**

**FP FP ECR MAX MAX ì Cod.** *DESCRIZIONE / SOLUZIONE*

|●|●|●|●|●|**32**|<p>**“INIZIALIZZAZIONE DGFE NON POSSIBILE”**</p><p>*Non è stato possibile inizializzare il nuovo DGFE, sostituire con altro e avvisare assistenza tecnica.*</p>|
| - | - | - | - | - | - | - |
|●|●|●|●|●|**33**|**“DGFE NON PRESENTE”** *Manca il DGFE, inserirlo.*|
|●|●|●|●|●|**34**|<p>**“DATI DGFE ERRATI”**</p><p>*Tentativo di scrittura su DGFE fallita.*</p>|
|●|●|●|●|●|**35**|<p>**“MF È STATA DISCONN.”**</p><p>*La memoria fi scale è stata disconnessa. Contattare l’assistenza tecnica.*</p>|
|●|●|●|●|●|**36**|<p>**“NESSUN DATO TROVATO SU DGFE”**</p><p>*Mancano i dati del DGFE, sostituire e avvisare il servizio tecnico.*</p>|
|●|●|●|●|●|**38**|<p>**“DGFE NON IDENTIFICATO”**</p><p>*DGFE non omologato. Contattare il rivenditore autorizzato.*</p>|
|●|●|●|●|●|**40**|<p>**“DATO DGFE NON PRESENTE”**</p><p>*Il dato cercato sul DGFE non è stato trovato.*</p>|
|●|●|●|●|●|**50**|<p>**“MF NON PRESENTE”**</p><p>*Riconosciuta la sconnessione della memoria fi scale, chiamare il servizio tecnico.*</p>|
|●|●|●|●|●|**51**|<p>**“MF PIENA”**</p><p>*La memoria fi scale si è esaurita, chiamare il servizio tecnico.*</p>|
|●|●|●|●|●|**52**|<p>**“JUMPER HWINIT INSER”**</p><p>*E’ stato lasciato dal tecnico il jumper dell’Hardware Hinit, chiamare il ser- vizio tecnico.*</p>|
|●|●|●|●|●|**53**|<p>**“DISPOS. GIÀ SERIALIZ.”**</p><p>*Si sta tentando di serializzare una MF già serializzata.*</p>|
|●|●|●|●|●|**54**|<p>**“CHIUS FISC NECESS”**</p><p>*Si richiede la chiusura fi scale.*</p>|
|●|●|●|●|●|**55**|**“MODO TRAINING ATTIVO”** *E’ attivo il modo apprendimento.*|
|●|●|●|●|●|**56**|**“DISPLAY NON PRESENTE (È EMESSO UN BEEP OGNI 3 SECONDI)”** *Il visore cliente è scollegato*|
|●|●|●|●|●|**57**|**“DATA/ ORA NON IMPOST.”** *Non è stata inserita la data e l’ora.*|
|●|●|●|●|●|**59**|<p>**“DISPOS. N. FISCALIZ.”**</p><p>*Dispositivo non fi scalizzabile perchè già fi scalizzato o con problemi alla memoria fi scale.*** </p>|
|●|●|●|●|●|**60**|<p>**“DISPOS. N. SERIALIZ.”**</p><p>*Il dispositivo non è ancora stato serializzato. Contattare l’assistenza tec- nica.*</p>|
|●|●|●|●|-|**62**|<p>**“RICEZ.DATI IN CORSO”**</p><p>*Ricezione dati da remoto a scontrino aperto; chiudere lo scontrino da tastie- ra. Lo scontrino in memoria verrà stampato alla chiusura della transazione corrente da tastiera.*</p>|
|●|●|●|●|-|**63**|**“TRANSAZIONE FALLITA”** *Transazione fallita su EFT-POS*|
|●|●|●||-|**64**|<p>**“COPERCHIO APERTO”**</p><p>*Assicurarsi che il coperchio sia chiuso.*</p>|
|●|●|●|●|●|**65**|<p>**“ERR.ALIMENT.TESTINA”**</p><p>*Tensione elevata su testina termica. Contattare l’assistenza tecnica.*</p>|
|●|●|●|●|●|**66**|<p>**“ERR.TEMP.TESTINA”**</p><p>*Temperatura elevata su testina termica. Contattare l’assistenza tecnica.*</p>|
|●|●|●|●|●|**67**|<p>**“ERRORE OP.SYS.”**</p><p>*Errore generico interno di sistema operativo. Contattare l’assistenza tec- nica.*</p>|
|-|-|●|●|●|**100**|<p>**“ERRORE <codice errore> SCONOSC.”**</p><p>*È stato generato un errore sconosciuto. Prendere contatto con l’assistenza clienti.*</p>|

**THEA KUBE KUBE MESSAGGIO DI SEGNALAZIONE**

**FP FP ECR MAX MAX ì Cod.** *DESCRIZIONE / SOLUZIONE*

|-|-|●|●|●|**101**|<p>**“MEMORIA ESAURITA”**</p><p>*La memoria disponibile per il salvataggio delle ricevute a credito con cliente impostato (FATTURAZIONE DIFFERITA abilitata) è esaurita. È necessario fare una fatturazione differita.*</p>|
| - | - | - | - | - | - | - |
|-|-|●|●|●|**102**|<p>**“SUP. CAP. TOTALE”**</p><p>*Il prezzo immesso “al volo” è superiore a quello massimo impostato per quel reparto.*</p>|
|-|-|●|●|●|**103**|<p>**“<riga>-<colonna> NON ASSOCIATO”**</p><p>*È stato premuto un tasto a cui non corrisponde alcuna funzione.*</p>|
|-|-|●|●|●|**116**|<p>**“FUNZ. NON IMPLEM.”**</p><p>*La funzione associata al tasto premuto non è ancora disponibile. Verifi care la disponibilità di una nuova versione del fi rmware ECR.*</p>|
|-|-|●|●|●|**117**|<p>**“FUNZ. NON AMMESSA”**</p><p>*La funzione richiesta non è applicabile alla situazione presente.*</p>|
|-|-|●|●|●|**118**|<p>**“IMPOSTAZ. ERRATA”**</p><p>*La quantità immessa supera le 65535,99 unità.*</p>|
|-||●|●|●|**119**|<p>**“DATA ERRATA”**</p><p>*La sequenza immessa non è compatibile con il formato data ggmmaa o non corrisponde ad una data.*</p>|
|-|-|●|●|-|**120**|<p>**“ELIM. IMPOSSIBILE”**</p><p>*È impossibile eseguire la cancellazione dell’oggetto. Potrebbe già esser stato cancellato o mai esistito.*</p>|
|-|-|●|●|●|**121**|<p>**“SCONTO ERRATO”**</p><p>*Lo sconto inserito è superiore al 100%.*</p>|
|-|-|●|●|●|**122**|<p>**“VALORE NON AMMESSO”**</p><p>*Il valore immesso non è compreso tra il minimo ed il massimo previsti per quel parametro.*</p>|
|-|-|●|●|●|**123**|<p>**“PASSWORD ERRATA”**</p><p>*La parola chiave non è stata digitata correttamente (o è errata o è stata cambiata).*</p>|
|-|-|●|●|-|**132**|<p>**“FARE FATT. DIFF.”**</p><p>*Al cliente che si vuole eliminare sono state emesse delle ricevute a cre- dito. Non sarà possibile eliminarlo fi nché non verrà fatta una fatturazione differita.*</p>|
|-|-|●|●|-|**133**|<p>**“FARE FATT. TICKET”**</p><p>*Della convenzione che si vuole eliminare sono stati accettati dei ticket. Non sarà possibile eliminarla fi nché non verrà fatta una fatturazione dei ticket alla società corrispondente.*</p>|
|-|-|●|●|●|**134**|<p>**“CHIUDERE DOCUMENTO”**</p><p>*È stata raggiunta la lunghezza massima del documento (150 battute): è ne- cessario chiuderlo ed eventualmente continuare su un nuovo documento.*</p>|
|-|-|●|●|-|**135**|<p>**“RISCUOTERE CREDITO”**</p><p>*Al cliente che si vuole eliminare è stato fatto credito. Non sarà possibile elimina fi nché non verrà riscosso e azzerato il credito residuo.*</p>|
|-|-|●|●|●|**136**|<p>**“CONTANTE INSUFFIC.”**</p><p>*La quantità di contante presente in cassa non è suffi ciente per l’operazione richiesta.*</p>|
|-|-|●|●|-|**148**|<p>**“REPARTO INESISTENTE”**</p><p>*Il reparto richiesto non è utilizzabile poiché non esistente o cancellato.*</p>|
|-|-|●|●|-|**149**|<p>**“REPARTO ESISTENTE”**</p><p>*Il reparto richiesto non è utilizzabile poiché già esistente.*</p>|
|-|-|●|●|●|**150**|<p>**“PLU INESISTENTE”**</p><p>*Il PLU richiesto non è utilizzabile poiché non esistente o cancellato.*</p>|
|-|-|●|●|-|**151**|<p>**“PLU ESISTENTE”**</p><p>*Il PLU richiesto non è utilizzabile poiché già esistente.*</p>|
|-|-|●|●|●|**152**|<p>**“OPERAT. INESISTENTE”**</p><p>*L’operatore richiesto non è utilizzabile poiché non esistente o cancellato.*</p>|
|-|-|●|●|-|**153**|<p>**“OPERATORE ESISTENTE”**</p><p>*L’operatore richiesto non è utilizzabile poiché già esistente.*</p>|

*Guida segnalazioni di stato  5***![ref2]*

**THEA KUBE KUBE MESSAGGIO DI SEGNALAZIONE**

**FP FP ECR MAX MAX ì Cod.** *DESCRIZIONE / SOLUZIONE*

**“CLIENTE INESISTENTE”![](cef2e6c5-b46b-44be-b392-3359776d8743.245.png)**

  - - ● ● - **154**

*Il cliente richiesto non è utilizzabile poiché non esistente o cancellato.*

- ● ● - **155 “CLIENTE ESISTENTE”***Il cliente richiesto non è utilizzabile poiché già esistente.*
  - - ● ● - **156 “NO CONVENZIONI”***Nessuna convenzione è associata alla società selezionata.*

**“CONVENZ. INESISTENTE”**

  - - ● ● - **157** *La convenzione richiesta non è utilizzabile poiché non esistente o cancel- lata.*
  - - ● ● - **158 “CONVENZ. ESISTENTE”**

*La convenzione richiesta non è utilizzabile poiché già esistente.*

  - - ● ● - **159 “SOCIET***La società richiesta non è utilizzabile poiché non esistente o cancellata.***A  INESISTENTE”**
  - - ● ● - **160 “SOCIET***La società richiesta non è utilizzabile poiché già esistente.***A  ESISTENTE”**
  - - ● ● ● **161 “PREC. <numero preconto> N. DISP.”**

*Al numero di preconto richiesto non corrisponde alcun preconto salvato.*

**“TROVATE 0 SF / RIC.”**

  - - ● ● - **162** *Nessuna ricevuta è stata salvata per la fatturazione differita del cliente selezionato.*
  - - ● ● - **163 “SU STAMPANTE RF”**

*La stampante RF (ricevute fi scali) non risponde ai comandi.*

**“TAVOLO PIENO”**

  - - ● - - **164** *Il numero di battute immesse al tavolo è pari alla quantità massima di battute possibili in un documento (150). Occorre liberare il tavolo.*
  - - ● - - **165 “TAVOLO VUOTO”**

*Al tavolo richiesto non sono ancora state inserire battute.*

  - - ● - - **166 “CHIUDERE TAVOLO”**

*Prima di fare l’operazione richiesta è necessario chiudere il tavolo.*

  - - ● - - **167 “SC <numero> NON ASSOCIATA”**

*La stampante cucina identifi cata non è stata associata.*

  - - ● - - **168 “ MC <numero> NON** *La multicomm identificata non è stata associata.***ASSOCIATA”**

**“PROBLEMI IN SC <m> <n>”**

  - - ● - - **169** *Sono stati rilevati problemi nella stampante cucina identifi cata da <n> col- legata alla multicomm <m>.*

**Legenda:**  La pallinatura nella colonna indica che la segnalazione è presente in quel tipo di prodotto. Ad esem-

pio cod. 64 (coperchio aperto) è presente solo nei prodotti THEA FP, KUBE FP e KUBE ECR.

**(1) Nota:**  Nelle versioni FP sul display viene visualizzato solo il codice della segnalazione.

7**  *Guida segnalazioni di stato![ref3]*

**Part Number : DOFI-FISC-ER     Rev**

![ref46] ![ref47] ![ref48]

**CUSTOM ENGINEERING SPA**

World Headquarters

**Via Berettine, 2 - 43100 Fontevivo**

**Tel. +39 0521 680111 - Fax +39 0521 610701 <info@custom.biz> - <www.custom.biz>**

*All rigths reserved*

**<www.custom.biz>  ![ref49]![ref50]**

FISCALE![ref51]![ref52]![ref53]

Tutti i diritti riservati. È vietata la riproduzione totale o parziale del presente manuale in qualsiasi forma, sia essa cartacea o informatica. La CUSTOM ENGINEERING S.p.A. e le risorse impiegate nella realizzazione del manuale, non si assumono nessuna responsabilità derivante dall’utilizzo dello stesso, garantendo che le informazioni contenute nel manuale sono state accuratamente verifi cate.

Ogni suggerimento riguardo ad eventuali errori riscontrati o a possibili miglioramenti sarà particolarmente ap- prezzato. I prodotti sono soggetti ad un continuo controllo e miglioramento, pertanto la CUSTOM ENGINEERING S.p.A. si riserva di modifi care le informazioni contenute nel manuale senza preavviso.

Copyright © 2008 CUSTOM ENGINEERING S.p.A. – Italy

CUSTOM ENGINEERING S.p.A.

Str. Berettine 2 - 43010 Fontevivo (PARMA) - Italy

Tel. : +39 0521-680111  -  Fax : +39 0521-610701 http: <www.custom.it>

Assistenza Tecnica Clienti

*Prodotti POS & Retail:*   <supporto.pos@custom.it>

**ELENCO SEGNALAZIONI E TABELLA COMPARATIVA PRODOTTI**

In caso di anomalie viene emesso un segnale acustico e viene visualizzato sul display la dicitura ERRORE seguita da un codice numerico e da un messaggio (1). Nella seguente tabella è riportato l’elenco delle segna- lazioni raggruppate in base al tipo di prodotto fi scale e l’eventuale soluzione:

*Guida segnalazioni di stato  3***![ref2]*

**XKUBE-F BIG XTHEA-F VKP80II-XF**

- ● ● ●![](cef2e6c5-b46b-44be-b392-3359776d8743.246.png)
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●
- ● ● ●

**MESSAGGIO DI SEGNALAZIONE**

**Cod.** *DESCRIZIONE / SOLUZIONE*

**“ERRORE <codice errore> SCONOSC.”**

**0** *È stato generato un errore sconosciuto. Prendere contatto con l’as- sistenza clienti.*

**“IN RICEZIONE DA MF”**

**2** *Vi è stato un errore nella lettura dei dati della memoria fi scale, si richiede l’intervento del tecnico.*

**“VALORE NON VALIDO”**

**3**

*L’immissione fatta non è corretta, cancellare e ricominciare.*

**“DI CODICE INTERNO”**

4  *Se l’operazione richiesta non è stata eseguita, ripeterla. Se l’errore persiste, contattare l’assistenza tecnica.*

**“OPERAZIONE NON POSSIBILE”**

5  *L’operazione fatta non è corretta, terminare eventuali documenti in corso e ripetere.*

**“IN PROG. MATR. MF”**

**6**

*Impossibile scrivere il logotipo fi scale sulla memoria fi scale* **“IN SCRITTA TOTALE”**

**7**

*Si è tentato di inviare la scritta totale in una vendita.*

**“TOT. SCONTR. ECCESS.”**

9  *Superato, come importo, il valore massimo sul totale scontrino pari a € 9999999,99*

**“TOT. GIORN. ECCESS”**

10  *Superato, come importo, il valore massimo sul totale giornaliero pari a € 9999999,99*

**“DATA ANTECEDENTE A MF”**

**12** *E’ stata inserita una data antecedente a quella memorizzata nella memoria fi scale, correggere e reinserire.*

**“DATA / ORA NON VALIDA”**

**13**

*Si è inserito una data / ora non valida, correggere e reimpostare.* **“DATA DIVERSA”**

**14** *Si è inserito una data differente da quella memorizzata, correggere e reimpostare.*

**“FINE CARTA”**

**16**

*Errore sulla stampante per fi ne carta. Sostituire il rotolo.* **“RAG.SOC.MANCANTE”**

**18**

*Non è stata programmata l’intestazione del documento.* **“CHIUSURA MF NON POSSIBILE”**

**19**

*Non si è riusciti a scrivere la chiusura in memoria fi scale.*

**“DOCUMENTO IN CORSO”**

**21** *Un terminale remoto sta inviando un documento. Attendere che l’ope- razione in corso venga terminata.*

**“DATE DIVERSE”**

**22**

*Nella richiesta sono state inserite date incongruenti.*

**“TOTALE NEGATIVO”**

**23**

*Il totale dello scontrino è negativo, aggiungere importi o annullare.* **“IN LUNGHEZZA COMANDO”**

**24**

*E’ stato inviato un comando di lunghezza sbagliata.* **“PAGAMENTO INCOMPLETO”**

**25**

*E’ stato inviato un pagamento non completo*

**“PROC. INTERR. DALL’UTENTE”**

**26**

*La procedura è stata interrotta dall’utente.*

*Guida segnalazioni di stato  ![ref2]*

**MESSAGGIO DI SEGNALAZIONE XKUBE-F BIG XTHEA-F VKP80II-XF Cod.** *DESCRIZIONE / SOLUZIONE*

|●|●|●|●|**27**|<p>**“DB ENGINE COD. <codice errore>”**</p><p>*Errore generico di database (viene visualizzato un sottocodice in- terno che defi nisce il tipo di errore SQLite). Contattare l’assistenza tecnica.*</p>|
| - | - | - | - | - | - |
|●|●|●|●|**30**|<p>**“DGFE ESAURITO”**</p><p>*Il DGFE è completo, sostituire*</p>|
|●|●|●|●|**31**|<p>**“DGFE QUASI ESAURITO”**</p><p>*Si sta completando il DGFE, sostituire prima possibile*</p>|
|●|●|●|●|**32**|<p>**“INIZIALIZZAZIONE DGFE NON POSSIBILE”**</p><p>*Non è stato possibile inizializzare il nuovo DGFE, sostituire con altro e avvisare assistenza tecnica*</p>|
|●|●|●|●|**33**|**“DGFE NON PRESENTE”** *Manca il DGFE, inserirlo*|
|●|●|●|●|**34**|<p>**“DATI DGFE ERRATI”**</p><p>*Tentativo di scrittura su DGFE fallita.*</p>|
|●|●|●|●|**35**|<p>**“MF È STATA DISCONN.”**</p><p>*La memoria fi scale è stata disconnessa. Contattare l’assistenza tecnica.*</p>|
|●|●|●|●|**36**|<p>**“NESSUN DATO TROVATO SU DGFE”**</p><p>*Mancano i dati del DGFE, sostituire e avvisare il servizio tecnico.*</p>|
|●|●|●|●|**38**|<p>**“DGFE NON IDENTIFICATO”**</p><p>*DGFE non omologato. Contattare il rivenditore autorizzato.*</p>|
|●|●|●|●|**39**|<p>**SD/MMC CON PASSWORD**</p><p>*La SD/MMC inserita non è utilizzabile in quanto protetta da password. Utilizzarne una non protetta.*</p>|
|●|●|●|●|**40**|<p>**“DATO DGFE NON PRESENTE”**</p><p>*Il dato cercato sul DGFE non è stato trovato.*</p>|
|●|●|●|●|**50**|<p>**“MF NON PRESENTE”**</p><p>*Riconosciuta la sconnessione della memoria fi scale, chiamare il servizio tecnico*</p>|
|●|●|●|●|**51**|<p>**“MF PIENA”**</p><p>*La memoria fi scale si è esaurita, chiamare il servizio tecnico*</p>|
|●|●|●|●|**52**|<p>**“JUMPER HWINIT INSER”**</p><p>*E’ stato lasciato dal tecnico il jumper dell’Hardware Hinit, chiamare il servizio tecnico*</p>|
|●|●|●|●|**53**|<p>**“DISPOS. GIÀ SERIALIZ.”**</p><p>*Si sta tentando di serializzare una MF già serializzata.*</p>|
|●|●|●|●|**54**|<p>**“CHIUS FISC NECESS”**</p><p>*Si richiede la chiusura fi scale.*</p>|
|●|●|●|●|**55**|**“MODO TRAINING ATTIVO”** *E’ attivo il modo apprendimento.*|
|●|●|●|●|**56**|<p>**“DISPLAY NON PRESENTE (È EMESSO UN BEEP OGNI 3 SE- CONDI)”**</p><p>*Il visore cliente è scollegato.*</p>|
|●|●|●|●|**57**|**“DATA/ ORA NON IMPOST.”** *Non è stata inserita la data e l’ora.*|
|●|●|●|●|**59**|<p>**“DISPOS. N. FISCALIZ.”**</p><p>*Dispositivo non fi scalizzabile perchè già fi scalizzato o con problemi alla memoria fi scale.*</p>|
|●|●|●|●|**60**|<p>**“DISPOS. N. SERIALIZ.”**</p><p>*Il dispositivo non è ancora stato serializzato. Contattare l’assistenza tecnica.*</p>|
|●|●|●|●|**62**|<p>**“RICEZ.DATI IN CORSO”**</p><p>*Ricezione dati da remoto a scontrino aperto; chiudere lo scontrino da tastiera. Lo scontrino in memoria verrà stampato alla chiusura della transazione corrente da tastiera.*</p>|
|●|●|●|●|**63**|**“TRANSAZIONE FALLITA”** *Transazione fallita su EFT-POS.*|

**MESSAGGIO DI SEGNALAZIONE XKUBE-F BIG XTHEA-F VKP80II-XF Cod.** *DESCRIZIONE / SOLUZIONE*

|●|-|-|-|**64**|<p>**“COPERCHIO APERTO”**</p><p>*Assicurarsi che il coperchio sia chiuso.*</p>|
| - | - | - | - | - | - |
|●|●|●|●|**65**|<p>**“ERR.ALIMENT.TESTINA”**</p><p>*Tensione elevata su testina termica. Contattare l’assistenza tecnica.*</p>|
|●|●|●|●|**66**|<p>**“ERR.TEMP.TESTINA”**</p><p>*Temperatura elevata su testina termica. Contattare l’assistenza tecnica.*</p>|
|●|-|-|-|**67**|<p>**“ERRORE TAGLIERINA”**</p><p>*Errore taglierina. Contattare l’assistenza tecnica.*</p>|
|-|-|-|●|**68**|**“TESTINA SCOLLEGATA”** *Contattare l’assistenza tecnica.*|
|●|●|●|●|**99**|**“Errore disponibile come eco solo dal protocollo CUSTOM.”** *Errore disponibile come eco solo dal protocollo CUSTOM. Errore gene- rico del motore gestionale (fare riferimento a errori superiori a 99).*|
|●|●|●|●|**100**|<p>**“ERRORE <codice errore> SCONOSC.”**</p><p>*È stato generato un errore sconosciuto. Prendere contatto con l’as- sistenza clienti.*</p>|
|●|●|●|●|**101**|<p>**“MEMORIA ESAURITA”**</p><p>*La memoria disponibile per la memorizzazione delle operazioni tran- sitorie è esaurita. E’ necessario effettuare i relativi azzeramenti (es. Azzerare i preconti tramite azzeramento fi nanziario).*</p>|
|●|●|●|●|**102**|<p>**“SUPERAT IMPORTO MAX”**</p><p>*Il prezzo immesso “al volo” è superiore a quello massimo impostato per quel reparto.*</p>|
|●|●|●|●|**103**|<p>**“<riga>-<colonna> NON ASSOCIATO”**</p><p>*È stato premuto un tasto a cui non corrisponde alcuna funzione.*</p>|
|●|●|●|●|**106**|<p>**“DEALLOCAZIONE ERRATA”**</p><p>*Se l’operazione richiesta non e stata eseguita, ripeterla. Se l’errore persiste, contattare l’assistenza tecnica.*</p>|
|●|●|●|●|**107**|<p>**“UPGRADE FALLITO”**</p><p>*L’upgrade del fi le specifi cato è fallito. Verifi care che i fi le utilizzati siano quelli corretti.*</p>|
|●|●|●|●|**108**|<p>**“IMP. MIN N. RAGGIUNTO”**</p><p>*Il prezzo “al volo” immesso è inferiore a quello minimo programmato per quel reparto.*</p>|
|●|●|●|●|**109**|<p>**“CONTAT. N. AZZERATI”**</p><p>*Non è stato possibile azzerare i contatori corrispondenti per cui la cancellazione risulta incompleta.*</p>|
|●|●|●|●|**117**|<p>**“FUNZ. NON AMMESSA”**</p><p>*La funzione richiesta non è applicabile alla situazione presente.*</p>|
|●|●|●|●|**118**|<p>**“IMPOSTAZ. ERRATA”**</p><p>*La quantità immessa supera le 65535,99 unità.*</p>|
|●|●|●|●|**121**|<p>**“MODIFICATORE ERRATO”**</p><p>*Lo sconto inserito è superiore al 100%.*</p>|
|●|●|●|●|**122**|<p>**“VALORE NON AMMESSO”**</p><p>*Il valore immesso non è compreso tra il minimo ed il massimo previsti per quel parametro.*</p>|
|●|●|●|●|**123**|<p>**“PASSWORD ERRATA”**</p><p>*La parola chiave non è stata digitata correttamente (o è errata o è stata cambiata).*</p>|
|\*|\*|\*|\*|**132**|<p>**“FARE FATT. DIFF”**</p><p>*Al cliente che si vuole eliminare sono state emesse delle ricevute a credito. Non sarà possibile eliminarlo fi nché non verrà fatta una fatturazione differita.*</p>|
|\*|\*|\*|\*|**133**|<p>**“FARE FATT. TICKET”**</p><p>*Della convenzione che si vuole eliminare sono stati accettati dei ticket. Non sarà possibile eliminarla fi nché non verrà fatta una fatturazione dei ticket alla società corrispondente.*</p>|

*Guida segnalazioni di stato  5***![ref2]*

**MESSAGGIO DI SEGNALAZIONE XKUBE-F BIG XTHEA-F VKP80II-XF Cod.** *DESCRIZIONE / SOLUZIONE*

|●|●|●|●|**134**|<p>**“CHIUDERE DOCUMENTO”**</p><p>*È stata raggiunta la lunghezza massima del documento: è necessar chiuderlo ed eventualmente continuare su un nuovo documento.*</p>|
| - | - | - | - | - | - |
|●|●|●|●|**135**|<p>**“RISCUOTERE CREDITO”**</p><p>*Al cliente che si vuole eliminare è stato fatto credito. Non sarà possib eliminarlo fi nché non verrà riscosso e azzerato il credito residuo.*</p>|
|●|●|●|●|**136**|<p>**“CONTANTE INSUFFIC.”**</p><p>*La quantità di contante presente in cassa non è suffi ciente per l’ope- razione richiesta.*</p>|
|●|●|●|●|**137**|<p>**“PAGAMENTO NON VALIDO”**</p><p>*Il tipo di pagamento selezionato non è ammesso per concludere l’operazione in corso.*</p>|
|●|●|●|●|**138**|<p>**“QUANTITÀ N. SPECIF.”**</p><p>*Si è tentato di inserire un Reparto/PLU senza specifi care la quantità. Occorre farlo coerentemente a quanto programmato per quel reparto* </p><p>*o per il reparto a cui è collegato quel PLU.*</p>|
|●|●|●|●|**140**|<p>**“OPERAT. GIÀ INSERITO”**</p><p>*In modalità operatore obbligatorio e operatore a turno non è consentita la dichiarazione dello stesso operatore per più di una volta rispettiva- mente nello stesso documento e nello stesso turno.*</p>|
|●|●|●|●|**141**|<p>**“IMPORTO PAG: ECCESS.”**</p><p>*L’importo immesso è superiore a quello massimo programmato per quel pagamento.*</p>|
|●|●|●|●|**142**|<p>**“RESTO ECCESSIVO”**</p><p>*Il resto che si è prodotto è superiore a quello massimo programmato per quel pagamento.*</p>|
|●|●|●|●|**143**|<p>**“CRED. CLIENTE ECCESS”**</p><p>*Il credito che si è tentato di concedere è superiore a quello massimo programmato per quel cliente.*</p>|
|●|●|●|●|**144**|<p>**“PAGAMENTO INESIST.”**</p><p>*Il pagamento specifi cato è inesistente.*</p>|
|●|●|●|●|**146**|<p>**“MODIFICATORE INESIST”**</p><p>*Il modifi catore specifi cato è inesistente.*</p>|
|●|●|●|●|**148**|<p>**“REPARTO INESISTENTE”**</p><p>*Il reparto richiesto non è utilizzabile poiché non esistente o cancel- lato.*</p>|
|●|●|●|●|**150**|<p>**“PLU INESISTENTE”**</p><p>*Il PLU richiesto non è utilizzabile poiché non esistente o cancellato.*</p>|
|●|●|●|●|**152**|<p>**“OPERAT. INESISTENTE”**</p><p>*L’operatore richiesto non è utilizzabile poiché non esistente o can- cellato.*</p>|
|\*|\*|\*|\*|**154**|<p>**“CLIENTE INESISTENTE”**</p><p>*Il cliente richiesto non è utilizzabile poiché non esistente o cancel- lato.*</p>|
|\*|\*|\*|\*|**156**|<p>**“NO CONVENZIONI”**</p><p>*Nessuna convenzione è associata alla società selezionata.*</p>|
|\*|\*|\*|\*|**157**|<p>**“CONVENZ. INESISTENTE”**</p><p>*La convenzione richiesta non è utilizzabile poiché non esistente o cancellata.*</p>|
|\*|\*|\*|\*|**158**|<p>**“CONVENZ. ESISTENTE”**</p><p>*La convenzione richiesta non è utilizzabile poiché già esistente.*</p>|
|\*|\*|\*|\*|**159**|<p>**“SOCIETA  INESISTENTE”**</p><p>*La società richiesta non è utilizzabile poiché non esistente o can- cellata.*</p>|
|\*|\*|\*|\*|**160**|<p>**“SOCIETA  ESISTENTE”**</p><p>*La società richiesta non è utilizzabile poiché già esistente.*</p>|
|●|●|●|●|**161**|<p>**“PREC. <numero preconto> N. DISP.”**</p><p>*Al numero di preconto richiesto non corrisponde alcun preconto salvato.*</p>|

7**  *Guida segnalazioni di stato![ref3]*

**MESSAGGIO DI SEGNALAZIONE XKUBE-F BIG XTHEA-F VKP80II-XF Cod.** *DESCRIZIONE / SOLUZIONE*

|||||||
| :- | :- | :- | :- | :- | :- |
|||||||
|||||||
|||||||
|||||||
|||||||
|||||||
|||||||
|<p>**Legenda:**  La pallinatura nella colonna indica che la segnalazione è presente in quel tipo di prodotto. Ad esem</p><p>pio cod. 64 (coperchio aperto) è presente solo nel prodotto XKUBE-F.</p><p>**\*Nota:**  Campo presente per utilizzi futuri.</p>||||||

|\*|\*|\*|\*|**162**|<p>**“TROVATE 0 SF / RIC.”**</p><p>*Nessuna ricevuta è stata salvata per la fatturazione differita del cliente selezionato.*</p>|
| - | - | - | - | - | - |
|\*|\*|\*|\*|**163**|<p>**“SU STAMPANTE RF”**</p><p>*La stampante RF (ricevute fi scali) non risponde ai comandi.*</p>|
|\*|\*|\*|\*|**164**|<p>**“TAVOLO PIENO”**</p><p>*Il numero di battute immesse al tavolo è pari alla quantità massima di battute possibili in un documento. Occorre liberare il tavolo.*</p>|
|\*|\*|\*|\*|**165**|<p>**“TAVOLO VUOTO”**</p><p>*Al tavolo richiesto non sono ancora state inserire battute.*</p>|
|\*|\*|\*|\*|**166**|<p>**“CHIUDERE TAVOLO”**</p><p>*Prima di fare l’operazione richiesta è necessario chiudere il tavolo.*</p>|
|\*|\*|\*|\*|**167**|<p>**“SC <numero> NON ASSOCIATA”**</p><p>*La stampante cucina identifi cata non è stata associata.*</p>|
|\*|\*|\*|\*|**168**|<p>**“ MC <numero> NON ASSOCIATA”**</p><p>*La multicomm identifi cata non è stata associata.*</p>|
|\*|\*|\*|\*|**169**|<p>**“PROBLEMI IN SC <m> <n>”**</p><p>*Sono stati rilevati problemi nella stampante cucina identifi cata da <n> collegata alla multicomm <m>*</p>|

``*Guida segnalazioni di stato  9***![ref6]*

**Part Number : DOFI-FISC-ER-XG     Rev**

![ref46] ![ref47] ![ref48]

**CUSTOM ENGINEERING SPA**

World Headquarters

**Via Berettine, 2 - 43100 Fontevivo**

**Tel. +39 0521 680111 - Fax +39 0521 610701 <info@custom.biz> - <www.custom.biz>**

*All rigths reserved*
**<www.custom.biz>  ![ref49]![ref50]**

[ref1]: cef2e6c5-b46b-44be-b392-3359776d8743.002.png
[ref2]: cef2e6c5-b46b-44be-b392-3359776d8743.004.png
[ref3]: cef2e6c5-b46b-44be-b392-3359776d8743.005.png
[ref4]: cef2e6c5-b46b-44be-b392-3359776d8743.006.png
[ref5]: cef2e6c5-b46b-44be-b392-3359776d8743.015.png
[ref6]: cef2e6c5-b46b-44be-b392-3359776d8743.016.png
[ref7]: cef2e6c5-b46b-44be-b392-3359776d8743.017.png
[ref8]: cef2e6c5-b46b-44be-b392-3359776d8743.018.png
[ref9]: cef2e6c5-b46b-44be-b392-3359776d8743.019.png
[ref10]: cef2e6c5-b46b-44be-b392-3359776d8743.020.png
[ref11]: cef2e6c5-b46b-44be-b392-3359776d8743.021.png
[ref12]: cef2e6c5-b46b-44be-b392-3359776d8743.022.png
[ref13]: cef2e6c5-b46b-44be-b392-3359776d8743.023.png
[ref14]: cef2e6c5-b46b-44be-b392-3359776d8743.024.png
[ref15]: cef2e6c5-b46b-44be-b392-3359776d8743.027.png
[ref16]: cef2e6c5-b46b-44be-b392-3359776d8743.028.png
[ref17]: cef2e6c5-b46b-44be-b392-3359776d8743.029.png
[ref18]: cef2e6c5-b46b-44be-b392-3359776d8743.032.png
[ref19]: cef2e6c5-b46b-44be-b392-3359776d8743.034.png
[ref20]: cef2e6c5-b46b-44be-b392-3359776d8743.035.png
[ref21]: cef2e6c5-b46b-44be-b392-3359776d8743.036.png
[ref22]: cef2e6c5-b46b-44be-b392-3359776d8743.040.png
[ref23]: cef2e6c5-b46b-44be-b392-3359776d8743.041.png
[ref24]: cef2e6c5-b46b-44be-b392-3359776d8743.043.png
[ref25]: cef2e6c5-b46b-44be-b392-3359776d8743.044.png
[ref26]: cef2e6c5-b46b-44be-b392-3359776d8743.046.png
[ref27]: cef2e6c5-b46b-44be-b392-3359776d8743.047.png
[ref28]: cef2e6c5-b46b-44be-b392-3359776d8743.057.png
[ref29]: cef2e6c5-b46b-44be-b392-3359776d8743.089.png
[ref30]: cef2e6c5-b46b-44be-b392-3359776d8743.095.png
[ref31]: cef2e6c5-b46b-44be-b392-3359776d8743.096.png
[ref32]: cef2e6c5-b46b-44be-b392-3359776d8743.098.png
[ref33]: cef2e6c5-b46b-44be-b392-3359776d8743.099.png
[ref34]: cef2e6c5-b46b-44be-b392-3359776d8743.118.png
[ref35]: cef2e6c5-b46b-44be-b392-3359776d8743.119.png
[ref36]: cef2e6c5-b46b-44be-b392-3359776d8743.120.png
[ref37]: cef2e6c5-b46b-44be-b392-3359776d8743.121.png
[ref38]: cef2e6c5-b46b-44be-b392-3359776d8743.122.png
[ref39]: cef2e6c5-b46b-44be-b392-3359776d8743.123.png
[ref40]: cef2e6c5-b46b-44be-b392-3359776d8743.124.png
[ref41]: cef2e6c5-b46b-44be-b392-3359776d8743.125.png
[ref42]: cef2e6c5-b46b-44be-b392-3359776d8743.138.png
[ref43]: cef2e6c5-b46b-44be-b392-3359776d8743.193.png
[ref44]: cef2e6c5-b46b-44be-b392-3359776d8743.194.png
[ref45]: cef2e6c5-b46b-44be-b392-3359776d8743.197.png
[ref46]: cef2e6c5-b46b-44be-b392-3359776d8743.236.png
[ref47]: cef2e6c5-b46b-44be-b392-3359776d8743.237.png
[ref48]: cef2e6c5-b46b-44be-b392-3359776d8743.238.png
[ref49]: cef2e6c5-b46b-44be-b392-3359776d8743.239.png
[ref50]: cef2e6c5-b46b-44be-b392-3359776d8743.240.png
[ref51]: cef2e6c5-b46b-44be-b392-3359776d8743.241.jpeg
[ref52]: cef2e6c5-b46b-44be-b392-3359776d8743.242.jpeg
[ref53]: cef2e6c5-b46b-44be-b392-3359776d8743.243.jpeg
