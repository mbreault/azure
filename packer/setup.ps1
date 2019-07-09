## Install Choco
Set-ExecutionPolicy Bypass -Scope Process -Force; Invoke-Expression ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

## Install 7zip
choco install 7zip.install -y --force

## HP OfficeJet Pro 6970
## Download the driver from HP
$url = "https://ftp.hp.com/pub/softlib/software13/printers/OJ6970/OJ6970_Basicx64_40.12.1161.exe"
$output = "C:\\Windows\\Temp\\OJ6970_Basicx64_40.12.1161.exe"

Invoke-WebRequest $url  -OutFile $output

New-Item -ItemType Directory -Force -Path "C:\\Windows\\Temp\\OJ6970"

## Extract the exe using 7zip
7z.exe x $output -o"C:\\Windows\\Temp\\OJ6970" -aoa

## Run the MSI to install the driver
msiexec.exe /i "C:\\Windows\\Temp\\OJ6970\\OJ697x64.msi" /qn /l*v "C:\\Windows\\Temp\\HPWia_OJ6970.log" ENTERPRISE=YES FAX=NO SCANTOPC=NO REBOOT=ReallySuppress

## HP LaserJet Pro M402dw
## Download the driver from HP
$url = "https://ftp.hp.com/pub/softlib/software13/COL61821/lj-149219-8/HP_LJ_Pro_M402-M403_PCL6_v3_Full_Soln_19133.exe"
$output = "C:\\Windows\\Temp\\HP_LJ_Pro_M402-M403_PCL6_v3_Full_Soln_19133.exe"

Invoke-WebRequest $url  -OutFile $output

New-Item -ItemType Directory -Force -Path "C:\\Windows\\Temp\\HP_LJ_Pro_M402-M403"

## Extract the exe using 7zip
7z.exe x $output -o"C:\\Windows\\Temp\\HP_LJ_Pro_M402-M403" -aoa

## Run the exe to install the driver
Start-Process -FilePath "C:\\Windows\\Temp\\HP_LJ_Pro_M402-M403\\Installer\\DPInst_x64\\dpinst.exe"



