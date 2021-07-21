FROM mysql:5.7.22
EXPOSE 3306
COPY ./Rest.net5/DB/Migrations/ /home/database/
COPY ./Rest.net5/DB/Dataset/ /home/database/
COPY ./Rest.net5/CI/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh