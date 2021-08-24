# MQ4Inject

Injects code from includes into mq4/mq5 files

## How to use

It's a command-line utility. 

There are two mandatory parameters: --sources and --source-file

source-file is a file you need insert includes to.

sources is a path to a directory with included files.

Example:

MQ4Inject.exe --soruces "c:/mql4includes" --source-file "myea.mq4" --target-file "myea_full.mq4"

This command will replace all #include <blahblahblah.mq4> lines with the code from c:/mql4includes/blahblahblah.mq4 and will write the resulting code
into myea_fill.mq4. You can omit --target-file parameter. The utility will write the code into the source-file in this case. All includes in the included files 
will be replaces as well.

## How to compine

Install Microsoft .Net Core 3.0

Go to the project folder in the console and type dotnet build. Or build it in Visual Studio

## Related projects

[Lint utility for indicators/strategies](https://github.com/sibvic/fxlint)

[Injection of includes into MQL4/5](https://github.com/sibvic/MQ4Inject)

[Automatic Trade Script Converter App](https://www.microsoft.com/en-us/p/pinescript-converter/9mwmkf7bmqgn?activetab=pivot:overviewtab) and [WebApp](https://convert.profitrobots.com)

[Trade Copier Source](https://github.com/sibvic/trade_copier)

### Templates

[FXTS2](https://github.com/sibvic/fxts2-templates) 

[PineScript/TradingView](https://github.com/sibvic/pinescript-templates) 

[MT4/MQL4](https://github.com/sibvic/mq4-templates) 

[MT5/MQL5](https://github.com/sibvic/mq5-templates) 

[NT8/Ninja Trader 8](https://github.com/sibvic/nt8-templates)

### Code Snippets for Visual Studio Code

[MT4/MQL4](https://github.com/sibvic/vsc-mq4-snippets) 

[MT5/MQL5](https://github.com/sibvic/vsc-mq5-snippets) 

[Indicore](https://github.com/sibvic/vsc-indicore)

[NinjaTrader8](https://github.com/sibvic/vsc-nt8-snippets)
