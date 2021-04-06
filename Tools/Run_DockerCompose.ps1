$uiContainer = "carbrand-ui";
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
		## Build the api and db services
		docker-compose build
		
		## Create the containers
		docker-compose up --no-start
		
		## Start containers in specific order
		$ui = docker inspect $uiContainer
		$api = docker inspect $apiContainer
		$db = docker inspect $dbContainer
		
		$jsonUI = $ui | ConvertFrom-Json
		$jsonAPI = $api | ConvertFrom-Json
		$jsonDB = $db | ConvertFrom-Json
		
		$uiContainerExists = ($jsonUI.State.PSobject.Properties.Name -match "Health") -eq "Health"
		$uiContainerExists = !($uiContainerExists -eq $False)
		
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
		
		# Start UI container
		if ($uiContainerExists -and !($jsonUI.State.Status -eq "running")) {
			docker-compose start $uiContainer
		}
	}
	catch
	{
		Write-Host " " + $_.Exception.Message
	}
}