create database smart_schedule_db;

use smart_schedule_db;

create table functionary (
	id int primary key auto_increment unique,
    name varchar(100) not null,
    cpf varchar(11) not null unique,
    siape varchar(20) not null unique
);

insert into functionary (name, cpf, siape) values
    ('Danilo Saiter da Silva', '03442444233', '11111'),
    ('Wester Jesuíno', '22222222222', '22222'),
    ('Adrian Henrique Ferreira', '33333333333', '33333'),
    ('Marcão', '44444444444', '44444');
    
select * from functionary;
    