create database smart_schedule_db;

use smart_schedule_db;

create table functionary (
	id int primary key auto_increment unique,
    name varchar(100) not null,
    cpf varchar(11) not null unique,
    siape varchar(20) not null unique
);

create table user (
                      id int primary key auto_increment unique,
                      name varchar(100) not null,
                      cpf varchar(11) not null unique,
                      email varchar(100) not null unique,
                      cellphone varchar(15),
                      username varchar(50) not null unique,
                      password varchar(255) not null
);

create table team (
                      id int primary key auto_increment unique,
                      name varchar(100) not null,
                      description text
);

-- Inserts para a tabela user
insert into user (name, cpf, email, cellphone, username, password) values
                                                                       ('John Doe', '12345678901', 'john.doe@example.com', '1234567890', 'johndoe', 'password123'),
                                                                       ('Jane Smith', '23456789012', 'jane.smith@example.com', '0987654321', 'janesmith', 'password456');

-- Inserts para a tabela team
insert into team (name, description) values
                                         ('Development', 'Development Team'),
                                         ('Marketing', 'Marketing Team');

-- Inserts para a tabela functionary
insert into functionary (name, cpf, siape) values
                                               ('Alice Johnson', '34567890123', 'SIAPE12345'),
                                               ('Bob Brown', '45678901234', 'SIAPE67890');

-- Inserts para a tabela user_team
insert into user_team (user_id, team_id) values
                                             (1, 1),
                                             (2, 2);

select * from functionary;
    