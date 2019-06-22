## create temp directory for working
##$tempDirectory = Get-Random
##New-Item -ItemType directory -Path $tempDirectory

$driver = 'Generic / Text only'

## install 7zip
##$7zInstaller = "$tempDirectory\7z-install.exe"
##Invoke-WebRequest https://www.7-zip.org/a/7z1900-x64.exe -OutFile $7zInstaller
##Start-Process -FilePath $7zInstaller -ArgumentList "/S"
##if (-not (test-path "$env:ProgramFiles\7-Zip\7z.exe")) {throw "$env:ProgramFiles\7-Zip\7z.exe needed"} 
##set-alias sz "$env:ProgramFiles\7-Zip\7z.exe"  

## download driver
##$hpDriver = "$tempDirectory/hpdriver.exe"
##Invoke-WebRequest https://ftp.hp.com/pub/softlib/software13/printers/OJ6970/OJ6970_Basicx64_40.12.1161.exe -OutFile $hpDriver
##$target = "$tempDirectory\extracted"
##New-Item -ItemType directory -Path $target
##sz x $hpDriver -o"$target" -r

## install driver
##$pnpOutput = pnputil -a "$tempDirectory\extracted\HPWia_OJ6970.INF" | Select-String "Published name"

## Delete if existing so we have a clean install
Remove-Printer -Name 'SFPRINTER' -ErrorAction SilentlyContinue
Remove-PrinterPort  -Name 'SFPRINTERPORT' -ErrorAction SilentlyContinue
Remove-PrinterDriver  -Name $driver -ErrorAction SilentlyContinue

## Install printer, port and driver
Add-PrinterDriver -Name $driver -ErrorAction SilentlyContinue
Add-PrinterPort -Name 'SFPRINTERPORT' -PrinterHostAddress '192.168.1.1' -ErrorAction SilentlyContinue
Add-Printer -Name 'SFPRINTER' -DriverName $driver -PortName 'SFPRINTERPORT' -ErrorAction SilentlyContinue