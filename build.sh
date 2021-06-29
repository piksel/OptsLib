#!/bin/bash

GIT_ROOT="$(cd ${BASH_SOURCE%/*} && git rev-parse --show-toplevel)"
echo $GIT_ROOT


for p in $(find src -name '*.csproj'); do
	if [ "$p" != "src/OptsLib.WinForms.Design/OptsLib.WinForms.Design.csproj" ]; then
	  echo -e "Building \e[1;94m$p\e[0m...\e[1;90m"
	  dotnet clean --nologo $p
	  dotnet build --nologo -c release -p:SolutionDir=$GIT_ROOT -p:ContinuousIntegrationBuild=true $p
	  dotnet pack --nologo -c release -p:SolutionDir=$GIT_ROOT -p:ContinuousIntegrationBuild=true $p
	  echo -e "\e[0m"
	fi
done