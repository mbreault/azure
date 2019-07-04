$driver = 'HP OfficeJet Pro 6970 PCL-3'

## Delete if existing so we have a clean install
Remove-Printer -Name 'SFPRINTER' -ErrorAction SilentlyContinue
Remove-PrinterPort  -Name 'SFPRINTERPORT' -ErrorAction SilentlyContinue
Remove-PrinterDriver  -Name $driver -ErrorAction SilentlyContinue

## Install printer, port and driver
Add-PrinterDriver -Name $driver -ErrorAction SilentlyContinue
Add-PrinterPort -Name 'SFPRINTERPORT' -PrinterHostAddress '192.168.1.1' -ErrorAction SilentlyContinue
Add-Printer -Name 'SFPRINTER' -DriverName $driver -PortName 'SFPRINTERPORT' -ErrorAction SilentlyContinue