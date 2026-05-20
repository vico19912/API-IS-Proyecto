#!/bin/bash

/opt/mssql/bin/sqlservr &
SQLSERVER_PID=$!

echo "Esperando que SQL Server esté listo..."
until /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -Q "SELECT 1" -C > /dev/null 2>&1; do
    echo "SQL Server no está listo aún, reintentando..."
    sleep 2
done

echo "SQL Server listo. Ejecutando script de inicialización..."
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -i /docker-entrypoint-initdb.d/init.sql -C
echo "Tablas creadas correctamente."

echo "Cargando datos iniciales..."
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -i /docker-entrypoint-initdb.d/seed.sql -C
echo "Datos iniciales cargados correctamente."

wait $SQLSERVER_PID
