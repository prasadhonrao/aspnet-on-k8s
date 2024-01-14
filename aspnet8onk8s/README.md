# Database Setup Instructions

## Check if any process is running on port 1433

```code
Get-Process -Id (Get-NetTCPConnection -LocalPort 1433).OwningProcess
```

## Stop the process

```code
Stop-Process -Id (Get-NetTCPConnection -LocalPort 1433).OwningProcess
```

## Kill the process

```code
Stop-Process -Id (Get-NetTCPConnection -LocalPort 1433).OwningProcess -Force
```

## Create container with SQL Server 2022

```code
docker run --rm -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=P@ssw0rd" -p 1432:1433 --name sql --hostname sqlhost -d mcr.microsoft.com/mssql/server:2022-latest
```

# Check if container is running

```code
docker ps
```

## Create ProudctDb Database

```sql
docker exec -it sql /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "P@ssw0rd" -Q "CREATE DATABASE ProductDb"
```

## Create Product Table

```sql
docker exec -it sql /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "P@ssw0rd" -d ProductDb -Q "CREATE TABLE Product (Id INT PRIMARY KEY IDENTITY(1,1), Name NVARCHAR(100))"
```

## Insert Data into Product Table

```sql
docker exec -it sql /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "P@ssw0rd" -d ProductDb -Q "INSERT INTO Product (Name) VALUES ('iPhone')"
```

## Check if data is inserted

```sql
docker exec -it sql /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "P@ssw0rd" -d ProductDb -Q "SELECT * FROM Product"
```
