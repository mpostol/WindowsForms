if $(ConfigurationName)==Debug goto skip
rd /q /s .\temp
md .\temp
"%dotfuscator%" /in:$(TargetFileName)   /out:temp  /makeconfig:config.xml
"%net20sdk%\sn.exe" -R .\temp\$(TargetFileName) ..\..\BK.CodeProtect\cas.snk
copy /y .\temp\$(TargetFileName) .\ 
:skip