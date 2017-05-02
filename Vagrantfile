# -*- mode: ruby -*-
# vi: set ft=ruby :

Vagrant.configure("2") do |config|
	config.vm.box = "ubuntu/trusty64"

	config.vm.provision "shell", inline: <<-SHELL
		echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list

		apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893
		apt-get update
		apt-get install -y dotnet-dev-1.0.1
		apt-get install -y mono-complete
		apt-get install -y nuget
	SHELL

	config.vm.provision "shell", privileged: false, inline: <<-SHELL
		cd /vagrant

		nuget restore Cottle.sln
		nuget install NUnit.Console -Version 3.0.1 -OutputDirectory packages
		xbuild /p:Configuration=Release /p:TargetFrameworkVersion=v4.5 Cottle.sln
		mono ./packages/NUnit.Console.3.0.1/tools/nunit3-console.exe ./Cottle.Test/bin/Release/Cottle.Test.dll

		rm -fr ./artifacts
		dotnet restore
		dotnet test ./Cottle.Test/Cottle.Test.csproj -c Release -f netcoreapp1.0
		dotnet pack ./Cottle/Cottle.csproj -c Release -o ./artifacts
	SHELL
end
