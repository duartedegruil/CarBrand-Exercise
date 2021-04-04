$apiContainer = "carbrand-api";
$dbContainer = "carbrand-db";

## Confirm Docker is using Linux containers
$useLinuxContainerQuestion = (docker info -f '{{ .OSType }}')
if ($useLinuxContainerQuestion -eq 'windows')
{ 
	Write-Host "Please switch Docker to use Linux containers before proceeding..."
} 
else
{
	try
	{
		Set-Location -Path "$PSScriptRoot\..\CarBrandAPI"

		## Build the api and db services
		docker-compose build
		
		## Create the containers
		docker-compose up --no-start
		
		## Start containers in specific order
		$api = docker inspect $apiContainer
		$db = docker inspect $dbContainer
		
		$jsonAPI = $api | ConvertFrom-Json
		$jsonDB = $db | ConvertFrom-Json
		
		$apiContainerExists = ($jsonAPI.State.PSobject.Properties.Name -match "Health") -eq "Health"
		$apiContainerExists = !($apiContainerExists -eq $False)
		
		$dbContainerExists = ($jsonDB.State.PSobject.Properties.Name -match "Health") -eq "Health"
		$dbContainerExists = !($dbContainerExists -eq $False)
		
		# Start DB container
		if ($dbContainerExists -and !($jsonDB.State.Status -eq "running")) {
			docker-compose start $dbContainer
			Start-Sleep -s 5
		}
		
		# Start API container
		if ($apiContainerExists -and !($jsonAPI.State.Status -eq "running")) {
			docker-compose start $apiContainer
		}
	}
	catch
	{
		Write-Host " " + $_.Exception.Message
	}
}