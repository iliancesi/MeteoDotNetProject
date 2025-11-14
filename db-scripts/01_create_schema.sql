-- Crée la base de données
CREATE DATABASE db_meteo; 

-- Indique que les commandes suivantes doivent s'appliquer à cette base
USE db_meteo;

-- Table 1 : VILLES
CREATE TABLE Villes (
    id_ville INT NOT NULL AUTO_INCREMENT,
    nom_ville VARCHAR(100) NOT NULL,
    code_postal VARCHAR(10) UNIQUE,
    PRIMARY KEY (id_ville)
);

-- Table 2 : STATIONS
CREATE TABLE Stations (
    id_station INT NOT NULL AUTO_INCREMENT,
    id_ville INT NOT NULL, 
    nom_station VARCHAR(100) NOT NULL, 
    latitude DECIMAL(10, 8) NOT NULL,
    longitude DECIMAL(11, 8) NOT NULL,
    PRIMARY KEY (id_station),
    FOREIGN KEY (id_ville) REFERENCES Villes(id_ville)
);

-- Table 3 : RELEVESMETEO
CREATE TABLE RelevesMeteo (
    id_releve INT NOT NULL AUTO_INCREMENT,
    id_station INT NOT NULL, 
    horodatage DATETIME NOT NULL,
    temperature_celsius DECIMAL(5, 2) NOT NULL,
    humidite_pourcentage DECIMAL(5, 2),
    vitesse_vent_kmh DECIMAL(5, 2),
    PRIMARY KEY (id_releve),
    FOREIGN KEY (id_station) REFERENCES Stations(id_station)
);

-- Insertion des Villes
INSERT INTO Villes (nom_ville, code_postal) VALUES 
('Paris', '75000'),
('Lyon', '69000'),
('Marseille', '13000');

-- Insertion des Stations
INSERT INTO Stations (id_ville, nom_station, latitude, longitude) VALUES 
(1, 'Paris - Tour Eiffel', 48.8584, 2.2945), 
(1, 'Paris - La Villette', 48.8920, 2.3888),
(2, 'Lyon - Vieux Lyon', 45.7611, 4.8277),  
(3, 'Marseille - Port', 43.2952, 5.3728); 

-- Insertion de Relevés 
INSERT INTO RelevesMeteo (id_station, horodatage, temperature_celsius, humidite_pourcentage) VALUES 
(1, NOW(), 15.5, 70.0), 
(2, NOW(), 14.8, 68.0), 
(3, NOW(), 18.2, 65.0), 
(4, NOW(), 20.1, 55.0);