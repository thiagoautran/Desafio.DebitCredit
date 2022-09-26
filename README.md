0) Faça o download e instale o Docker
<p>
[docker](https://desktop.docker.com/win/main/amd64/Docker%20Desktop%20Installer.exe)
</p>

1) Baixe o banco de dados SqlServer usando o docker, com o comando abaixo
<p>
docker run --name=SqlServer2022 --restart=always --network=bridge -p 1433:1433 -e "ACCEPT_EULA=Y" -e TZ=America/Sao_Paulo -e "SA_PASSWORD=Adm#n#str@dor" -v /custom/mount:/var/lib/sqlserver2022/data -d mcr.microsoft.com/mssql/server:2022-latest
</p>

2) Faça o download e instale o Azure Data Studio
<p>
[Azure Data Studio](https://go.microsoft.com/fwlink/?linkid=2204567)
</p>

3) Baixe o repositorio do projeto

4) Abra o terminal do windows na pasta do repositorio do projeto

5) Execute o comando para criar a imagem da api credit no docker
<p>
docker build Credit -t desafio.credit
</p>

6) Execute o comando para criar o container da api credit no docker
<p>
docker run -p 8002:80 --network=bridge -e ASPNETCORE_ENVIRONMENT=Docker -e TZ=America/Sao_Paulo --restart=always --name desafio.credit -d desafio.credit
</p>

7) Execute o comando para criar a imagem da api account no docker
<p>
docker build Account -t desafio.account
</p>

8) Execute o comando para criar o container da api account no docker
<p>
docker run -p 8001:80 --network=bridge -e ASPNETCORE_ENVIRONMENT=Docker -e TZ=America/Sao_Paulo --restart=always --name desafio.account -d desafio.account
</p>

9) Acesse o endereço <www.localhost:8001> no seu navegador para acessar a api account

10) Acesse o endereço <www.localhost:8002> no seu navegador para acessar a api credit

