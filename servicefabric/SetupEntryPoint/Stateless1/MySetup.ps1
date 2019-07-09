$driver = 'HP OfficeJet Pro 6970 PCL-3'

## Delete if existing so we have a clean install
Remove-Printer -Name 'SFPRINTER' -ErrorAction SilentlyContinue
Remove-PrinterPort  -Name 'SFPRINTERPORT' -ErrorAction SilentlyContinue
Remove-PrinterDriver  -Name $driver -ErrorAction SilentlyContinue

## Install printer, port and driver
Add-PrinterDriver -Name $driver -ErrorAction SilentlyContinue
Add-PrinterPort -Name 'SFPRINTERPORT' -PrinterHostAddress '192.168.1.1' -ErrorAction SilentlyContinue
Add-Printer -Name 'SFPRINTER' -DriverName $driver -PortName 'SFPRINTERPORT' -ErrorAction SilentlyContinue

$driver = 'HP LaserJet Pro M402-M403 PCL 6'

## Delete if existing so we have a clean install
Remove-Printer -Name 'MENUPRINTER' -ErrorAction SilentlyContinue
Remove-PrinterPort  -Name 'MENUPRINTERPORT' -ErrorAction SilentlyContinue
Remove-PrinterDriver  -Name $driver -ErrorAction SilentlyContinue

## Install printer, port and driver
Add-PrinterDriver -Name $driver -ErrorAction SilentlyContinue
Add-PrinterPort -Name 'MENUPRINTERPORT' -PrinterHostAddress '192.168.1.1' -ErrorAction SilentlyContinue
Add-Printer -Name 'MENUPRINTER' -DriverName $driver -PortName 'MENUPRINTERPORT' -ErrorAction SilentlyContinue

