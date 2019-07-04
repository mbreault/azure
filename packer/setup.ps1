## Install Choco
Set-ExecutionPolicy Bypass -Scope Process -Force; Invoke-Expression ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

## Install 7zip
choco install 7zip.install -y --force

## Download the driver from HP
$url = "https://ftp.hp.com/pub/softlib/software13/printers/OJ6970/OJ6970_Basicx64_40.12.1161.exe"
$output = "C:\\Windows\\Temp\\OJ6970_Basicx64_40.12.1161.exe"

Invoke-WebRequest $url  -OutFile $output

mkdir "C:\\Windows\\Temp\\OJ6970"

## Extract the exe using 7zip
7z.exe x $output -o"C:\\Windows\\Temp\\OJ6970" -aoa

## Run the MSI to install the driver
msiexec.exe /i "C:\\Windows\\Temp\\OJ6970\\OJ697x64.msi" /qn /l*v "C:\\Windows\\Temp\\HPWia_OJ6970.log" ENTERPRISE=YES FAX=NO SCANTOPC=NO REBOOT=ReallySuppress
