### Preparando ambiente

1) Instale o Docker
<https://desktop.docker.com/win/main/amd64/Docker%20Desktop%20Installer.exe>

2) Instale o Azure Data Studio
<https://go.microsoft.com/fwlink/?linkid=2204567>

### Preparando banco de dados

1) Instale o SqlServer
* Abra o terminal e digite o comando abaixo
> docker run --name=SqlServer2022 --restart=always --network=bridge -p 1433:1433 -e "ACCEPT_EULA=Y" -e TZ=America/Sao_Paulo -e "SA_PASSWORD=Adm#n#str@dor" -v /custom/mount:/var/lib/sqlserver2022/data -d mcr.microsoft.com/mssql/server:2022-latest

2) Crie o banco de dados
* Abra o Azure Data Studio
* Connect no banco de dados SqlServer2022
<p>
Server: localhost <br/>
User name: sa <br/>
Password: Adm#n#str@dor
</p>
* Abra o arquivo DataBase.sql na raiz do repositorio e execute o script

### Criando as imagens dos projetos

1) Baixe o repositorio do projeto

2) Abra o terminal do windows na pasta do repositorio do projeto

3) Execute o comando para criar a imagem da api credit no docker
> docker build Credit -t desafio.credit

4) Execute o comando para criar a imagem da api account no docker
> docker build Account -t desafio.account

### Publicando as api's no docker

1) Execute o comando para criar o container da api credit no docker
> docker run -p 8002:80 --network=bridge -e ASPNETCORE_ENVIRONMENT=Docker -e TZ=America/Sao_Paulo --restart=always --name desafio.credit -d desafio.credit

2) Execute o comando para criar o container da api account no docker
> docker run -p 8001:80 --network=bridge -e ASPNETCORE_ENVIRONMENT=Docker -e TZ=America/Sao_Paulo --restart=always --name desafio.account -d desafio.account

### Acessando projetos publicados

1) Api account [www.localhost:8001](http://www.localhost:8001/index.html)

2) Api credit [www.localhost:8002](http://www.localhost:8002/index.html)
