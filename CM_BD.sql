DROP DATABASE IF EXISTS CM_BD;
CREATE DATABASE CM_BD;



USE CM_BD;



CREATE TABLE jugadores(

    id INT NOT NULL,

    Nickname VARCHAR(15),

    Password VARCHAR(15),

    PRIMARY KEY (id)



)ENGINE=InnoDB;



CREATE TABLE partidas(

    id INT NOT NULL,

    Ganador VARCHAR(20),

    Fecha VARCHAR(15),

    Hora VARCHAR(10),

    Duracion FLOAT,  

    PRIMARY KEY (id)

)ENGINE=InnoDB;



CREATE TABLE datos(

    idJ1 INT NOT NULL,

    idJ2 INT NOT NULL,

    idP INT NOT NULL,

    Puntos INT NOT NULL,

    FOREIGN KEY (idP) REFERENCES partidas(id),

    FOREIGN KEY (idJ1) REFERENCES jugadores(id),

    FOREIGN KEY (idJ2) REFERENCES jugadores(id)



)ENGINE=InnoDB;




INSERT INTO jugadores (id, Nickname, Password)

VALUES (1,'munyi','abcd'); 



INSERT INTO jugadores (id, Nickname, Password)

VALUES (2,'titi','abcde'); 



INSERT INTO jugadores (id, Nickname, Password)

VALUES (3, 'manolin','abcd2'); 



INSERT INTO jugadores (id, Nickname, Password)

VALUES (4, 'jj','1a2b');



SELECT * FROM jugadores;



INSERT INTO partidas (id, Ganador, Fecha, Hora, Duracion)

VALUES (1,'manolin','27-11-2016', '10:56', 1.56); 



INSERT INTO partidas (id, Ganador, Fecha, Hora, Duracion)

VALUES (2,'munyi','13-08-2021', '23:51', 3.04); 



INSERT INTO partidas (id, Ganador, Fecha, Hora, Duracion)

VALUES (3,'manolin','14-01-2022', '06:10', 6.35); 


INSERT INTO partidas (id, Ganador, Fecha, Hora, Duracion)

VALUES (4,'titi','03-03-2022', '19:19', 9.2); 



SELECT * FROM partidas;







INSERT INTO datos (idJ1, idJ2, idP, Puntos)

VALUES (3, 4, 1, 5); 


INSERT INTO datos (idJ1, idJ2, idP, Puntos)

VALUES (1, 2, 2, 5); 



INSERT INTO datos (idJ1, idJ2, idP, Puntos)

VALUES (2, 3, 3, 5); 



INSERT INTO datos (idJ1, idJ2, idP, Puntos)

VALUES (4, 2, 4, 5); 

