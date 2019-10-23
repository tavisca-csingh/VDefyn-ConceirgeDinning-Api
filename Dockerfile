FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
				

COPY ConceirgeDinning.API/bin/Release/netcoreapp2.2/publish/ /app/

WORKDIR /app/

EXPOSE 80

CMD ["dotnet", "ConceirgeDinning.API.dll"]
#demo2