## Monoberry_Builder.ps1: Create and install a .bar package for Blackberry 10 OS Simulator
#### Authors:
##   Gustavo Torrico (gatm50@gmail.com)
#### Licensed under the terms of the Microsoft Public License (MS-PL)
#### Copyright 2012 Cup-Coffee, ( http://cup-coffe.blogspot.com )
##

################
##### Environment Variables
$descriptor_path='monoberry-descriptor.xml';
$deploy='Deploy';
$temp='tmp\';
$locale='tmp\locale';
$exe='C:\bbndk\host_10_0_9_404\win32\x86\usr\bin\blackberry-nativepackager.bat';
$scriptPath = $MyInvocation.mycommand.path;
#Hard-Coded name, it's necessary read it like a parameter of the script when is called from Visual Studio 
$barName="monoberry.bar";

####
## Function that calls the native application
###
function RunProcess()
{
    param (
		[string]$exe = $(Throw "An executable must be specified"), 	
		[string] $arguments = $(Throw "A Script Path must be specified")
		)
    $startInfo= new-Object System.Diagnostics.ProcessStartInfo;  
    $startInfo.FileName = $exe;  
    $startInfo.Arguments=$arguments;  
    $startInfo.RedirectStandardOutput = $true; 
    $startInfo.UseShellExecute = $false;  
	$startinfo.RedirectStandardError = $true;
	$startinfo.WindowStyle = "Normal";
    $process = New-Object System.Diagnostics.Process;  
    $process.StartInfo = $startInfo;  
    $process.Start();  
	$process.WaitForExit();
    $result = $process.StandardOutput.ReadToEnd();
	$result;
}
 
function CreatePackage()  
{  
    param (
		[string]$exe = $(Throw "An executable must be specified"), 	
		[string] $scriptPath = $(Throw "A Script Path must be specified"),
		[string] $barPath = $(Throw "A Script Path must be specified")
		)
		
	#The Script will fail if $scriptPath contains spaces.
	$completePath = [System.IO.Path]::Combine([System.IO.Path]::GetDirectoryName($scriptPath), "");
	$descriptor_path=[System.IO.Path]::Combine($completePath, $descriptor_path);
	$deploy=[System.IO.Path]::Combine($completePath, $deploy);
	$temp=[System.IO.Path]::Combine($completePath, $temp);
	$locale=[System.IO.Path]::Combine($completePath, $locale);
	$barPath=[System.IO.Path]::Combine($completePath, $barPath);
	
	$arguments= [System.String]::Format("-package {0} -devMode {1} {2} -C {3} {4}", $barPath, $descriptor_path, $deploy, $temp, $locale);
	RunProcess $exe $arguments;
}

######
## Begin Main Method
######
CreatePackage $exe $scriptPath $barName;
######
## End Main Method
######