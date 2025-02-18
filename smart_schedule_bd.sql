CREATE DATABASE IF NOT EXISTS smart_schedule_db;
USE smart_schedule_db;

-- Tabela de Usuários
CREATE TABLE users (
                       id INT PRIMARY KEY AUTO_INCREMENT UNIQUE,
                       name VARCHAR(100) NOT NULL,
                       cpf VARCHAR(11) NOT NULL UNIQUE,
                       email VARCHAR(100) NOT NULL UNIQUE,
                       cellphone VARCHAR(15),
                       username VARCHAR(50) NOT NULL UNIQUE,
                       password VARCHAR(255) NOT NULL
);

-- Tabela de Times/Equipes
CREATE TABLE team (
                      id INT PRIMARY KEY AUTO_INCREMENT UNIQUE,
                      name VARCHAR(100) NOT NULL,
                      description TEXT
);

-- Tabela de Funções (Roles)
CREATE TABLE role (
                      id INT PRIMARY KEY AUTO_INCREMENT UNIQUE,
                      name VARCHAR(100) NOT NULL,
                      description TEXT
);

-- Tabela de Associação Entre Usuários e Times
CREATE TABLE member (
                        id INT PRIMARY KEY AUTO_INCREMENT UNIQUE,
                        user_id INT NOT NULL,
                        team_id INT NOT NULL,
                        role_id INT NOT NULL,
                        FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
                        FOREIGN KEY (team_id) REFERENCES team(id) ON DELETE CASCADE,
                        FOREIGN KEY (role_id) REFERENCES role(id) ON DELETE CASCADE
);

-- Tabela de Assignment
CREATE TABLE assignment (
                            id INT PRIMARY KEY AUTO_INCREMENT UNIQUE,
                            name VARCHAR(100) NOT NULL,
                            description TEXT,
                            due_date DATE
);

-- Tabela de Scheduled
CREATE TABLE scheduled (
                           id INT PRIMARY KEY AUTO_INCREMENT UNIQUE,
                           name VARCHAR(100) NOT NULL,
                           description TEXT,
                           start DATE NOT NULL,
                           end DATE
);

-- Tabela de Assigned (Associação entre membro, assignment e scheduled)
CREATE TABLE assigned (
                          id INT PRIMARY KEY AUTO_INCREMENT UNIQUE,
                          member_id INT NOT NULL,
                          assignment_id INT NOT NULL,
                          scheduled_id INT NOT NULL,
                          FOREIGN KEY (member_id) REFERENCES member(id) ON DELETE CASCADE,
                          FOREIGN KEY (assignment_id) REFERENCES assignment(id) ON DELETE CASCADE,
                          FOREIGN KEY (scheduled_id) REFERENCES scheduled(id) ON DELETE CASCADE
);

-- Inserts para a tabela users
INSERT INTO users (name, cpf, email, cellphone, username, password) VALUES
                                                                        ('John Doe', '12345678901', 'john.doe@example.com', '1234567890', 'johndoe', 'password123'),
                                                                        ('Jane Smith', '23456789012', 'jane.smith@example.com', '0987654321', 'janesmith', 'password456');

-- Inserts para a tabela team
INSERT INTO team (name, description) VALUES
                                         ('Development', 'Development Team'),
                                         ('Marketing', 'Marketing Team');

-- Inserts para a tabela role
INSERT INTO role (name, description) VALUES
                                         ('Developer', 'Software Developer'),
                                         ('Manager', 'Team Manager');

-- Inserts para a tabela member
INSERT INTO member (user_id, team_id, role_id) VALUES
                                                   (1, 1, 1),  -- John Doe como Developer na Development Team
                                                   (2, 2, 2);  -- Jane Smith como Manager na Marketing Team

-- Inserts para a tabela assignment
INSERT INTO assignment (name, description, due_date) VALUES
                                                         ('Task 1', 'Descrição da Task 1', '2025-02-15'),
                                                         ('Task 2', 'Descrição da Task 2', '2025-02-20');

-- Inserts para a tabela scheduled
INSERT INTO scheduled (name, description, start) VALUES
    ('BUG no BD', 'Banco de Dados', '2025-02-12');

-- Inserts para a tabela assigned
INSERT INTO assigned (member_id, assignment_id, scheduled_id) VALUES
                                                                  (1, 1, 1),
                                                                  (2, 2, 1);
