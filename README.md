1) Baixe o banco de dados SqlServer usando o docker, com o comando abaixo
<p>
docker run --name=SqlServer2022 --restart=always --network=bridge -p 1433:1433 -e "ACCEPT_EULA=Y" -e TZ=America/Sao_Paulo -e "SA_PASSWORD=Adm#n#str@dor" -v /custom/mount:/var/lib/sqlserver2022/data -d mcr.microsoft.com/mssql/server:2022-latest
</p>