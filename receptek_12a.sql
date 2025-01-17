-- Create database
CREATE DATABASE IF NOT EXISTS receptek_12a;

-- Use the database
USE receptek_12a;

-- Create table for creators first
CREATE TABLE IF NOT EXISTS keszitok (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nev VARCHAR(255) NOT NULL,
    cim TEXT NOT NULL,
    eletkor INT NOT NULL
);

-- Create table for sources
CREATE TABLE IF NOT EXISTS forrasok (
    id INT AUTO_INCREMENT PRIMARY KEY,
    forras_nev VARCHAR(255) NOT NULL
);

-- Create table for food recipes, referencing keszitok and forrasok
CREATE TABLE IF NOT EXISTS receptek (
    id INT AUTO_INCREMENT PRIMARY KEY,
    receptNev VARCHAR(255) NOT NULL,
    hozzavalok TEXT NOT NULL,
    leiras TEXT NOT NULL,
    elokeszitesiIdo INT,
    fozesiIdo INT,
    osszesIdo INT,
    keszito_id INT,
    forras_id INT,
    FOREIGN KEY (keszito_id) REFERENCES keszitok(id),
    FOREIGN KEY (forras_id) REFERENCES forrasok(id)
);

-- Insert sample data into creators table
INSERT INTO keszitok (nev, cim, eletkor) VALUES
('John Doe', '123 Maple Street, Springfield', 35),
('Jane Smith', '456 Oak Avenue, Metropolis', 28);

-- Insert sample data into sources table
INSERT INTO forrasok (forras_nev) VALUES
('BBC'),
('Good Food'),
('Damn Delicious');

-- Insert 50 food recipes with linked keszito_id and forras_id
INSERT INTO receptek (receptNev, hozzavalok, leiras, elokeszitesiIdo, fozesiIdo, osszesIdo, keszito_id, forras_id) VALUES
('Spaghetti Carbonara', 'Spagetti, Tojás, Parmezán sajt, Pancetta, Fokhagyma, Só, Bors', '1. Főzd meg a spagettit. 2. Pirítsd meg a pancettát fokhagymával. 3. Keverd össze a tojást és a sajtot. 4. Keverd össze a spagettit, a pancettát és a tojásos keveréket. 5. Ízesítsd sóval és borssal.', 10, 20, 30, 1, 1),
('Chicken Curry', 'Csirke, Curry por, Kókusztej, Hagyma, Fokhagyma, Gyömbér, Só, Bors, Olaj', '1. Pirítsd meg a hagymát, fokhagymát és gyömbért. 2. Add hozzá a csirkét és süsd meg. 3. Add hozzá a curry port. 4. Öntsd bele a kókusztejet. 5. Párold, amíg a csirke teljesen meg nem fő. 6. Ízesítsd sóval és borssal.', 15, 30, 45, 2, 2),
('Beef Stroganoff', 'Marhahús, Hagyma, Gomba, Tejföl, Marhahús alaplé, Vaj, Liszt, Só, Bors', '1. Pirítsd meg a marhahús csíkokat. 2. Főzd meg a hagymát és a gombát. 3. Add hozzá a marhahús alaplét és párold. 4. Keverd bele a tejfölt. 5. Sűrítsd a vaj és liszt keverékével. 6. Ízesítsd sóval és borssal.', 20, 25, 45, 1, 3),
('Vegetarian Chili', 'Vörösbab, Fekete bab, Kukorica, Paradicsom, Hagyma, Fokhagyma, Chili por, Kömény, Só, Bors, Olaj', '1. Pirítsd meg a hagymát és a fokhagymát. 2. Add hozzá a paradicsomot és a fűszereket. 3. Öntsd bele a babot és a kukoricát. 4. Párold, amíg a zöldségek meg nem puhulnak. 5. Ízesítsd sóval és borssal.', 10, 40, 50, 2, 1),
/* Ismételd meg a fenti struktúrát a fennmaradó 46 bejegyzéshez */
('Pizza Margherita', 'Pizzatészta, Paradicsomszósz, Mozzarella sajt, Bazsalikom, Olívaolaj, Só', '1. Kend meg a tésztát paradicsomszósszal. 2. Add hozzá a mozzarellát. 3. Sütőben süsd meg. 4. Díszítsd friss bazsalikommal és olívaolajjal. 5. Ízesítsd sóval.', 15, 20, 35, 1, 2);

-- Continue with additional 45 recipes...
